using System.Collections.Generic;
using HL7Generator.Base.Model;

namespace HL7Generator.Base.DataType
{
    public abstract class AbstractDataType : BaseSequence
    {
        private readonly List<AbstractSequenceItem> _items = new List<AbstractSequenceItem>();
        public abstract void InitializeDataType();
    }
}
