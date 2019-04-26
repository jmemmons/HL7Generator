using HL7Generator.Base.DataType;

namespace HL7Generator.Base.Model
{
    internal class AbstractSequenceItem
    {
        internal int _sequenceNumber { get; set; }
        internal int _length { get; set; }
        internal DataType _dataType { get; set; }
        internal string _optionalCode { get; set; }
        internal string _repeatable { get; set; }
        internal string _description { get; set; }
        internal string _value { get; set; }


        internal AbstractSequenceItem(string description, string value)
        {
            _description = description;
            _value = value;
        }

        public AbstractSequenceItem(int sequenceNumber, int length, DataType dataType, string optionalCode, string repeatable, string description, string value)
        {
            _sequenceNumber = sequenceNumber;
            _length = length;
            _dataType = dataType;
            _optionalCode = optionalCode;
            _repeatable = repeatable;
            _description = description;
            _value = value;
        }
    }
}
