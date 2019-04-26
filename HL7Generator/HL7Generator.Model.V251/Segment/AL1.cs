using System;
using HL7Generator.Base.Model;

namespace HL7Generator.Model.V251.Segment
{
    public class AL1 : AbstractSegment
    {
        public AL1() : base("AL1")
        {

        }

        public override void InitializeSegmentFields()
        {
            SetField(1, 4, Base.Model.DataType.ST, Optionality.R, 1, "Set ID");
            SetField(2, 250, Base.Model.DataType.CE, Optionality.O, 1, "Allergy Type");
            SetField(3, 250, Base.Model.DataType.CE, Optionality.R, 1, "Allergy Code/Mnemonic/Description");
            SetField(4, 250, Base.Model.DataType.CE, Optionality.O, 1, "Allergy Severity");
            SetField(5, 15, Base.Model.DataType.ST, Optionality.O, "Allergy Reaction");
            SetField(6, 8, Base.Model.DataType.DT, Optionality.B, 1, "Identification Date");
        }

        public override void BuildSegment()
        {
            throw new NotImplementedException();
        }
    }
}
