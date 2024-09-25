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
    public class EssayTaskRepository : IEssayTaskRepository
    {
        private readonly EssayTaskDAO _essayTaskDAO;

        public EssayTaskRepository(EssayTaskDAO essayTaskDAO)
        {
            _essayTaskDAO = essayTaskDAO;
        }

        public Task<EssayTask> AddEssayTask(EssayTask essayTask) => _essayTaskDAO.AddEssayTask(essayTask);
        public Task<bool> DeleteEssayTask(int id) => _essayTaskDAO.DeleteEssayTask(id);
        public Task<IEnumerable<EssayTask>> GetAllEssayTask(int offset, int limit, string direction, string sort) => _essayTaskDAO.GetAllAsync(offset, limit, direction, sort);
        public Task<EssayTask> GetEssayTaskById(int Id) => _essayTaskDAO.GetEssayTaskById(Id);
        public Task<bool> UpdateEssayTask(EssayTask essayTask) => _essayTaskDAO.UpdateEssayTask(essayTask);
    }
}
