namespace HL7Generator.Base.Model
{
    public interface ISegment
    {
        void BuildSegment();
        string GenerateSegment();
    }
}
