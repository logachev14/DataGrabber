using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace DataGrabber.Model
{
    class SerialPortProvider : IDataProvider
    {
        public SerialPortProvider()
        {
            _invoker = Invoke;
        }


        SerialPort _port;
        Thread _listener;
        delegate void Invoker();
        Invoker _invoker;
        public event EventHandler<Data> DataLenghtReceived;
        public event EventHandler<Data> DataPeriodReceived;

        public bool Init(string port, int baudRate)
        {
            try
            {
                _port = new SerialPort(port, baudRate);
                _port.Open();
                _listener = new Thread(Listen) { IsBackground = true };
                _listener.Start();
            }
            catch(Exception e)
            {
                Trace.WriteLine(e);
                return false;
            }
            return _port.IsOpen;
        }

        private void Listen()
        {
            while(true)
            {
                App.Current.Dispatcher.BeginInvoke(_invoker);
            }
        }
        private void Invoke()
        {

        }
    }
}
