using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Database.Enum
{
    public enum Status
    {
        New = 0,
        Payment = 1,
        Completed = 2,
        Canceled = -1
    }
}
