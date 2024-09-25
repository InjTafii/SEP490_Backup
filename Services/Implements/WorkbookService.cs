using BusinessObject.DTOs.WorkbookDTOs;
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
    public class WorkbookService : IWorkbookService
    {
        private readonly IWorkbookRepository _workbookRepository;
        
        public WorkbookService(IWorkbookRepository workbookRepository)
        {
            _workbookRepository = workbookRepository;
        }

        public Task<Workbook> AddWorkbookAsync(AddWorkbookRequestDTO request) => _workbookRepository.AddWorkbook(new Workbook
        {
            Name = request.Name,
            WorkbookCategoryId = request.WorkbookCategoryId,
            LevelId = request.LevelId,
            CreateDate = !string.IsNullOrEmpty(request.EditDate)
                           ? DateOnly.ParseExact(request.EditDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                           : (DateOnly?)null,
            EditDate = !string.IsNullOrEmpty(request.EditDate)
                           ? DateOnly.ParseExact(request.EditDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                           : (DateOnly?)null,
            Description = request.Description,
            Status = request.Status,
        });

        public Task<bool> DeleteWorkbookAsync(int id) => _workbookRepository.DeleteWorkbook(id);

        public Task<IEnumerable<Workbook>> GetAllWorkbooksAsync(int offset, int limit, string direction, string sortBy)
            => _workbookRepository.GetAllWorkbook(offset, limit, direction, sortBy);

        public Task<Workbook> GetWorkbookByIdAsync(int id) => _workbookRepository.GetWorkbookById(id);

        public Task<bool> UpdateWorkbookAsync(UpdateWorkbookRequestDTO request) => _workbookRepository.UpdateWorkbook(new Workbook
        {
            Id = request.Id,
            Name = request.Name,
            WorkbookCategoryId = request.WorkbookCategoryId,
            LevelId = request.LevelId,
            CreateDate = !string.IsNullOrEmpty(request.EditDate)
                           ? DateOnly.ParseExact(request.EditDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                           : (DateOnly?)null,
            EditDate = !string.IsNullOrEmpty(request.EditDate)
                           ? DateOnly.ParseExact(request.EditDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                           : (DateOnly?)null,
            Description = request.Description,
            Status = request.Status,
        });
    }
}
