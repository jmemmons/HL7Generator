using System.ComponentModel;
using HL7Generator.Base.DataType;
using HL7Generator.Base.Model;

namespace HL7Generator.Model.V251.DataType
{
    [Description("Hierarchic Designator")]
    public class HD : AbstractDataType
    {
        public override void InitializeDataType()
        {
            SetField(1, 20, Base.Model.DataType.IS, Optionality.O, "Namespace Id");
            SetField(2, 199, Base.Model.DataType.ST, Optionality.C, "Universal Id");
            SetField(3, 6, Base.Model.DataType.ID, Optionality.C, "Universal Id Type");
        }
    }
}
