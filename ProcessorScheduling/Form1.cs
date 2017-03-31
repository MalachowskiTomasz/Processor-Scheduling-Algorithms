using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProcessorScheduling
{
    public partial class Form1 : MetroForm
    {
        private ReadyQueue readyQueue;
        private List<Process> processList;
        private List<Label> jobRemaining = new List<Label>();
        private List<Label> jobWaiting = new List<Label>();
        private List<ProgressBar> jobProgressBar = new List<ProgressBar>();

        private Process currentlyRunning;
        private int clockInterval;
        private int time;
        private System.Windows.Forms.Timer timer;
        private Boolean isTimerPause;
        private Boolean isRunForOneTriger;
        private int timeSlice;
        private int averageTime;

        public Form1()
        {
            InitializeComponent();
            readyQueueText.Text = "";
            algoComboBox.SelectedIndex = 0;
            btnPlay.Enabled = false;
            readyQueue = new ReadyQueue();

            processList = new List<Process>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void loadingComponents()
        {
            processTable.Rows.Clear();

            int c = 0;
            foreach (Process i in processList)
            {
                waitingTime.Add(0);
                c += i.ServiceTime;
            }
            chart1.ChartAreas[0].AxisY.Maximum = c;
            chart1.ChartAreas[0].AxisX.Minimum = -1;
            chart1.ChartAreas[0].AxisX.Maximum = processList.Count;

            currentlyRunning = null;

            for (int i = 0; i < processList.Count; i++)
            {
                String[] rowDetail = { "Process " + processList[i].Pid.ToString(), processList[i].ArrivedTime.ToString(), processList[i].ServiceTime.ToString() };
                processTable.Rows.Add(rowDetail);
            }

            timer = new System.Windows.Forms.Timer();
            time = 0;
            isTimerPause = false;
            isRunForOneTriger = false;

            timeSpinner.Value = 0;
            label30.Text = "\n 0%";

            int k = 0;
            foreach (Process p in processList)
            {
                ProgressBar a = new ProgressBar();
                a.Size = new Size(237, 30);
                //Roznica = 36
                a.Location = new Point(65, 44 + k * 36);
                panel1.Controls.Add(a);
                jobProgressBar.Add(a);

                Label l = new Label();
                l.AutoSize = true;
                l.Font = new Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                l.ForeColor = Color.White;
                l.Location = new Point(12, 50 + k * 36);
                l.Text = "P" + k;
                panel1.Controls.Add(l);

                Label t = new Label();
                t.AutoSize = true;
                t.Text = "0";
                t.Font = new Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                t.ForeColor = Color.White;
                t.Location = new Point(339, 56 + k * 36);
                t.Size = new Size(0, 13);
                jobRemaining.Add(t);
                panel1.Controls.Add(t);

                Label o = new Label();
                o.AutoSize = true;
                o.Text = "0";
                o.Font = new Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                o.ForeColor = Color.White;
                o.Location = new Point(475, 56 + k++ * 36);
                o.Size = new Size(0, 13);
                jobWaiting.Add(o);
                panel1.Controls.Add(o);
            }
            for (int i = 0; i < processList.Count; i++)
                waitingTimeDone.Add(false);
        }

        private void loadingProcessesFromFile(int pid, int serviceTime, int arrivalTime)
        {
            OpenFileDialog t = new OpenFileDialog();
            t.ShowDialog();
            t.Multiselect = false;
            try
            {
                if (t.OpenFile() != null)
                {
                    string[] s = File.ReadAllLines(t.FileName);
                    foreach (var item in s)
                    {
                        if (item.StartsWith("#"))
                            continue;
                        var x = item.Split(' ');
                        Process i = new Process(Int32.Parse(x[serviceTime]), Int32.Parse(x[arrivalTime]), 0, Int32.Parse(x[pid]));
                        processList.Add(i);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Couldn't read file from disk");
                //wczytywanieProcesow(pid, serviceTime, arrivalTime);
            }

            isDone = true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //string selectedAlgo = algoComboBox.GetItemText(algoComboBox.SelectedItem);
            clockInterval = Int32.Parse(speedText.Text);

            start_timer(algoComboBox.SelectedIndex);
        }

        public void start_timer(int selectedAlgo)
        {
            averageTime = 0;
            foreach(Process i in processList)
            {
                i.lastTime = 0;
                i.averageTime = 0;
            }
            //check if pause button has clicked before
            if (isTimerPause)
            {
                timer.Enabled = true;
            }
            else
            {
                reset();
                //when timer trigging relavant method is called
                if (selectedAlgo == 1)
                {
                    timer.Tick += new EventHandler(timer_Tick_FCFS);
                }
                else if (selectedAlgo == 5)
                {
                    roundrobin = true;
                    timeSlice = Int32.Parse(timeSliceText.Text);
                    timer.Tick += new EventHandler(timer_Tick_RoundRobin);
                }
                else if (selectedAlgo == 2)
                {
                    timer.Tick += new EventHandler(timer_Tick_SPN);
                }
                else if (selectedAlgo == 3)
                {
                    timeSlice = Int32.Parse(timeSliceText.Text);
                    timer.Tick += new EventHandler(timer_Tick_SRT);
                }
                else if (selectedAlgo == 4)
                {
                    timer.Tick += new EventHandler(timer_Tick_HRRN);
                }
                //set timer interval, enable timer and start timer
                timer.Interval = clockInterval;
                timer.Enabled = true;
                timer.Start();
            }
        }

        public void timer_Tick_FCFS(object sender, EventArgs e)
        {
            readyQueueText.Text = " ";
            timeText.Text = (time + 1).ToString();

            //add process to ready queue if arrival time is equal to current time
            for (int k = 0; k < processList.Count; k++)
            {
                if (processList[k].ArrivedTime == time)
                {
                    readyQueue.Ready_Queue.Enqueue(processList[k]);
                }
            }

            //if time=0 start with the first process in the queue
            if (time == 0)
            {
                currentlyRunning = readyQueue.firstComeFirstServe();
            }

            //if the service time of a process equal to run time, then get the next in the queuek
            if (currentlyRunning.ServiceTime == currentlyRunning.RunTime)
            {
                currentlyRunning = readyQueue.firstComeFirstServe();
            }

            showReadyQueue();
            currentlyRunning.RunTime += 1;

            showProcessTimeline();

            //display the process id of the currently running pricess of the cpu
            processInCPU.Text = currentlyRunning.Pid.ToString();
            int alltime = 0;
            int runtimes = 0;
            foreach (Process i in processList)
            {
                alltime += i.ServiceTime;
                runtimes += i.RunTime;
            }

            time++;

            //display time spinner value
            timeSpinner.Value = (int)(((double)runtimes / alltime) * 100);

            label30.Text = "Timer\n" + timeSpinner.Value + "%";

            //stop timer after all processes are executed

            if (time == alltime)
            {
                timeSpinner.Value = 100;
                label30.Text = "Timer\n" + timeSpinner.Value + "%";
                timer.Stop();
                btnNext.Enabled = false;
                btnPause.Enabled = false;
                MessageBox.Show("Average waiting time: " + ((double)averageTime / processList.Count));
                //btnStop.Enabled = false;
            }

            //check if this method executed when step next button clicked
            //then timer should be disabled as this should run step by step
            if (isRunForOneTriger)
            {
                isRunForOneTriger = false;
                timer.Enabled = false;
            }
        }

        private List<int> waitingTime = new List<int>();

        public void timer_Tick_RoundRobin(object sender, EventArgs e)
        {
            readyQueueText.Text = " ";
            timeText.Text = (time + 1).ToString();

            //add process to ready queue if arrival time is equal to current time
            for (int k = 0; k < processList.Count; k++)
            {
                if (processList[k].ArrivedTime == time)
                {
                    readyQueue.Ready_Queue.Enqueue(processList[k]);
                }
            }

            //if time=0 start with the first process in the queue
            if (time == 0)
            {
                currentlyRunning = readyQueue.roundRobin(null, true);
            }
            //if the service time of a process equal to run time, then get the next in the queue
            if (currentlyRunning.ServiceTime == currentlyRunning.RunTime)
            {
                //averageTime += (time - currentlyRunning.ServiceTime);
                //currentlyRunning.lastTime = time;
                currentlyRunning = readyQueue.roundRobin(null, true);
                timeSlice = Int32.Parse(timeSliceText.Text);
                //MessageBox.Show(averageTime.ToString());
            }
            else if (timeSlice == 0)
            {
                currentlyRunning.lastTime = time;
                currentlyRunning = readyQueue.roundRobin(currentlyRunning, false);
                currentlyRunning.averageTime += (time - currentlyRunning.lastTime);
                timeSlice = Int32.Parse(timeSliceText.Text);
            }

            showReadyQueue();

            currentlyRunning.RunTime += 1;

            showProcessTimeline();

            //display the process id of the currently running pricess of the cpu
            processInCPU.Text = currentlyRunning.Pid.ToString();

            timeSlice--;

            int alltime = 0;
            foreach (Process i in processList)
                alltime += i.ServiceTime;

            time++;

            //display time spinner value
            timeSpinner.Value += (100 / alltime);
            label30.Text = "Timer\n" + timeSpinner.Value + "%";

            //stop timer after all processes are executed

            if (time == alltime)
            {
                timeSpinner.Value = 100;
                label30.Text = "Timer\n" + timeSpinner.Value + "%";
                timer.Stop();

                int avgTime = 0;
                foreach (var item in processList)
                {
                    avgTime += item.averageTime;
                }
                MessageBox.Show("Average waiting time: " + (int)(((double)avgTime+averageTime) / processList.Count), "Result");
                btnNext.Enabled = false;
                btnPause.Enabled = false;
                //btnStop.Enabled = false;
            }

            //check if this method executed when step next button clicked
            //then timer should be disabled as this should run step by step
            if (isRunForOneTriger)
            {
                isRunForOneTriger = false;
                timer.Enabled = false;
            }
        }

        public void timer_Tick_SPN(object sender, EventArgs e)
        {
            readyQueueText.Text = " ";
            timeText.Text = (time + 1).ToString();

            //add process to ready queue if arrival time is equal to current time
            for (int k = 0; k < processList.Count; k++)
            {
                if (processList[k].ArrivedTime == time)
                {
                    readyQueue.Ready_Queue.Enqueue(processList[k]);
                }
            }

            //if time=0 start with the first process in the queue
            if (time == 0)
            {
                currentlyRunning = readyQueue.SPN();
            }

            //if the service time of a process equal to run time, then get the next in the queue
            if (currentlyRunning.ServiceTime == currentlyRunning.RunTime)
            {
                currentlyRunning = readyQueue.SPN();
            }

            showReadyQueue();

            currentlyRunning.RunTime += 1;

            showProcessTimeline();

            //display the process id of the currently running pricess of the cpu
            processInCPU.Text = currentlyRunning.Pid.ToString();

            int alltime = 0;
            foreach (Process i in processList)
            {
                alltime += i.ServiceTime;
            }
            time++;

            //display time spinner value
            timeSpinner.Value += (100 / alltime);
            label30.Text = "Timer\n" + timeSpinner.Value + "%";

            //stop timer after all processes are executed

            if (time == alltime)
            {
                timeSpinner.Value = 100;
                label30.Text = "Timer\n" + timeSpinner.Value + "%";
                timer.Stop();
                MessageBox.Show("Average waiting time: " + ((double)averageTime / processList.Count)); btnNext.Enabled = false;
                btnPause.Enabled = false;
                //btnStop.Enabled = false;
            }

            //check if this method executed when step next button clicked
            //then timer should be disabled as this should run step by step
            if (isRunForOneTriger)
            {
                isRunForOneTriger = false;
                timer.Enabled = false;
            }
        }

        public void timer_Tick_SRT(object sender, EventArgs e)
        {
            readyQueueText.Text = " ";
            timeText.Text = (time + 1).ToString();

            //add process to ready queue if arrival time is equal to current time
            for (int k = 0; k < processList.Count; k++)
            {
                if (processList[k].ArrivedTime == time)
                {
                    readyQueue.Ready_Queue.Enqueue(processList[k]);
                }
            }

            //if time=0 start with the first process in the queue
            if (time == 0)
            {
                currentlyRunning = readyQueue.SRN(null);
            }
            //if the service time of a process equal to run time, then get the next in the queue
            else if (currentlyRunning.ServiceTime == currentlyRunning.RunTime)
            {
                currentlyRunning = readyQueue.SRN(null);
                currentlyRunning.averageTime += (time - currentlyRunning.lastTime);
                timeSlice = Int32.Parse(timeSliceText.Text);
            }
            else if (timeSlice == 0)
            {
                currentlyRunning.lastTime = time;
                if (currentlyRunning.ServiceTime == currentlyRunning.RunTime)
                {
                    currentlyRunning = readyQueue.SRN(null);
                    
                }
                else
                {
                    currentlyRunning = readyQueue.SRN(currentlyRunning);
                }
                currentlyRunning.averageTime += (time - currentlyRunning.lastTime);
                timeSlice = Int32.Parse(timeSliceText.Text);
            }

            showReadyQueue();

            currentlyRunning.RunTime += 1;

            showProcessTimeline();

            //display the process id of the currently running pricess of the cpu
            processInCPU.Text = currentlyRunning.Pid.ToString();

            timeSlice--;

            int avgtime = 0;
            int alltime = 0;
            foreach (Process i in processList)
            {
                alltime += i.ServiceTime;
                avgtime += i.averageTime;
            }
            time++;

            //display time spinner value
            timeSpinner.Value += (100 / alltime);
            label30.Text = "Timer\n" + timeSpinner.Value + "%";

            //stop timer after all processes are executed

            if (time == alltime)
            {
                timeSpinner.Value = 100;
                label30.Text = "Timer\n" + timeSpinner.Value + "%";
                timer.Stop();
                MessageBox.Show("Average waiting time: " + (((double)averageTime+avgtime) / (2*processList.Count))); btnNext.Enabled = false;
                btnPause.Enabled = false;
                //btnStop.Enabled = false;
            }

            //check if this method executed when step next button clicked
            //then timer should be disabled as this should run step by step
            if (isRunForOneTriger)
            {
                isRunForOneTriger = false;
                timer.Enabled = false;
            }
        }

        public void timer_Tick_HRRN(object sender, EventArgs e)
        {
            readyQueueText.Text = " ";
            timeText.Text = (time + 1).ToString();

            //add process to ready queue if arrival time is equal to current time
            for (int k = 0; k < processList.Count; k++)
            {
                if (processList[k].ArrivedTime == time)
                {
                    readyQueue.Ready_Queue.Enqueue(processList[k]);
                }
            }

            //if time=0 start with the first process in the queue
            if (time == 0)
            {
                currentlyRunning = readyQueue.HRRN(time);
            }
            //if the service time of a process equal to run time, then get the next in the queue
            else if (currentlyRunning.ServiceTime == currentlyRunning.RunTime)
            {
                currentlyRunning = readyQueue.HRRN(time);
            }

            showReadyQueue();

            currentlyRunning.RunTime += 1;

            showProcessTimeline();

            //display the process id of the currently running pricess of the cpu
            processInCPU.Text = currentlyRunning.Pid.ToString();

            int alltime = 0;
            foreach (Process i in processList)
                alltime += i.ServiceTime;

            time++;

            //display time spinner value
            timeSpinner.Value += (100 / alltime);
            label30.Text = "Timer\n" + timeSpinner.Value + "%";

            //stop timer after all processes are executed

            if (time == alltime)
            {
                timeSpinner.Value = 100;
                label30.Text = "Timer\n" + timeSpinner.Value + "%";
                timer.Stop();
                MessageBox.Show("Average waiting time: " + ((double)averageTime / processList.Count)); btnNext.Enabled = false;
                btnPause.Enabled = false;
                //btnStop.Enabled = false;
            }

            //check if this method executed when step next button clicked
            //then timer should be disabled as this should run step by step
            if (isRunForOneTriger)
            {
                isRunForOneTriger = false;
                timer.Enabled = false;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            isTimerPause = true;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (isTimerPause)
            {
                timer.Enabled = true;
                isRunForOneTriger = true;
            }
            //timer.Enabled = false;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            reset();
        }

        //reset programme to initial conditions
        public void reset()
        {
            timeSpinner.Value = 0;
            timer.Stop();
            averageTime = 0;
            //readyQueue = new ReadyQueue();

            currentlyRunning = null;

            timer = new System.Windows.Forms.Timer();
            time = 0;
            isTimerPause = false;
            isRunForOneTriger = false;

            foreach (ProgressBar s in jobProgressBar)
                s.Value = 0;

            chart1.Series[0].Points.Clear();

            label30.Text = "Timer";

            readyQueue.Ready_Queue = new Queue<Process>();
            foreach (Process i in processList)
                i.RunTime = 0;
            for (int i = 0; i < waitingTimeDone.Count; i++)
                waitingTimeDone[i] = false;
        }

        //play button click event
        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            if (speedText.Text == "" || System.Text.RegularExpressions.Regex.IsMatch(speedText.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid value for Simulation Timer Interval.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //string selectedAlgo = algoComboBox.GetItemText(algoComboBox.SelectedItem);
                clockInterval = Int32.Parse(speedText.Text);

                if ((algoComboBox.SelectedIndex == 3 || algoComboBox.SelectedIndex == 5) && (timeSliceText.Text == "" || System.Text.RegularExpressions.Regex.IsMatch(timeSliceText.Text, "[^0-9]")))
                {
                    MessageBox.Show("Please enter valid value for Quantum Time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    start_timer(algoComboBox.SelectedIndex);

                    btnPause.Enabled = true;
                    btnNext.Enabled = true;
                    btnStop.Enabled = true;
                    btnPlay.Enabled = false;
                }
            }
            algoComboBox.Enabled = false;
        }

        //pause button button click event
        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            btnPlay.Enabled = true;
            timer.Enabled = false;
            isTimerPause = true;
        }

        //step next button click event
        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            if (isTimerPause)
            {
                btnPlay.Enabled = true;
                timer.Enabled = true;
                isRunForOneTriger = true;
            }
        }

        //stop button click event
        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            reset();
            roundrobin = false;
            btnNext.Enabled = false;
            btnPause.Enabled = false;
            btnPlay.Enabled = true;

            algoComboBox.Enabled = true;

            processInCPU.Text = "";
            timeText.Text = "";
            readyQueueText.Text = "";

            foreach (Label i in jobWaiting)
                i.Text = "";
            foreach (Label i in jobRemaining)
                i.Text = "";
        }

        private bool isDone = false;

        private void algoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (algoComboBox.SelectedIndex == 1)
            {
                lblTopic.Text = "First Come First Serve (FCFS)";
                lblDescription.Text = "Processes are dispatched according to their arrival time on the ready queue.";
                lblType.Text = "Non-Preemptive";
                btnPlay.Enabled = true;
                btnBanner.Visible = false;
            }
            else if (algoComboBox.SelectedIndex == 2)
            {
                lblTopic.Text = "Shortest Process Next (SPN)";
                lblDescription.Text = "The process with the shortest expected processing time is selected next.";
                lblType.Text = "Non-Preemptive";
                btnPlay.Enabled = true;
                btnBanner.Visible = false;
            }
            else if (algoComboBox.SelectedIndex == 3)
            {
                lblTopic.Text = "Shortest Remaining Time (SRT)";
                lblDescription.Text = "Chooses the process that has the shortest expected remaining processing time.";
                lblType.Text = "Preemptive";
                btnPlay.Enabled = true;
                btnBanner.Visible = false;
            }
            else if (algoComboBox.SelectedIndex == 4)
            {
                lblTopic.Text = "Highest Response Ratio Next";
                lblDescription.Text = "Chooses next process with the greatest response ratio. It accounts for the age of the process.";
                lblType.Text = "Non-Preemptive";
                btnPlay.Enabled = true;
                btnBanner.Visible = false;
            }
            else if (algoComboBox.SelectedIndex == 5)
            {
                lblTopic.Text = "Round Robin (RR)";
                lblDescription.Text = "Each process is given a slice of time before being pre-empted.";
                lblType.Text = "Preemptive";
                btnPlay.Enabled = true;
                btnBanner.Visible = false;
            }
            else if (algoComboBox.SelectedIndex == 0)
            {
                btnPlay.Enabled = false;
                btnBanner.Visible = true;
            }
            //if (isDone)
            //    foreach (Process i in processList)
            //        //i.burstTime = 0;
        }

        //show the process in the ready queue at current time
        private void showReadyQueue()
        {
            for (int i = 0; i < readyQueue.Ready_Queue.Count; i++)
            {
                if (readyQueue.Ready_Queue.Count == 1)
                {
                    readyQueueText.Text += "Process " + readyQueue.Ready_Queue.ElementAt(i).Pid;
                }
                else
                {
                    if (i == readyQueue.Ready_Queue.Count - 1)
                    {
                        readyQueueText.Text += "Process " + readyQueue.Ready_Queue.ElementAt(i).Pid;
                    }
                    else
                    {
                        readyQueueText.Text += "Process " + readyQueue.Ready_Queue.ElementAt(i).Pid + " | ";
                    }
                }
            }
        }

        //display value for the Remaining Time, Witing Time, Progress Bar.
        //color relavant boxes in display panel (timeline)
        private List<bool> waitingTimeDone = new List<bool>();

        private bool roundrobin = false;

        private void showProcessTimeline()
        {
            int a = processList.IndexOf(currentlyRunning);
            jobRemaining.ElementAt(a).Text = (currentlyRunning.ServiceTime - currentlyRunning.RunTime).ToString();
            if (!waitingTimeDone[a])
            {
                averageTime += time - currentlyRunning.ArrivedTime;
                jobWaiting.ElementAt(a).Text = (time - currentlyRunning.ArrivedTime).ToString();
                waitingTimeDone[a] = true;
            }

            jobProgressBar.ElementAt(a).Value = (int)(((double)currentlyRunning.RunTime / currentlyRunning.ServiceTime) * 100);
            if (currentlyRunning.ServiceTime == currentlyRunning.RunTime)
                jobProgressBar.ElementAt(a).Value = 100;

            //adding points to chart
            System.Windows.Forms.DataVisualization.Charting.DataPoint punkt = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
            punkt.XValue = a;
            punkt.YValues = new double[2];
            punkt.YValues[0] = time;
            punkt.YValues[1] = time + 1;

            chart1.Series[0].Points.Add(punkt);
            chart1.Refresh();
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void processTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int a = processTable.CurrentRow.Index;
            if (a < processList.Count)
            {
                processList[a].ArrivedTime = Int32.Parse(processTable.CurrentRow.Cells[1].Value.ToString());
                processList[a].ServiceTime = Int32.Parse(processTable.CurrentRow.Cells[2].Value.ToString());
                int c = 0;
                foreach (Process i in processList)
                    c += i.ServiceTime;
                chart1.ChartAreas[0].AxisY.Maximum = c;
            }
            /*else
            {
                if(processTable.CurrentRow.Cells[0].Value != null  && processTable.CurrentRow.Cells[1].Value != null && processTable.CurrentRow.Cells[2].Value != null)
                {
                    processList.Add(new Process(Int32.Parse(processTable.CurrentRow.Cells[2].Value.ToString()), Int32.Parse(processTable.CurrentRow.Cells[1].Value.ToString()), 0, Int32.Parse(processTable.CurrentRow.Cells[0].Value.ToString().Split(' ')[1])));
                    ladowanie();
                }
            }*/
        }

        private Form2 t = new Form2();
        private int[] processInformationOrder;

        private void loadButton_Click(object sender, EventArgs e)
        {
            processList.Clear();
            if (processInformationOrder != null)
            {
                loadingProcessesFromFile(processInformationOrder[0], processInformationOrder[1], processInformationOrder[2]);
                loadingComponents();
            }
            else
            {
                t.Show();
                t.button1.Click += new EventHandler(skopiujZBuforaEkranu);
            }
        }

        private void skopiujZBuforaEkranu(object sender, EventArgs e)
        {
            processInformationOrder = t.value;
            loadingProcessesFromFile(t.value[0], t.value[1], t.value[2]);
            t.Close();
            loadingComponents();
        }
    }
}