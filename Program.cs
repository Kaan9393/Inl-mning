using System;
using System.Collections.Generic;

namespace InlämningsUppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //Lista med Personer
            List<Person> people = new List<Person>();
            Random rnd = new Random();

            //Spelplan
            int X = 25;
            int Y = 100;
            String[,] spelPlan = new string[X, Y];


            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    spelPlan[x, y] = " ";
                }
            }
            



                for (int i = 0; i < 20; i++)
                {
                    people.Add(new Tjuv(rnd.Next(0, 100 + 1), rnd.Next(0, 25 + 1), rnd.Next(-1, 1 + 1), rnd.Next(-1, 1 + 1), "T"));
                    people.Add(new Polis(rnd.Next(0, 100 + 1), rnd.Next(0, 25 + 1), rnd.Next(-1, 1 + 1), rnd.Next(-1, 1 + 1), "P"));
                    people.Add(new Medborgare(rnd.Next(0, 100 + 1), rnd.Next(0, 25 + 1), rnd.Next(-1, 1 + 1), rnd.Next(-1, 1 + 1), "M"));
                }

                foreach (Person a in people)
                {
                    a.PositionX += a.DirectionY;
                    a.PositionY += a.DirectionX;

                    if (a.PositionX == -1 && a.DirectionY == -1)
                    {
                        a.PositionX = 24;
                    }
                    else if (a.PositionX == 25 && a.DirectionY == 1)
                    {
                        a.PositionX = 0;
                    }
                    if (a.PositionY == -1 && a.DirectionX == -1)
                    {
                        a.PositionY = 99;

                    }
                    else if (a.PositionY == 100 && a.DirectionX == 1)
                    {
                        a.PositionX = 0;
                    }


                    if (spelPlan[a.PositionX, a.PositionY] == " ")
                    {
                        spelPlan[a.PositionX, a.PositionY] = a.Token;
                    }
                    else if (spelPlan[a.PositionX, a.PositionY] == "T" && a is Polis)
                    {
                        spelPlan[a.PositionX, a.PositionY] = "X";
                    }
                    else if (spelPlan[a.PositionX, a.PositionY] == "M" && a is Tjuv)
                    {
                        spelPlan[a.PositionX, a.PositionY] = "X";
                    }
                
                    for (int x = 0; x < 25; x++)
                    {
                        for (int y = 0; y < 100; y++)
                        {
                            Console.Write(spelPlan[x, y]);
                        }
                        Console.WriteLine();
                    }

                    Console.ReadKey();

                    }
            




        }



        class Person
        {
            public int PositionX { get; set; }
            public int PositionY { get; set; }
            public int DirectionX { get; set; }
            public int DirectionY { get; set; }
            public string Token { get; set; }
            //Inventory? 

            public void Move()      //Ska jag använda det här?
            {
                // Denna är för att Position X och Y ska ändras, för det behöver vi plussa DirectionX,Y.
                //PositionX = PositionX + DirectionX;
                //PositionY = PositionY + DirectionY;

                //if (PositionX < 0)
                //{
                //    PositionX = DirectionX;
                //}
                //if (PositionY < 0)
                //{
                //    PositionY = DirectionY;
                //}
            }

            //public virtual char GetBoardChar()        //Använda det här?
            //{
            //    return '?';
            //}

        }

        class Tjuv : Person
        {
            public Tjuv(int positionX, int positionY, int directionX, int directionY, string token)
            {
                PositionX = positionX;
                PositionY = positionY;
                DirectionX = directionX;
                DirectionY = directionY;
                Token = token;
            }

            //public override char GetBoardChar()
            //{
            //    return 'T';
            //}

            //gör en metod med STEAL
        }

        class Polis : Person
        {
            public Polis(int positionX, int positionY, int directionX, int directionY, string token)
            {
                PositionX = positionX;
                PositionY = positionY;
                DirectionX = directionX;
                DirectionY = directionY;
                Token = token;
            }

            //public override char GetBoardChar()
            //{
            //    return 'P';
            //}

            ///Gör en metod med beslagtaget
        }

        class Medborgare : Person
        {
            public Medborgare(int positionX, int positionY, int directionX, int directionY, string token)
            {
                PositionX = positionX;
                PositionY = positionY;
                DirectionX = directionX;
                DirectionY = directionY;
                Token = token;
            }

            //public override char GetBoardChar()
            //{
            //    return 'M';
            //}

        }
    }
}
