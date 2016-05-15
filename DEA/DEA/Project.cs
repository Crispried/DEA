using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEA
{
    public class Project
    {
        private decimal[] EnterParameters;
        private decimal[] ExitParameters;
        private int SumRate;
        private int ProjectRate;
        public Project(decimal[] enterParameters, decimal[] exitParameters)
        {
            this.EnterParameters = enterParameters;
            this.ExitParameters = exitParameters;
        }
    }
}
