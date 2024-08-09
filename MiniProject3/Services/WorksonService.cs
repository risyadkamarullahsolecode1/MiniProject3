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

        public async Task<IEnumerable<Workson>> GetAllWorkOn()
        {
            return await _context.Worksons.ToListAsync();
        }

        public async Task<Workson> GetWorkOnById(int empNo, int projNo)
        {
            return await _context.Worksons.FindAsync(empNo, projNo);
        }

        public async Task<Workson> AddWorkOn(Workson workson)
        {
            _context.Worksons.Add(workson);
            await _context.SaveChangesAsync();
            return workson;
        }

        public async Task<Workson> UpdateWorkOn(int empNo, int projNo, Workson workson)
        {
            _context.Worksons.Update(workson);
            await _context.SaveChangesAsync();
            return workson;
        }

        public async Task<bool> DeleteWorkOn(int empNo, int projNo)
        {
            var workson = await _context.Worksons.FindAsync(empNo, projNo);
            if (workson == null)
            {
                return false;
            }

            _context.Worksons.Remove(workson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
