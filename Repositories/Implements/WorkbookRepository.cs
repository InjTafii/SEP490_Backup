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
    public class WorkbookRepository : IWorkbookRepository
    {
        private readonly WorkbookDAO _workbookDAO;

        public WorkbookRepository(WorkbookDAO workbookDAO)
        {
            _workbookDAO = workbookDAO;
        }

        public Task<Workbook> AddWorkbook(Workbook workbook) => _workbookDAO.AddWorkbook(workbook);
        public Task<bool> DeleteWorkbook(int id) => _workbookDAO.DeleteWorkbook(id);
        public Task<IEnumerable<Workbook>> GetAllWorkbook(int offset, int limit, string direction, string sort) => _workbookDAO.GetAllAsync(offset, limit, direction, sort);
        public Task<Workbook> GetWorkbookById(int Id) => _workbookDAO.GetWorkbookById(Id);
        public Task<bool> UpdateWorkbook(Workbook workbook) => _workbookDAO.UpdateWorkbook(workbook);
    }
}
