
namespace Users
{
    public interface IJob
    {
        string JobTitle { get; }
        
        string JobDescription { get; }
        
        decimal JobSalary { get; }

        void SelfPresentation();
    }
}
