
namespace Users
{
    public interface IReportGenerator
    {
        void PrintLine();
        
        void PrintRow(params string[] columns);
        
        string AlignCentre(string text, int width);
    }
}
