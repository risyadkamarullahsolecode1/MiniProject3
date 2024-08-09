using MiniProject3.Models;

namespace MiniProject3.Interfaces
{
    public interface IWorksonService
    {
        List<Workson> GetAllWorkOns();
        Workson GetWorkOnById(int empNo, int projNo);
        Workson AddWorkOn(Workson workOn);
        Workson UpdateWorkOn(int empNo, int projNo, Workson workson);
        bool DeleteWorkOn(int empNo, int projNo);
    }
}
