using BusinessObject.DTOs.EssayTaskDTOs;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEssayTaskService
    {
        Task<IEnumerable<EssayTask>> GetAllEssayTasksAsync(int offset, int limit, string direction, string sortBy);// <--->>
        Task<EssayTask> GetEssayTaskByIdAsync(int id);
        Task<bool> UpdateEssayTaskAsync(UpdateEssayTaskRequestDTO request);
        Task<EssayTask> AddEssayTaskAsync(AddEssayTaskRequestDTO request);
        Task<bool> DeleteEssayTaskAsync(int id);// <--->
    }
}
