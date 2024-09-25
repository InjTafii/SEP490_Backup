using BusinessObject.Data;
using BusinessObject.Models;
using ExceptionHandling;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataLayer
{
    public class EssayTaskDAO
    {
        private readonly MyDbContext _context;

        public EssayTaskDAO(MyDbContext context)
        {
            _context = context;
        }

        public async Task<EssayTask> AddEssayTask(EssayTask essayTask)
        {
            try
            {
                _context.EssayTasks.Add(essayTask);
                await _context.SaveChangesAsync();
                return essayTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteEssayTask(int id)
        {
            var essayTask = await GetEssayTaskById(id);
            if (essayTask == null) return false;
            try
            {
                _context.EssayTasks.Remove(essayTask);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<EssayTask>> GetAllAsync(int offset, int limit, string direction, string sortBy)
        {
            if (offset < 0) offset = 0;
            if (limit <= 0) limit = 10;
            if (direction != "asc" && direction != "desc") direction = "asc";

            var query = _context.EssayTasks.AsQueryable();

            switch (sortBy.ToLower())
            {
                case "name":
                    query = direction == "asc" ? query.OrderBy(e => e.TaskName) : query.OrderByDescending(e => e.TaskName);
                    break;
                case "id":
                    query = direction == "asc" ? query.OrderBy(e => e.Id) : query.OrderByDescending(e => e.Id);
                    break;
                default:
                    throw new CustomException(HttpStatusCode.BadRequest, "Invalid sortBy parameter.", "Invalid sortBy parameter.", null);
            }


            query = query.Skip(offset).Take(limit);

            return await query.ToListAsync();

            //return await _myDbContext.CommonMistakeCategories.ToListAsync();
        }

        public async Task<EssayTask> GetEssayTaskById(int essayTaskId)
        {
            return await _context.EssayTasks.FirstOrDefaultAsync(a => a.Id == essayTaskId);
        }


        public async Task<bool> UpdateEssayTask(EssayTask essayTask)
        {
            var originalEssayTask = await GetEssayTaskById(essayTask.Id);
            if (originalEssayTask == null) return false;

            try
            {
                _context.Entry(originalEssayTask).CurrentValues.SetValues(essayTask);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
