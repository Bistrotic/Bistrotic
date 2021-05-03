using System;
using System.Xml;

namespace Bistrotic.UblDocuments.Helpers
{
    public static class DateHelper
    {
        public static DateTimeOffset ToDateTime(this (string? date, string? time) dateTime)
        {
            DateTime d = XmlConvert.ToDateTime(dateTime.date ?? string.Empty, XmlDateTimeSerializationMode.Utc);
            DateTimeOffset t = XmlConvert.ToDateTimeOffset(dateTime.time ?? string.Empty);
            return new DateTimeOffset(
                d.Year, d.Month, d.Day,
                t.Hour, t.Minute, t.Second, t.Millisecond, t.Offset
                );
        }

        public static (string? date, string? time) ToDateTimeStrings(this DateTimeOffset? dateTime)
            => (dateTime == null) ? (null, null) : (XmlConvert.ToString(dateTime.Value, "yyyy-MM-dd"), XmlConvert.ToString(dateTime.Value).Split('T')[^1]);

        public static (string date, string time) ToDateTimeStrings(this DateTimeOffset dateTime)
            => (XmlConvert.ToString(dateTime, "yyyy-MM-dd"), XmlConvert.ToString(dateTime).Split('T')[^1]);
    }
}