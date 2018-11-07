using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_7z_2v
{
    class Program
    {
        static void Main(string[] args)
        {
            int summ = 0;
            bool S = false, f = true;
            int[,] cvad = new int[5, 5];
            Random rand = new Random();
            int li = 0, st = 0, counter = 0, Try = 0;
            for (int i = st; i < 5; i++)
                {
                    cvad[st, i] = rand.Next(1, 9);
                    summ += cvad[st, i];
                }
            Console.WriteLine("[" + st + "," + li + "] = " + summ);
            st++;
            while (!S)
            {
                cvad_zap(ref S, ref f, ref cvad, ref li, ref st, ref counter, summ, rand);
                if (!S) {
                    Try++;
                    Console.WriteLine("Попытка №" + Try + " неудалась.");
                    st = 1;
                    li = 0;
                    f = true;
                    for (int y = 0; y <= 4; y++)
                    {
                        for (int t = 0; t <= 4; t++)
                        {

                            if (t == 4) { Console.WriteLine(cvad[y, t] + " "); } else { Console.Write(cvad[y, t] + " "); }

                        }
                    }
                    for (int y = 1; y <= 4; y++)
                    {
                        for (int t = 0; t <= 4; t++)
                        {
                            cvad[y, t] = 0;
                        }
                    }
                }
                else
                {
                    Try++;
                    Console.WriteLine("Попытка №" + Try + " удалась.");
                    for (int y = 0; y <= 4; y++)
                    {
                        for (int t = 0; t <= 4; t++)
                        {

                            if (t == 4) { Console.WriteLine(cvad[y, t] + " "); } else { Console.Write(cvad[y, t] + " "); }

                        }
                    }                    
                }
            }
            
            Console.ReadKey();
        }
        static private bool cvad_zap (ref bool S, ref bool f, ref int[,] cvad, ref int li, ref int st, ref int counter, int summ, Random rand) {
            counter = 0;
            int nsumm = 0;

            if (f) {
                S = false;
                for (int i = st; i < 5; i++) { cvad[i, li] = rand.Next(1, 9); }
                while (!S){
                    for (int i = st; i < 5; i++)
                    {
                        nsumm = 0;
                        for (int i1 = 0; i1 < 5; i1++) { nsumm += cvad[i1, li]; }
                        if (nsumm > summ) { if (cvad[i, li] > 1) { cvad[i, li]--; } }
                        if (nsumm < summ) { if (cvad[i, li] < 9) { cvad[i, li]++; } }
                    }
                    nsumm = 0;
                    for (int i = 0; i < 5; i++) { nsumm += cvad[i, li]; }
                    if (summ == nsumm)
                    {
                        S = true;
                        f = false;
                        li++;
                        if (li < 5)
                        {
                            cvad_zap(ref S, ref f, ref cvad, ref li, ref st, ref counter, summ, rand);
                        }
                    }
                    else
                    {
                        counter++;
                    }
                    if (counter>=20) {
                        break;
                    }
                }
                } else {
                S = false;
                for (int i = li; i < 5; i++){cvad[st, i] = rand.Next(1, 9);
                }
                while (!S)
                {
                    
                    for (int i = li; i < 5; i++)
                    {
                        nsumm = 0;
                        for (int i1 = 0; i1 < 5; i1++){nsumm += cvad[st, i1];}
                        if (nsumm > summ){if (cvad[st, i] > 1){cvad[st, i]--;}}
                        if (nsumm < summ){if (cvad[st, i] < 9){cvad[st, i]++;}}
                    }
                    nsumm = 0;
                    for (int i = 0; i < 5; i++){nsumm += cvad[st, i];}
                    if (summ == nsumm){
                        S = true;
                        f = true;
                        st++;
                        if (st < 5)
                        {
                            cvad_zap(ref S, ref f, ref cvad, ref li, ref st, ref counter, summ, rand);
                        }

                    }
                    else
                    {
                       counter++;
                    }
                    if (counter >= 20)
                    {
                        break;
                    }
                }
            }

            return S;
        }

    }
}
