using System;

namespace MilitaryDtg
{
    public class DTG : IMilDate
    {
        private readonly MilDate _milDate;

        public DTG()
        {
            _milDate = new MilDate();
        }

        internal DTG(IMilDate milDate)
        {
            _milDate = (MilDate)milDate;
        }

        /// <inheritdoc />
        public IMilTimeZone MilTimeZone
        {
            get => _milDate.MilTimeZone;
            set => _milDate.MilTimeZone = value;
        }

        /// <inheritdoc />
        public DateTimeOffset? MilDateOffset
        {
            get => _milDate.MilDateOffset;
            set => _milDate.MilDateOffset = value;
        }

        /// <inheritdoc />
        public string ToString(string format) => _milDate.ToString();
    }
}
