using System.ComponentModel;
using HL7Generator.Base.DataType;
using HL7Generator.Base.Model;

namespace HL7Generator.Model.V251.DataType
{
    [Description("Street Address")]
    public class SAD : AbstractDataType
    {
        public override void InitializeDataType()
        {
            SetField(1, 120, Base.Model.DataType.ST, Optionality.O, "Street Or Mailing Address");
            SetField(2, 50, Base.Model.DataType.ST, Optionality.O, "Street Name");
            SetField(3, 12, Base.Model.DataType.ST, Optionality.O, "Dwelling Number");
        }
    }
}
