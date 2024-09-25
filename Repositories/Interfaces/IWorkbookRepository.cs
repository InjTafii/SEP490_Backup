using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IWorkbookRepository
    {
        Task<Workbook> AddWorkbook(Workbook workbook);
        Task<IEnumerable<Workbook>> GetAllWorkbook(int offset, int limit, string direction, string sortBy);
        Task<Workbook> GetWorkbookById(int Id);
        Task<bool> UpdateWorkbook(Workbook workbook);
        Task<bool> DeleteWorkbook(int id);
    }
}
