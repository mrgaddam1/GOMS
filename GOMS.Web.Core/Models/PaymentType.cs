using System;
using System.Collections.Generic;

namespace GOMS.Web.Core.Models;

public partial class PaymentType
{
    public int PaymentTypeId { get; set; }

    public string PaymentTypeDescription { get; set; } = null!;
}
