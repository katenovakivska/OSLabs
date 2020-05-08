using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OS3
{
    public partial class Charts : Form
    {
        public Charts()
        {
            InitializeComponent();
            FillChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            //FillChart();
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            //FillChart();
        }


        public void FillChart()
        {
            var roundRobin = new RoundRobin();
            Random rand = new Random();
            var list = new List<Result>();
            var list1 = new List<Result>();
            int quantum = 3;
            for (int i = 0; i < 32; i++)
            {
                var processCount = rand.Next(1,10);
                int[] processes = new int[processCount];
                for (int j = 0; j < processes.Length; j++)
                {
                    processes[j] = j + 1;
                }

                int[] burstTime = new int[processCount];
                for (int j = 0; j < burstTime.Length; j++)
                {
                    burstTime[j] = rand.Next(1,10);
                }

                var results = roundRobin.FindAverageTime(processes, processCount, burstTime, quantum);
                var element = new Result(results[0], results[1], processCount);
                list.Add(element);
                
            }
            var query = list.Distinct(new IntensivityComparer()).OrderBy(x => x.intensivity);
            chart1.Titles.Add("Average waiting to intensivity");
            chart1.Series["Waiting"].ChartType = SeriesChartType.Spline;
            chart2.Titles.Add("Intensivity to procent of lay-up");
            chart2.Series["Intensivity"].ChartType = SeriesChartType.Spline;
            chart3.Titles.Add("Tasks to average time in turn");
            chart3.Series["Procent"].ChartType = SeriesChartType.Spline;
            var query1 = list.Distinct(new TimeComparer()).OrderBy(x => x.averageWaitingTime);

            foreach (var el in query)
            {
                chart1.Series["Waiting"].Points.AddXY(100/el.intensivity, Math.Round(el.averageWaitingTime, 2));
                chart2.Series["Intensivity"].Points.AddXY(100/el.intensivity, (el.intensivity-quantum)*100/quantum);
                chart3.Series["Procent"].Points.AddXY((el.intensivity - quantum), Math.Round(el.averageWaitingTime, 2));
            }

        }

    }
}
