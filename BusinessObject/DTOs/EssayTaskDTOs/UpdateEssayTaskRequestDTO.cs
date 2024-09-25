using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTOs.EssayTaskDTOs
{
    public class UpdateEssayTaskRequestDTO
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public int WordCountLimit { get; set; }

        public int DurationLimit { get; set; }

        public int TaskOwnerId { get; set; }

        public string UpdateDate { get; set; }

        public int WorkbookEssayTaskId { get; set; }

        public string Status { get; set; }

    }
}
