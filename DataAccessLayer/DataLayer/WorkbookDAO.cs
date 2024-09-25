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
    public class WorkbookDAO
    {
        private readonly MyDbContext _context;

        public WorkbookDAO(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Workbook> AddWorkbook(Workbook workbook)
        {
            try
            {
                _context.Workbooks.Add(workbook);
                await _context.SaveChangesAsync();
                return workbook;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteWorkbook(int id)
        {
            var workbook = await GetWorkbookById(id);
            if (workbook == null) return false;
            try
            {
                _context.Workbooks.Remove(workbook);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Workbook>> GetAllAsync(int offset, int limit, string direction, string sortBy)
        {
            if (offset < 0) offset = 0;
            if (limit <= 0) limit = 10;
            if (direction != "asc" && direction != "desc") direction = "asc";

            var query = _context.Workbooks.AsQueryable();

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

        public async Task<Workbook> GetWorkbookById(int WorkbookId)
        {
            return await _context.Workbooks.FirstOrDefaultAsync(a => a.Id == WorkbookId);
        }


        public async Task<bool> UpdateWorkbook(Workbook workbook)
        {
            var originalWorkbook = await GetWorkbookById(workbook.Id);
            if (originalWorkbook == null) return false;

            try
            {
                _context.Entry(originalWorkbook).CurrentValues.SetValues(workbook);

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
