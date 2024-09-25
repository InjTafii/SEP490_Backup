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
    public class WorkbookCategoryDAO
    {
        private readonly MyDbContext _context;

        public WorkbookCategoryDAO(MyDbContext context)
        {
            _context = context;
        }

        public async Task<WorkbookCategory> AddWorkbookCategory(WorkbookCategory workbookCategory)
        {
            try
            {
                _context.WorkbookCategories.Add(workbookCategory);
                await _context.SaveChangesAsync();
                return workbookCategory;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteWorkbookCategory(int id)
        {
            var workbookCategory = await GetWorkbookCategoryById(id);
            if (workbookCategory == null) return false;
            try
            {
                _context.WorkbookCategories.Remove(workbookCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<WorkbookCategory>> GetAllAsync(int offset, int limit, string direction, string sortBy)
        {
            if (offset < 0) offset = 0;
            if (limit <= 0) limit = 10;
            if (direction != "asc" && direction != "desc") direction = "asc";

            var query = _context.WorkbookCategories.AsQueryable();

            switch (sortBy.ToLower())
            {
                case "name":
                    query = direction == "asc" ? query.OrderBy(e => e.Name) : query.OrderByDescending(e => e.Name);
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

        public async Task<WorkbookCategory> GetWorkbookCategoryById(int workbookCategoryId)
        {
            return await _context.WorkbookCategories.FirstOrDefaultAsync(a => a.Id == workbookCategoryId);
        }


        public async Task<bool> UpdateWorkbookCategory(WorkbookCategory workbookCategory)
        {
            var originalWorkbookCategory = await GetWorkbookCategoryById(workbookCategory.Id);
            if (originalWorkbookCategory == null) return false;

            try
            {
                _context.Entry(originalWorkbookCategory).CurrentValues.SetValues(workbookCategory);

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
