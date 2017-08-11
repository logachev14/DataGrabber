using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGrabber.Model
{
    interface IDataProvider
    {
        bool Init(string port, int baudRate);
        event EventHandler<Data> DataLenghtReceived;
        event EventHandler<Data> DataPeriodReceived;
    }
    public class Data : EventArgs
    {
        public int data;
    }
    

}
