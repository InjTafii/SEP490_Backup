using BusinessObject.DTOs.WorkbookDTOs;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IWorkbookService
    {
        Task<IEnumerable<Workbook>> GetAllWorkbooksAsync(int offset, int limit, string direction, string sortBy);// <--->>
        Task<Workbook> GetWorkbookByIdAsync(int id);
        Task<bool> UpdateWorkbookAsync(UpdateWorkbookRequestDTO request);
        Task<Workbook> AddWorkbookAsync(AddWorkbookRequestDTO request);
        Task<bool> DeleteWorkbookAsync(int id);// <--->
    }
}
