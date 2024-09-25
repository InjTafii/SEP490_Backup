using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IEssayTaskRepository
    {
        Task<EssayTask> AddEssayTask(EssayTask essayTask);
        Task<IEnumerable<EssayTask>> GetAllEssayTask(int offset, int limit, string direction, string sortBy);
        Task<EssayTask> GetEssayTaskById(int Id);
        Task<bool> UpdateEssayTask(EssayTask essayTask);
        Task<bool> DeleteEssayTask(int id);
    }
}
