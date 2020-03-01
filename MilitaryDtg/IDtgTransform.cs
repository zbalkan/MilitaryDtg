namespace MilitaryDtg
{
    internal interface IDtgTransform
    {
        string DtgStringValue { get; set; }
        int Year { get; set; }
        int Month { get; set; }
        int Day { get; set; }
        int Hour { get; set; }
        int Minute { get; set; }
        int Second { get; set; }
        string MilTimeZoneAbbreviation { get; set; }
    }
}