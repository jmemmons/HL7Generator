using System;
using System.ComponentModel;

namespace HL7Generator.Base
{
    public class GeneratorConfigurator
    {
        public MessageType MessageType { get; set; }
        public string MessageTriggerEvent { get; set; }
        public DateTime MessageDateTimeUtc { get; set; }

        public GeneratorConfigurator()
        {
            MessageDateTimeUtc = DateTime.UtcNow;
        }
    }

    public enum MessageType
    {
        [Description("ADT")]
        ADT = -8,

        [Description("DFT")]
        DFT = -2,

        [Description("MDM")]
        MDM = -3,

        [Description("ORU")]
        ORU = -5,

        [Description("CCDA")]
        CCDA = 0
    }
}
