using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalonManagementSystem.Model;
namespace BeautySalonManagementSystem.Controller
{
    public class LoadController
    {
        private LoadModel model;

        public LoadController()
        {
            model = new LoadModel();
        }

        public int GetProgress()
        {
            return model.ProgressValue;
        }

        public void UpdateProgress()
        {
            model.IncrementProgress();
        }

        public bool IsLoadingComplete()
        {
            return model.IsCompleted;
        }
    }
}
