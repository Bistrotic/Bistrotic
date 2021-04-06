using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Bistrotic.DataIntegrations.Common.Domain.ValueTypes;
using Bistrotic.DataIntegrations.Contracts.Events;
using Bistrotic.DataIntegrations.Domain.States;

using ExcelDataReader;

namespace Bistrotic.DataIntegrations.Domain
{
    internal class DataIntegration
    {
        private readonly string _id;
        private readonly IDataIntegrationState _state;

        public DataIntegration(string id, IDataIntegrationState state)
        {
            _id = id;
            _state = state;
        }

        public Task<IEnumerable<object>> Normalize()
        {
            FileType.TryParse(typeof(FileType), _state.DocumentType, true, out object? fileType);
            string? data = null;
            var content = Convert.FromBase64String(_state.Document);
            switch (fileType)
            {
                case FileType.Csv:
                    {
                        using IExcelDataReader reader = ExcelReaderFactory.CreateCsvReader(new MemoryStream(content),
                            new ExcelReaderConfiguration
                            {
                                AutodetectSeparators = new char[] { ',', ';', '\t', '|', '#' }
                            });
                        DataSet dataset = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true,
                            }
                        }); ;
                        data = ConverToJson(dataset);
                        break;
                    }
                case FileType.Xls:
                case FileType.Xlsx:
                case FileType.Xlsb:
                    {
                        using IExcelDataReader reader = ExcelReaderFactory.CreateReader(new MemoryStream(content));
                        DataSet dataset = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });
                        List<dynamic> recs = new();
                        dynamic rec;
                        while ((rec = reader.Read()) != null)
                        {
                            recs.Add(rec);
                        }
                        data = ConverToJson(dataset);
                        break;
                    }
                default:
                    return Task.FromResult<IEnumerable<object>>(Array.Empty<object>());
            }
            List<object> events = new();
            events.Add(new DataIntegrationNormalized
            {
                DataIntegrationId = _id,
                Name = _state.Name,
                Description = _state.Description,
                Data = data ?? string.Empty
            });
            _state.Apply(events);
            return Task.FromResult<IEnumerable<object>>(events);
        }

        public Task<IEnumerable<object>> Submit(
                    string name,
            string description,
            string documentName,
            string documentType,
            string document)
        {
            if (string.IsNullOrWhiteSpace(documentType))
            {
                documentType = Path.GetExtension(documentName) switch
                {
                    ".CSV" => FileType.Csv.ToString(),
                    ".TXT" => FileType.Csv.ToString(),
                    ".XML" => FileType.Xml.ToString(),
                    ".XLS" => FileType.Xls.ToString(),
                    ".XLSX" => FileType.Xlsx.ToString(),
                    _ => string.Empty
                };
            }
            List<object> events = new();
            events.Add(new DataIntegrationSubmitted
            {
                DataIntegrationId = _id,
                Name = name,
                Description = description,
                DocumentName = documentName,
                DocumentType = documentType,
                Document = document
            });
            _state.Apply(events);
            return Task.FromResult<IEnumerable<object>>(events);
        }

        private static string ConverToJson(DataSet dataSet)
        {
            using var stream = new MemoryStream();
            using var jsonWriter = new Utf8JsonWriter(stream);
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                jsonWriter.WriteStartArray();
                var table = dataSet.Tables[i];
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    dynamic rec = new ExpandoObject();
                }
                jsonWriter.WriteEndArray();
            }
            return Encoding.UTF8.GetString(stream.GetBuffer());
        }
    }
}