using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS3
{
    public class Result
    {
        public float averageWaitingTime { get; set; }
        public float averageTurnAroundTime { get; set; }
        public int intensivity { get; set; }

        public Result(float averageWaitingTime, float averageTurnAroundTime, int intensivity)
        {
            this.averageWaitingTime = averageWaitingTime;
            this.averageTurnAroundTime = averageTurnAroundTime;
            this.intensivity = intensivity;
        }

        
    }
    internal class IntensivityComparer : IEqualityComparer<Result>
    {
        public bool Equals(Result x, Result y)
        {
            if (string.Equals((x.intensivity).ToString(), (y.intensivity).ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Result obj)
        {
            return obj.intensivity.GetHashCode();
        }
    }
    internal class TimeComparer : IEqualityComparer<Result>
    {
        public bool Equals(Result x, Result y)
        {
            if (string.Equals((x.averageWaitingTime).ToString(), (y.averageWaitingTime).ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Result obj)
        {
            return obj.averageWaitingTime.GetHashCode();
        }
    }
}
