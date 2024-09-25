using BusinessObject.DTOs.WorkbookCategoryDTOs;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IWorkbookCategoryService
    {
        Task<IEnumerable<WorkbookCategory>> GetAllWorkbookCategorysAsync(int offset, int limit, string direction, string sortBy);// <--->>
        Task<WorkbookCategory> GetWorkbookCategoryByIdAsync(int id);
        Task<bool> UpdateWorkbookCategoryAsync(UpdateWorkbookCategoryRequestDTO request);
        Task<WorkbookCategory> AddWorkbookCategoryAsync(AddWorkbookCategoryRequestDTO request);
        Task<bool> DeleteWorkbookCategoryAsync(int id);// <--->
    }
}
