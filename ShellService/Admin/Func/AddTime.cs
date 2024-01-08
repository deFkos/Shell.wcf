using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ShellService.Admin.Func
{
    public class AddTime
    {
        public DateTime CurrentTime { get; set; }
        public int id { get; set; }
        public Dictionary<DateTime, DateTime> TimeRanges { get; set; }
        public static List<AddTime> addTimes { get; set; } = new List<AddTime>();
        public OperationContext OperationContext { get; internal set; }
    }
}
