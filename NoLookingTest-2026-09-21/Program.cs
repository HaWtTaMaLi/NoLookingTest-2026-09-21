using System;
using System.Net;

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
        //Levels
        static int curLVL;
        static int lvlUp;
        static int lvlUpCost;
        //Experience
        static int currEXP;
        static int expInc;
        static int expIncCost;
        //Health
        static int currPlayerHealth;
        static int currEnemyHealth;

        static void Main()
        {
            //Initiate
            curLVL = 1;
            lvlUpCost = 1;
            lvlUp = lvlUpCost;

            currEXP = 0;
            expIncCost = 25;
            expInc = expIncCost;

            currPlayerHealth = 100;
            currEnemyHealth = 100;

            Console.ForegroundColor = ConsoleColor.White;

            //Pretend play through
            PlayerHUD();
            EnemyHUD();
            XPGained(100);
            TakePlayerDamage(10);
            TakeEnemyDamage(20);
            LvlUpChecker();
            LvlUpChecker(); //if the amount is going to be more then the cost i need to run lvl up checker more 
            PlayerHUD();
            EnemyHUD();
            HealPlayer(5);
            PlayerHUD();

        }

        static void LvlUpChecker()
        {
            //lvl checker would go somewhere in an update function so it's constantly checking?
            if(currEXP >= expInc)
            {
                curLVL = curLVL + lvlUp;

                currEXP = currEXP - expInc;
                expInc = expInc + expIncCost;
            }
        }

        static void XPGained(int xp)
        {
            currEXP = xp + currEXP;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nGained " + xp +"xp");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PlayerHUD()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--------Player-------");
            Console.WriteLine("Health: " + currPlayerHealth + " | lvl: " + curLVL);
            Console.WriteLine("   Exp: " + currEXP + "/" + expInc);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void EnemyHUD()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n--------Enemy-------");
            Console.WriteLine("Health: " + currEnemyHealth);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void TakePlayerDamage(int dmg)
        {
            currPlayerHealth = currPlayerHealth - dmg;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou took damage!");
            Console.WriteLine("-" + dmg +" dmg");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //somewhere in here i can probaly add a if the enemy health
        //reaches 0 it can add XP and then reset the 0 to 100
        //and repeat. and maybe increase the XP each kill?

        static void TakeEnemyDamage(int dmg)
        {
            currEnemyHealth = currEnemyHealth - dmg;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou attacked the enemy");
            Console.WriteLine("-" + dmg + " dmg delt.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void HealPlayer(int hp)
        {
            currPlayerHealth = currPlayerHealth + hp;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYou healed +" + hp + " hp.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
