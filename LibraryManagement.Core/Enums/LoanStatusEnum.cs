using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Enums
{
    public enum LoanStatusEnum
    {
        Activity = 0,
        Delivered = 1,
        DeliveredWithCharge = 2,
        Deleted = 3
    }
}
