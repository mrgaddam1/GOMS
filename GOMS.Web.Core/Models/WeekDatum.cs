using System;
using System.Collections.Generic;

namespace GOMS.Web.Core.Models;

public partial class WeekDatum
{
    public int WeekId { get; set; }

    public int? WeekNumber { get; set; }

    public DateTime? WeekDate { get; set; }
}
