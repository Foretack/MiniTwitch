using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTwitch.Helix.Enums;

public enum UnbanRequestStatus
{
    Unknown,
    Pending,
    Approved,
    Denied,
    Acknowledged,
    Canceled,
}
