using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRVTrack.Model
{
    public class HrvDataModel
    {
        public DateTime TimeStamp { get; set; }
        public double HrvValue { get; set; } // RMSSD
        public int HeartRate { get; set; } 
        public double Readiness { get; set; } // 0.00 - 100.0
        public int PhysiologicalAge { get; set; }
        public double MeanRR { get; set; } // xxx.xx (ms)

    }
}
