using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ravine
{
    public class RavinePlay

    {

        private bool _isRescue = new bool();
        private bool _hasFire = new bool();
        private int _health = new int();
        private int _risk = new int();
        public List<ForagedItem> _foragedItemDeck = new List<ForagedItem>();
        public List<NightCard> _nightcards = new List<NightCard>();
        private bool continueToRun;




        //deal random item from list
        // private List<CraftingTools> _craftingTools = new List<CraftingTools>();


        // deal random item from list



        public void Run()
        {
            // introPage LoadScreen = new introPage();
            // LoadScreen.Run();
            AddNightCards();
            AddForagedItem();
            _health = SetHealth();
            bool continueToRun = true;
            //game engine
            Console.Clear();
            Console.WriteLine("You have crashed on the island. Rescue will occur if you are lucky. Can you survive?");
            Console.WriteLine("Press any key to take your chances at survival");
            Thread.Sleep(1500);
            Console.WriteLine
            ("Your injuries may be major (3 hearts) or minor (6 hearts).\n",
            "To survive you must Forage for supplies by risking hearts. \n",
            "But beware, each day of foraging and each night brings either chance or terror!!!.\n",
            "Press Any key to play.");
            Console.ReadKey();
            // if (_health > 0 &&  //  == Animal|| Weather || Emotion)
            while (continueToRun && _health > 0)
            {
                Console.Clear();
                Console.WriteLine("Let's check your health.");
                Console.WriteLine($"You have {_health} to risk foraging");
                Console.WriteLine("Press any key to take your chances at survival");
                //Console.WriteLine($"The maximum you may risk foraging is {_health - 1} ");
                Thread.Sleep(2500);
                Console.WriteLine("Would you like to forage? If so press 2.");
                string userinput = Console.ReadLine();
                _risk = Int32.Parse(userinput);
                Console.WriteLine($"You are spending 2 health foraging. Your remaining health is {_health} Best of luck to you!");
                if (_risk == 1)
                {
                    _health -= 1;
                    Thread.Sleep(2500);
                    Console.WriteLine($"Sitting in the sand afraid will not feed you today. You now have {_health} health points.");
                }
                else
                {
                    Thread.Sleep(2500);
                    Console.WriteLine("Let's go foraging!!! Walking......walking.....stalk.....CATCH!!!!");
                    Thread.Sleep(2000);
                    _health -= 2;
                    GetRandomForageCard();
                    ForagedItem foragedItem = GetRandomForageCard();
                    Thread.Sleep(2000);
                    Console.WriteLine($"You have found a {foragedItem.TypeofForage}, they are {foragedItem.Description} it gives {foragedItem.Value} health");
                    _health += foragedItem.Value;
                    Console.WriteLine($"You now have {_health}");
                }
                Thread.Sleep(2500);
                Console.WriteLine("Are you ready for a new night? yes or no");
                string useriInput = Console.ReadLine();
                if (_health >= 1 && _currentCard.CardType == CardType.Rescue)
                {
                    Console.WriteLine($"Congrats, you have been rescued. You still have {_health} left.");
                    continueToRun = false;
                }
                else if (_health >= 1)
                {
                    //Console.WriteLine("Game Over, you died without being rescued. Your body will rot and be forgotten. hahahah.... ");
                    //continueToRun = false;
                    //Console.ReadKey();
                    if (useriInput == "yes")
                    {
                        GetRandomNightCard();
                        _currentCard = GetRandomNightCard();
                        Thread.Sleep(2500);
                        //_currentCard = nightCard;
                        Console.WriteLine($"Description:{_currentCard.Description} {_currentCard.Consequence} loose {_currentCard.Damage}");
                        CalculateHealth(_currentCard.Damage);
                        Console.WriteLine($"Your health is now {_health}\n" +
                            $"Press any key to continue");
                        Console.ReadKey();
                        Console.WriteLine($"Ready to forage again? You currently have {_health} If so, click any key.");
                    }
                    else
                    {
                        Console.WriteLine("Suicide makes sense, Game over sucka!");
                        continueToRun = false;
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Game Over, you died without being rescued. Your body will rot and be forgotten. hahahah.... ");
                    continueToRun = false;
                    Console.ReadKey();
                }
            }
        }

        public int CalculateHealth(int damage)
        {
            _health += damage;
            return _health;
        }