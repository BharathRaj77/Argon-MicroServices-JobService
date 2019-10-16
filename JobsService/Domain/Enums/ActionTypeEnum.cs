using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public enum ActionTypeEnum
    {
        Approve = 1,
        Create = 2,
        Delete = 3,
        Import = 4,
        Issue = 5,
        Reject = 6,
        RequestApproval = 7,
        Update = 8,
        Rollback = 9,
        Upload = 10,
        Download = 11,
        BackendStateUpdate = 12
    }
}
