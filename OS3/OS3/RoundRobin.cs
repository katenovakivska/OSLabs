using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS3
{
    public class RoundRobin
    {
        // знаходження часу очікування
        static void FindWaitingTime(int[] processes, int n, int[] bt, int[] wt, int quantum)
        {
            // час виконання завдання
            int[] rem_bt = new int[n];

            for (int i = 0; i < n; i++)
                rem_bt[i] = bt[i];

            int t = 0; // поточний час 

            // поки всі завдання не виконані
            while (true)
            {
                bool done = true;

                // прохід всіх процесів в потоці
                for (int i = 0; i < n; i++)
                {
                    if (rem_bt[i] > 0)
                    {
                        //процес в очікуванні
                        done = false;

                        if (rem_bt[i] > quantum)
                        {
                            // збільшення часу
                            t += quantum;

                            // зменшення критичного часу 
                            rem_bt[i] -= quantum;
                        }
                        else
                        {

                            // час, за який виконується процес
                            t = t + rem_bt[i];

                            // час очікування є меншим на час виконання
                            wt[i] = t - bt[i];

                            // час, що лишився
                            rem_bt[i] = 0;
                        }
                    }
                }

                // всі процеси виконані 
                if (done == true)
                    break;
            }
        }

        // обрахування часу в черзі 
        static void FindTurnAroundTime(int[] processes, int n, int[] bt, int[] wt, int[] tat)
        {
            for (int i = 0; i < n; i++)
                tat[i] = bt[i] + wt[i];
        }

        // обрахування середнього часу
        public float[] FindAverageTime(int[] processes, int n, int[] bt, int quantum)
        {
            int[] wt = new int[n];
            int[] tat = new int[n];
            float[] results = new float[2];
            int total_wt = 0, total_tat = 0;

            // знаходження асу очікування
            FindWaitingTime(processes, n, bt, wt, quantum);

            // обрахування часу в черзі
            FindTurnAroundTime(processes, n, bt, wt, tat);

            // повний час
            for (int i = 0; i < n; i++)
            {
                total_wt = total_wt + wt[i];
                total_tat = total_tat + tat[i];
            }

            results[0] = (float) total_wt / (float) n;
            results[1] = (float)total_tat / (float)n;

            return results;
        }
    }
}
