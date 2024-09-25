using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTOs.WorkbookDTOs
{
    public class UpdateWorkbookRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkbookCategoryId { get; set; }
        public string Description { get; set; }
        public string? CreateDate { get; set; }
        public string EditDate { get; set; }
        public int LevelId { get; set; }
        public string Status { get; set; }
    }
}
