using HL7Generator.Base;
using HL7Generator.Base.Model;
using HL7Generator.Model.V251.DataType;

namespace HL7Generator.Model.V251.Segment
{
    public class MSH : AbstractSegment
    {
        public MSH() : base("MSH")
        {
          
        }

        public sealed override void InitializeSegmentFields()
        {
            //SetField(1, 1, Base.Model.DataType.ST, Optionality.R, 1, "Field Separator");
            SetField(2, 4, Base.Model.DataType.ST, Optionality.R, 1, "Encoding Characters");
            SetField(3, 227, Base.Model.DataType.HD, Optionality.O, 1, "Sending Application");
            SetField(4, 227, Base.Model.DataType.HD, Optionality.O, 1, "Sending Facility");
            SetField(5, 227, Base.Model.DataType.HD, Optionality.O, 1, "Receiving Application");
            SetField(6, 227, Base.Model.DataType.HD, Optionality.O, 1, "Receiving Facility");
            SetField(7, 26, Base.Model.DataType.TS, Optionality.R, 1, "Date/Time of Message");
            SetField(8, 40, Base.Model.DataType.ST, Optionality.O, 1, "Security");
            SetField(9, 15, Base.Model.DataType.MSG, Optionality.R, 1, "Message Type");
            SetField(10, 20, Base.Model.DataType.ST, Optionality.R, 1, "Message Control Id");
            SetField(11, 3, Base.Model.DataType.PT, Optionality.R, 1, "Processing Id");
            SetField(12, 60, Base.Model.DataType.VID, Optionality.R, 1, "Version Id");
            SetField(13, 15, Base.Model.DataType.NM, Optionality.O, 1, "Sequence Number");
            SetField(14, 180, Base.Model.DataType.ST, Optionality.O, 1, "Continuation Pointer");
            SetField(15, 2, Base.Model.DataType.ID, Optionality.O, 1, "Accept Acknowledgement Type");
            SetField(16, 2, Base.Model.DataType.ID, Optionality.O, 1, "Application Acknowledgement Type");
            SetField(17, 3, Base.Model.DataType.ID, Optionality.O, 1, "Country Code");
            SetField(18, 16, Base.Model.DataType.ID, Optionality.O, "Character Set");
            SetField(19, 250, Base.Model.DataType.CE, Optionality.O, 1, "Principal Language of Message");
            SetField(20, 20, Base.Model.DataType.ID, Optionality.O, 1, "Alternate Character Set Handling Scheme");
            SetField(21, 427, Base.Model.DataType.EI, Optionality.O, "Message Profile Identifier");
        }

        public override void BuildSegment()
        {
            SetFieldValue(2, "^~&");
            SetFieldValue(9, new MSG(Config));
            SetFieldValue(11, "T");
            SetFieldValue(12, "2.5.1");
            SetFieldValue(15, "NE");
            SetFieldValue(16, "AL");
            SetFieldValue(17, "USA");
            SetFieldValue(18, "ASCII");
        }
    }
}
