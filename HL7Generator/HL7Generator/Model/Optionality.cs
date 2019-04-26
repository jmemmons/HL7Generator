using System.ComponentModel;

namespace HL7Generator.Base.Model
{
    public enum Optionality
    {
        [Description("Included for backwards compatibility with previous versions")] B,
        [Description("Conditional")] C,
        [Description("Conditional but may be empty")] CE,
        [Description("Optional")] O,
        [Description("Required")] R,
        [Description("Required but may be empty")] RE,
        [Description("Not supported")] X,
    }
}
