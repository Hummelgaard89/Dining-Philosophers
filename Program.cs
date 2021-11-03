using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dining_Philosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            Fork fork0 = new Fork("Fork0", false);
            Fork fork1 = new Fork("Fork1", false);
            Fork fork2 = new Fork("Fork2", false);
            Fork fork3 = new Fork("Fork3", false);
            Fork fork4 = new Fork("Fork4", false);

            philosophers Phil1 = new philosophers("Philosophers 1", fork0, fork1, 10);
            philosophers Phil2 = new philosophers("Philosophers 2", fork1, fork2, 10);
            philosophers Phil3 = new philosophers("Philosophers 3", fork2, fork3, 10);
            philosophers Phil4 = new philosophers("Philosophers 4", fork3, fork4, 10);
            philosophers Phil5 = new philosophers("Philosophers 5", fork4, fork0, 10);


            //System.Timers.Timer Phil1DeathTimer = new System.Timers.Timer(15000);
            
            Thread Phil1Eating = new Thread(Phil1.StartSpaghettiMaham);
            Phil1Eating.Start();
            //Phil1Eating.Join();

            Thread Phil2Eating = new Thread(Phil2.StartSpaghettiMaham);
            Phil2Eating.Start();
            //Phil2Eating.Join();


            Thread Phil3Eating = new Thread(Phil3.StartSpaghettiMaham);
            Phil3Eating.Start();
            //Phil3Eating.Join();


            Thread Phil4Eating = new Thread(Phil4.StartSpaghettiMaham);
            Phil4Eating.Start();
            //Phil4Eating.Join();


            Thread Phil5Eating = new Thread(Phil5.StartSpaghettiMaham);
            Phil5Eating.Start();
            //Phil5Eating.Join();


            Console.ReadLine();

        }



    }
}
