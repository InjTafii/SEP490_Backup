using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class StudentNoteBook
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int WorkingSpaceId { get; set; }

    public int? WorkbookId { get; set; }

    public virtual WorkingSpace WorkingSpace { get; set; } = null!;
}
