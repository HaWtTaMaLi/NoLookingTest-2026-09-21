using System;

//using Microsoft C# Documentation only
//no looking at old projects or old code

//Combine what i know so far
//make small game where player can roll for damage + heal
//have a YouLoose outcome, cant have a YouWin if i want it to be infinate lol
//have playerHealth and enemyHealth
//give both player and enemy a HUD either separate or together
//Combine it together with XP and LevelSystem 
//to make it a play till you loose game

//does not have time limit, just requires me to only use -
//- it when it's been at least an hour since i've looked at code

//just realized i have no idea how to make this repeat itself
//but im sure i can figure it out lol

namespace NoLookingTest_2026_09_21
{
    internal class Program
    {
        //start with experience and levels
        static int lVL;
        static int lvlUp;
        static int lvlUpCost;

        static int eXP;
        static int expInc;
        static int expIncCost;

        static void Main()
        {
            //Initiate
            lVL = 1;
            lvlUpCost = 1;
            lvlUp = lvlUpCost;

            eXP = 0;
            expIncCost = 25;
            expInc = expIncCost;

            Console.ForegroundColor = ConsoleColor.White;

            //
            HUD();
            XPGained(100);
            LvlUpChecker();
            LvlUpChecker(); //if the amount is going to be more then the cost i need to run lvl up checker more 
            HUD();

            //Can move on to health next


        }

        static void LvlUpChecker()
        {
            //lvl checker would go somewhere in an update function so it's constantly checking?
            if(eXP >= expInc)
            {
                lVL = lVL + lvlUp;
                eXP = eXP - expInc;

                expInc = expInc + expIncCost;
            }
        }

        static void XPGained(int xp)
        {
            eXP = xp + eXP;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nGained " + xp +"XP");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void HUD()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n-------Player------");
            Console.WriteLine("Health: " + " | lvl: " + lVL);
            Console.WriteLine("Exp: " + eXP + "/" + expInc);
            Console.ForegroundColor = ConsoleColor.White;  
        }
    }
}
