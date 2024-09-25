using BusinessObject.DTOs.EssayTaskDTOs;
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
    public class EssayTaskService : IEssayTaskService
    {
        private readonly IEssayTaskRepository _EssayTaskRepository;

        public EssayTaskService(IEssayTaskRepository EssayTaskRepository)
        {
            _EssayTaskRepository = EssayTaskRepository;
        }

        public Task<EssayTask> AddEssayTaskAsync(AddEssayTaskRequestDTO request) => _EssayTaskRepository.AddEssayTask(new EssayTask
        {
            TaskName = request.TaskName,
            WordCountLimit = request.WordCountLimit,
            DurationLimit = request.DurationLimit,
            TaskOwnerId = request.TaskOwnerId,
            UpdateDate = !string.IsNullOrEmpty(request.UpdateDate)
                           ? DateOnly.ParseExact(request.UpdateDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                           : (DateOnly?)null,
            WorkbookEssayTaskId = request.WorkbookEssayTaskId,
            Status = request.Status,
        });

        public Task<bool> DeleteEssayTaskAsync(int id) => _EssayTaskRepository.DeleteEssayTask(id);

        public Task<IEnumerable<EssayTask>> GetAllEssayTasksAsync(int offset, int limit, string direction, string sortBy)
            => _EssayTaskRepository.GetAllEssayTask(offset, limit, direction, sortBy);

        public Task<EssayTask> GetEssayTaskByIdAsync(int id) => _EssayTaskRepository.GetEssayTaskById(id);

        public Task<bool> UpdateEssayTaskAsync(UpdateEssayTaskRequestDTO request) => _EssayTaskRepository.UpdateEssayTask(new EssayTask
        {
            Id = request.Id,
            TaskName = request.TaskName,
            WordCountLimit = request.WordCountLimit,
            DurationLimit = request.DurationLimit,
            TaskOwnerId = request.TaskOwnerId,
            UpdateDate = !string.IsNullOrEmpty(request.UpdateDate)
                           ? DateOnly.ParseExact(request.UpdateDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                           : (DateOnly?)null,
            WorkbookEssayTaskId = request.WorkbookEssayTaskId,
            Status = request.Status,
        });
    }
}
