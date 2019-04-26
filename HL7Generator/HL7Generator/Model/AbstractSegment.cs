using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HL7Generator.Base.Model
{
    public abstract class AbstractSegment : BaseSequence, ISegment
    {
        #region Properties
        private readonly List<AbstractSequenceItem> _items;
        public GeneratorConfigurator Config { get; set; }

        /// <summary>
        /// Provides a way to differentiate the segment from others since it is possible to have multiple of the same type.
        /// </summary>
        public Guid SegmentId { get; set; }

        internal List<AbstractSequenceItem> Items
        {
            get { return _items; }
        }

        /// <summary>
        /// The name of the segment.
        /// </summary>
        public string SegmentName { get; set; }
        #endregion

        protected AbstractSegment(string segmentName)
        {
            _items = new List<AbstractSequenceItem>();
            SegmentName = segmentName;
            SequenceName = segmentName;
            SegmentId = Guid.NewGuid();
            InitializeSegmentFields();
        }

        /// <summary>
        /// Sets the value in the segment for a particular field the user chooses. It should be noted that the fields are 1 based, not zero.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="value"></param>
        public virtual void SetValue(int position, string value)
        {
            _items[position - 1]._value = value;
        }

        /// <summary>
        /// Sets the configurator that the segment will use.
        /// </summary>
        /// <param name="configurator"></param>
        public virtual void SetConfigurator(GeneratorConfigurator configurator)
        {
            Config = configurator;
        }

        /// <summary>
        /// Gets the field description for the particular location in the segment. If you wanted the description for MSH.11, you'd enter 11 as a parameter.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public virtual string GetFieldDescription(int position)
        {
            return _items[position - 1]._description;
        }

        public string GetFieldValue(int position)
        {
            return _items[position - 1]._value;
        }

        public string GetFieldValueBySequenceNumber(int sequenceNumber)
        {
            var itemToFind = _items.FirstOrDefault(x => x._sequenceNumber == sequenceNumber);
            if (itemToFind == null)
                throw new InvalidOperationException("Could not find a field with the sequence number of " + sequenceNumber);
            return itemToFind._value;
        }

        /// <summary>
        /// This method is responsible for setting the initial description for each field in the segment using the "Add()" method.
        /// </summary>
        public abstract void InitializeSegmentFields();

        public List<string> GetFieldDescriptionsAndValues()
        {
            var fields = new List<string>();
            int count = 1;
            foreach (var item in _items)
            {
                fields.Add(SegmentName + "." + count + " - " + item._description + " - " + item._value);
                count++;
            }

            return fields;
        }

        public string GetFieldDescriptionAndValue(int position)
        {
            return GetFieldDescription(position) + " - " + GetFieldValue(position);
        }

        /// <summary>
        /// Returns the number of fields in the segment.
        /// </summary>
        /// <returns></returns>
        public virtual int NumFields()
        {
            return _items.Count;
        }


        /// <summary>
        /// Builds the completed segment. It is assumed that once this method is called, all data is set.
        /// </summary>
        public abstract void BuildSegment();

        public string GenerateSegment()
        {
            return ConvertToHL7();
        }
    }
}
