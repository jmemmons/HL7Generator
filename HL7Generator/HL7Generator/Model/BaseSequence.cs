using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HL7Generator.Base.Model
{
    public abstract class BaseSequence
    {
        internal string SequenceName { get; set; }
        private readonly List<AbstractSequenceItem> _items = new List<AbstractSequenceItem>();

        protected internal virtual void SetField<T>(int sequenceNumber, int length, DataType dataType, Optionality optionalCode, T repetition, string elementName, string value = null)
        {
            _items.Add(new AbstractSequenceItem(sequenceNumber, length, dataType, optionalCode.GetDescription(), repetition.ToString(), elementName, value));
        }

        protected internal virtual void SetField(int sequenceNumber, int length, DataType dataType, Optionality optionalCode, string elementName, string value = null)
        {
            _items.Add(new AbstractSequenceItem(sequenceNumber, length, dataType, optionalCode.GetDescription(), "*", elementName, value));
        }

        public virtual void SetFieldValue<T>(int sequenceNumber, T value)
        {
            var itemToSet = _items.FirstOrDefault(x => x._sequenceNumber == sequenceNumber);
            if (itemToSet == null)
                throw new InvalidOperationException("Could not find a field with the sequence number of " + sequenceNumber);
            itemToSet._value = (value != null) ? value.ToString() : null;
        }

        /// <summary>
        /// Gets a list of formatted strings which represents the segment field descriptions and their values
        /// </summary>
        /// <returns></returns>
        public List<string> GetFieldDescriptions()
        {
            var fields = new List<string>();
            int count = 1;
            foreach (var item in _items)
            {
                fields.Add(SequenceName + "." + count + " - " + item._description);
                count++;
            }

            return fields;
        }

        /// <summary>
        /// This method was created for visualization of the segment with the intent of it being used with a UI of some sort.
        /// </summary>
        /// <returns></returns>
        public DataTable GetSegmentDetails()
        {
            var dataTable = new DataTable("SegmentFields");
            dataTable.Columns.Add("FieldName");
            dataTable.Columns.Add("FieldValue");

            int count = 1;
            foreach (var item in _items)
            {
                var row = dataTable.NewRow();
                row[0] = SequenceName + "." + count++ + " - " + item._description;
                row[1] = item._value;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        /// <summary>
        /// This method puts a pipe symbol, "|" in between each field in the segment before adding a carriage return
        /// </summary>
        /// <returns></returns>
        public string ConvertToHL7()
        {
            StringBuilder sb = new StringBuilder(SequenceName + "|");
            _items.ForEach(item => sb.Append(item._value + "|"));
            sb.Append("\r\n");

            return sb.ToString();
        }
    }
}
