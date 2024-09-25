using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IWorkbookCategoryRepository
    {
        Task<WorkbookCategory> AddWorkbookCategory(WorkbookCategory workbookCategory);
        Task<IEnumerable<WorkbookCategory>> GetAllWorkbookCategory(int offset, int limit, string direction, string sortBy);
        Task<WorkbookCategory> GetWorkbookCategoryById(int Id);
        Task<bool> UpdateWorkbookCategory(WorkbookCategory workbookCategory);
        Task<bool> DeleteWorkbookCategory(int id);
    }
}
