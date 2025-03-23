using System;
using System.Collections.Generic;

namespace GOMS.Web.Core.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string StoreName { get; set; } = null!;
}
