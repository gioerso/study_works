using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab5_b
{
    internal class Methods
    {
        System.Timers.Timer timer = new System.Timers.Timer();

        internal void CloseDoor()
        {
            timer.Interval = 2000;
            timer.Start();


        }
        internal void OpenDoor()
        {

        }
        internal void Up()
        {

        }
        internal void Down()
        {

        }
    }
}
