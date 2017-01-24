using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{

    public enum PartStatus
    {
        Completed, WaitAnother, Created, Running
    }
    public class PartReport
    {
        public long Count { get; set; }
        public PartStatus PartStatus { get; set; }
    }
}
