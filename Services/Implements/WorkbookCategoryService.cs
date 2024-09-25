using BusinessObject.DTOs.WorkbookCategoryDTOs;
using BusinessObject.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class WorkbookCategoryService : IWorkbookCategoryService
    {
        private readonly IWorkbookCategoryRepository _workbookCategoryRepository;

        public WorkbookCategoryService(IWorkbookCategoryRepository workbookCategoryRepository)
        {
            _workbookCategoryRepository = workbookCategoryRepository;
        }

        public Task<WorkbookCategory> AddWorkbookCategoryAsync(AddWorkbookCategoryRequestDTO request) => _workbookCategoryRepository.AddWorkbookCategory(new WorkbookCategory
        {
            Name = request.Name,
            TeacherId = request.TeacherId,
            CreateDate = !string.IsNullOrEmpty(request.CreateDate)
                           ? DateOnly.ParseExact(request.CreateDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                           : (DateOnly?)null,
            EditDate = !string.IsNullOrEmpty(request.EditDate)
                           ? DateOnly.ParseExact(request.EditDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                           : (DateOnly?)null,
            Description = request.Description,
            Status = request.Status,
        });

        public Task<bool> DeleteWorkbookCategoryAsync(int id) => _workbookCategoryRepository.DeleteWorkbookCategory(id);

        public Task<IEnumerable<WorkbookCategory>> GetAllWorkbookCategorysAsync(int offset, int limit, string direction, string sortBy)
            => _workbookCategoryRepository.GetAllWorkbookCategory(offset, limit, direction, sortBy);

        public Task<WorkbookCategory> GetWorkbookCategoryByIdAsync(int id) => _workbookCategoryRepository.GetWorkbookCategoryById(id);

        public Task<bool> UpdateWorkbookCategoryAsync(UpdateWorkbookCategoryRequestDTO request) => _workbookCategoryRepository.UpdateWorkbookCategory(new WorkbookCategory
        {
            Id = request.Id,
            Name = request.Name,
            TeacherId = request.TeacherId,
            CreateDate = !string.IsNullOrEmpty(request.CreateDate)
                           ? DateOnly.ParseExact(request.CreateDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                           : (DateOnly?)null,
            EditDate = !string.IsNullOrEmpty(request.EditDate)
                           ? DateOnly.ParseExact(request.EditDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                           : (DateOnly?)null,
            Description = request.Description,
            Status = request.Status,
        });
    }
}
