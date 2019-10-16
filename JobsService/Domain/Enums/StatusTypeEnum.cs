using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public enum StatusTypeEnum
    {
        NEW = 1,
        DRAFT = 2,
        APPROVED = 3,
        SUBMITTED = 4,
        REJECTED = 5,
        ISSUED = 6,
        IMPORTED = 7,
        PREPARING_TO_ISSUE = 8,
        ARGON_PROCESSING_FAILED = 9,
        DELETED = 10,
        EXPIRED = 11,
        SUPERSEDED = 12
    }
}
