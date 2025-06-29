using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonManagementSystem.Model
{
    public class LoadModel
    {
        public int ProgressValue { get; set; } = 0;
        public int Step { get; set; } = 10;

        public bool IsCompleted => ProgressValue >= 100;

        public void IncrementProgress()
        {
            if (ProgressValue < 100)
            {
                ProgressValue += Step;
            }
        }
    }
}
