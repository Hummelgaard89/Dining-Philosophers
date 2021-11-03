using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Timers;

namespace Dining_Philosophers
{
    class philosophers
    {
        private Random random = new Random();
        public string Name { get; set; }
        public Fork ForkToTheLeft { get; private set; }
        public Fork ForkToTheRight { get; private set; }
        private int EatDelay { get; set; }
        private int ThinkDelay { get; set; }
        private int WaitDelay { get; set; }
        public int HungerCounter { get; set; }
        public philosophers(string name, Fork forktotheleft, Fork forktotheright,int hungercounter)
        {
            Name = name;
            ForkToTheLeft = forktotheleft;
            ForkToTheRight = forktotheright;
            HungerCounter = hungercounter;
        }

        public void StartSpaghettiMaham()
        {
            do
            {
                try

                {
                    Monitor.Enter(Thread.CurrentThread);

                    lock (Thread.CurrentThread)
                    {
                        //Checks if the Philosopher is still alive, if not it breaks the loop to not spam the console.
                        while (this.HungerCounter > 0)
                        {
                            //Checks if the fork to his left or right is available.
                            if (this.ForkToTheLeft.ForkOccupied == false || this.ForkToTheRight.ForkOccupied == false)
                            {
                                // #Region Eating: If both forks is available, both forks will be occupied and the philosoph will first eat for at random period of time, and his hungercocunter will increment.
                                // #Region Thinking: Afterwards he'll think about the meal for a random amount of time, and his hungercounter will decrement.
                                if (this.ForkToTheRight.ForkOccupied == false && this.ForkToTheLeft.ForkOccupied == false)
                                {
                                    //
                                    #region Eating
                                    this.ForkToTheLeft.ForkOccupied = true;
                                    this.ForkToTheRight.ForkOccupied = true;
                                    this.EatDelay = random.Next(2000, 5000);
                                    Thread.Sleep(this.EatDelay);
                                    Console.WriteLine(this.Name + " Is currently eating spaghetti");
                                    this.HungerCounter = this.HungerCounter + (this.EatDelay / 1000);
                                    Console.WriteLine(this.Name + "'s hungercount is: " + this.HungerCounter + "\n");
                                    this.ForkToTheLeft.ForkOccupied = false;
                                    this.ForkToTheRight.ForkOccupied = false;
                                    #endregion End Eating
                                    //
                                    #region Thinking
                                    this.ThinkDelay = random.Next(3000, 7000);
                                    Console.WriteLine(this.Name + " is now thinking about the lovely spaghetti!");
                                    Thread.Sleep(this.ThinkDelay);
                                    this.HungerCounter = this.HungerCounter - (this.ThinkDelay / 1000);
                                    Console.WriteLine(this.Name + "'s hungercount is: " + this.HungerCounter + "\n");
                                    #endregion End Thinking
                                }
                            }
                            // #Region Waiting: If the philosoph can't get both forks, he will wait a random amount of time and his hunger counter will decrement.
                            else if (this.ForkToTheRight.ForkOccupied == true || this.ForkToTheLeft.ForkOccupied == true)
                            {
                                #region Waiting
                                this.ForkToTheLeft.ForkOccupied = false;
                                WaitDelay = random.Next(1000, 3000);
                                Console.WriteLine(this.Name + " is awaiting forks to be available\n");
                                Thread.Sleep(random.Next(WaitDelay));
                                HungerCounter = HungerCounter - (WaitDelay / 1000);
                                #endregion End Waiting
                            }
                        }
                        //If the philosophs hungercounter gets to 0 or below, the philosoph will die.
                        Console.WriteLine(this.Name + " Is sadly passed away of starvation\n");
                        break;
                    }
                }
                finally
                {
                    Monitor.Exit(Thread.CurrentThread);
                }
            } while (true);
        }
    }

}

