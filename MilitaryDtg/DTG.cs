using System;

namespace MilitaryDtg
{
    public class DTG : IMilDate
    {
        private readonly MilDate _milDate;

        public DTG() => _milDate = new MilDate();

        internal DTG(IMilDate milDate) => _milDate = (MilDate) milDate;

        /// <inheritdoc />
        public DTZ DTZ
        {
            get => _milDate.DTZ;
            set => _milDate.DTZ = value;
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