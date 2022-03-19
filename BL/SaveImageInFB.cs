using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SaveImageInFB
    {
        public SaveImageInFB()
        {
        }

        public Task Upload()
        {
            var task = DAL.SaveImageInFB.Run();
            return task;
        }

    }
    
}
