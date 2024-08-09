using MiniProject3.Models;

namespace MiniProject3.Interfaces
{
    public interface IWorksonService
    {
        Task<IEnumerable<Workson>> GetAllWorkOn();
        Task<Workson> GetWorkOnById(int empNo, int projNo);
        Task<Workson> AddWorkOn(Workson workOn);
        Task<Workson> UpdateWorkOn(int empNo, int projNo, Workson workson);
        Task<bool> DeleteWorkOn(int empNo, int projNo);
    }
}
