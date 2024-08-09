using Microsoft.EntityFrameworkCore;
using MiniProject3.Interfaces;
using MiniProject3.Models;

namespace MiniProject3.Services
{
    public class WorksonService:IWorksonService
    {
        private readonly CompanyContext _context;

        public WorksonService(CompanyContext context)
        {
            _context = context;
        }

        public List<Workson> GetAllWorkOns()
        {
            return _context.Worksons.ToList();
        }

        public Workson GetWorkOnById(int empNo, int projNo)
        {
            return _context.Worksons.Find(empNo, projNo);
        }

        public Workson AddWorkOn(Workson workson)
        {
            _context.Worksons.Add(workson);
            _context.SaveChanges();
            return workson;
        }

        public Workson UpdateWorkOn(int empNo, int projNo, Workson workson)
        {
            if (empNo != workson.Empno || projNo != workson.Projno)
            {
                return null;
            }

            _context.Entry(workson).State = EntityState.Modified;
            _context.SaveChanges();
            return workson;
        }

        public bool DeleteWorkOn(int empNo, int projNo)
        {
            var workOn = _context.Worksons
                .FirstOrDefault(wo => wo.Empno == empNo && wo.Projno == projNo);

            if (workOn == null)
            {
                return false;
            }

            _context.Worksons.Remove(workOn);
            _context.SaveChanges();
            return true;
        }

    }
}
