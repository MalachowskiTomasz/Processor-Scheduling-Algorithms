namespace ProcessorScheduling
{
    public class Process
    {
        private int pid;
        private int serviceTime;
        private int arrivedTime;
        private int runTime;
        public int lastTime = 0;
        public int averageTime = 0;

        //set values of the process when creating the process using constructor
        public Process(int serviceTime, int arrivedTime, int runTime, int pid)
        {
            this.pid = pid;
            this.serviceTime = serviceTime;
            this.arrivedTime = arrivedTime;
            this.runTime = runTime;
        }

        public int RunTime
        {
            get { return runTime; }
            set { runTime = value; }
        }

        public int ArrivedTime
        {
            get { return arrivedTime; }
            set { arrivedTime = value; }
        }

        public int ServiceTime
        {
            get { return serviceTime; }
            set { serviceTime = value; }
        }

        public int Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public bool pause()
        {
            return false;
        }

        public bool run()
        {
            return false;
        }
    }
}