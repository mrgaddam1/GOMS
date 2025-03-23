using System;
using System.Collections.Generic;

namespace GOMS.Web.Core.Models;

public partial class Expense
{
    public int ExpensesId { get; set; }

    public int? UserId { get; set; }

    public int? WeekId { get; set; }

    public int GroceryId { get; set; }

    public int StoreId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? ExpensesDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
