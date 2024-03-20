namespace FluentSysInfo
{
    internal class DateTimeModel
    {

        public string DateTime { get; set; }

        public string DateTimeUTC { get; set; }

        public string DateOnly { get; set; }

        public string TimeOnly { get; set; }

        public string LongDate { get; set; }

        public string DayOfWeek { get; set; }

        public string FullDateTime { get; set; }



        public DateTimeModel(string dateTime,
                             string dateTimeUTC,
                             string dateOnly,
                             string timeOnly,
                             string longDate,
                             string fullDateTime,
                             string dayOfWeek)
        {
            DateTime = dateTime;
            DateTimeUTC = dateTimeUTC;
            DateOnly = dateOnly;
            TimeOnly = timeOnly;
            LongDate = longDate;
            FullDateTime = fullDateTime;
            DayOfWeek = dayOfWeek;
        }







    }


}
