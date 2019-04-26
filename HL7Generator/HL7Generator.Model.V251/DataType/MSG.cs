using System.ComponentModel;
using HL7Generator.Base;
using HL7Generator.Base.DataType;
using HL7Generator.Base.Model;

namespace HL7Generator.Model.V251.DataType
{
    [Description("Message Type")]
    public class MSG : AbstractDataType
    {
        public string MessageCode { get; set; }
        public string TriggerEvent { get; set; }
        public string MessageStructure { get; set; }

        public MSG(GeneratorConfigurator config = null)
        {
            if (config == null) return;
            MessageCode = config.MessageType.GetDescription();
            TriggerEvent = config.MessageTriggerEvent;
        }

        public override string ToString()
        {
            return $"{MessageCode}^{TriggerEvent}^{MessageStructure}";
        }

        public override void InitializeDataType()
        {
            SetField(1, 3, Base.Model.DataType.ID, Optionality.R, "Message Code");
            SetField(2, 3, Base.Model.DataType.ID, Optionality.R, "Trigger Event");
            SetField(3, 7, Base.Model.DataType.ID, Optionality.R, "Message Structure");
        }
    }
}
