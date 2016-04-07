using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrukcjeProdukcyjne
{
    interface IMediaViewer
    {
        void Start(string fileName);
        void Pause(bool value);
        void Stop();
        bool IsPause();
    }
}
