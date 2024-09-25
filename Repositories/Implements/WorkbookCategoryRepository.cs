using BusinessObject.Models;
using DataAccessLayer.DataLayer;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class WorkbookCategoryRepository : IWorkbookCategoryRepository
    {
        private readonly WorkbookCategoryDAO _workbookCategoryDAO;

        public WorkbookCategoryRepository(WorkbookCategoryDAO workbookCategoryDAO)
        {
            _workbookCategoryDAO = workbookCategoryDAO;
        }

        public Task<WorkbookCategory> AddWorkbookCategory(WorkbookCategory workbookCategory) => _workbookCategoryDAO.AddWorkbookCategory(workbookCategory);
        public Task<bool> DeleteWorkbookCategory(int id) => _workbookCategoryDAO.DeleteWorkbookCategory(id);
        public Task<IEnumerable<WorkbookCategory>> GetAllWorkbookCategory(int offset, int limit, string direction, string sort) => _workbookCategoryDAO.GetAllAsync(offset, limit, direction, sort);
        public Task<WorkbookCategory> GetWorkbookCategoryById(int Id) => _workbookCategoryDAO.GetWorkbookCategoryById(Id);
        public Task<bool> UpdateWorkbookCategory(WorkbookCategory workbookCategory) => _workbookCategoryDAO.UpdateWorkbookCategory(workbookCategory);
    }
}
