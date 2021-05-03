using System;
using System.Xml;

namespace Bistrotic.UblDocuments.Helpers
{
    public static class DateHelper
    {
        public static string? ToDateString(this DateTimeOffset? date)
             => (date == null) ? null : XmlConvert.ToString(date.Value, "yyyy-MM-dd");

        public static DateTimeOffset ToDateTime(this (string date, string? time) dateTime)
        {
            if (string.IsNullOrWhiteSpace(dateTime.date))
            {
                throw new ArgumentException("Date must be defined", nameof(dateTime));
            }

            DateTime d = XmlConvert.ToDateTime(dateTime.date, XmlDateTimeSerializationMode.Utc);
            if (string.IsNullOrWhiteSpace(dateTime.time))
            {
                return d;
            }

            DateTimeOffset t = XmlConvert.ToDateTimeOffset(dateTime.time);
            return new DateTimeOffset(
                d.Year, d.Month, d.Day,
                t.Hour, t.Minute, t.Second, t.Millisecond, t.Offset
                );
        }

        public static DateTimeOffset ToDateTime(this string? date)
            => XmlConvert.ToDateTime(date ?? string.Empty, XmlDateTimeSerializationMode.Local);

        public static (string? date, string? time) ToDateTimeStrings(this DateTimeOffset? dateTime)
            => (dateTime == null) ? (null, null) : (XmlConvert.ToString(dateTime.Value, "yyyy-MM-dd"), XmlConvert.ToString(dateTime.Value).Split('T')[^1]);

        public static (string date, string time) ToDateTimeStrings(this DateTimeOffset dateTime)
            => (XmlConvert.ToString(dateTime, "yyyy-MM-dd"), XmlConvert.ToString(dateTime).Split('T')[^1]);

        public static DateTimeOffset? ToNullableDateTime(this (string? date, string? time) dateTime)
        {
            if (string.IsNullOrWhiteSpace(dateTime.date) && string.IsNullOrWhiteSpace(dateTime.time))
            {
                return null;
            }
            return (dateTime.date ?? string.Empty, dateTime.time ?? string.Empty).ToDateTime();
        }
    }
}