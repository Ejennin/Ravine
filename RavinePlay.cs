using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Ravine
{


    public class RavinePlay

    {

        private bool _isRescue = new bool();
        private bool _hasFire = new bool();
        private int _health = new int();
        private int _risk = new int();
        private List<ForagedItem> _foragedItemDeck = new List<ForagedItem>();
        private List<NightCard> _nightcards = new List<NightCard>();
        private bool continueToRun = true;
        private NightCard _currentCard = new NightCard();








        public void Run()
        {
            introPage LoadScreen = new introPage();
            LoadScreen.Run();
            AddNightCards();
            AddForagedItem();
            _health = SetHealth();
            bool continueToRun = true;





            //game engine
            Console.Clear();
            Console.WriteLine("You have crashed on the island. Rescue will occur if you are lucky. Can you survive?");
            Console.WriteLine("Press any key to take your chances at survival.");
            Thread.Sleep(1500);
            Console.WriteLine
            ($"Your injuries leave you with {_health} health.\n" +


            "To survive you must Forage for supplies by risking hearts. \n" +


            "But beware, each day of foraging and each night brings either chance or terror!!!.\n" +


            "Press Any key to play.");


            Console.ReadKey();


            while (continueToRun && _health > 0)
            {
                Console.Clear();
                Console.WriteLine("Let's check your health.");
                Console.WriteLine($"You have {_health} to risk foraging");
                Console.WriteLine("Press any key to take your chances at survival. Risk as many health points as you dare.");
                Thread.Sleep(2500);
                Console.WriteLine("Would you like to forage? If so enter the health you want to risk.");
                string userinput = Console.ReadLine();
                _risk = Int32.Parse(userinput);
                CalculateHealthAfterRisk(_risk);
                Console.WriteLine($"You are spending {_risk} health foraging. Your remaining health is {_health} Best of luck to you Castaway!");
                if (_health >= 1 && _currentCard.CardType == CardType.Rescue)
                {
                    Console.WriteLine($"Congrats, you have been rescued. You still have {_health} left.");
                    continueToRun = false;
                }
                if (_risk == 1)
                {

                    _health -= 1;
                    Thread.Sleep(2500);
                    Console.WriteLine($"Sitting in the sand afraid will not feed you today. You now have {_health} health points.");


                }
                else
                {

                    GetRandomForageCard();
                    ForagedItem foragedItem = GetRandomForageCard();
                    Thread.Sleep(2000);
                    Console.WriteLine($"You have found a {foragedItem.TypeofForage}, they are {foragedItem.Description} it's value is {foragedItem.Value} health");
                    _health += foragedItem.Value;
                    Console.WriteLine($"You now have {_health}");
                }
                Thread.Sleep(2500);

                Console.WriteLine("Are you ready for a new night? yes or no");
                string useriInput = Console.ReadLine();
                Thread.Sleep(2500);

                Console.WriteLine("The sun goes down, Fate Takes it's turn!!!!");
                Thread.Sleep(2000);


                if (_health >= 1)
                {

                    if (useriInput == "yes")
                    {
                        GetRandomNightCard();
                        _currentCard = GetRandomNightCard();
                        Thread.Sleep(2500);
                        //_currentCard = nightCard;
                        Console.WriteLine($"{_currentCard.Description} {_currentCard.Consequence}it gives you a {_currentCard.Damage}");
                        CalculateHealth(_currentCard.Damage);
                        Thread.Sleep(2500);
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



















        private bool AddCardToForagedItemDeck(ForagedItem _card)
        {
            int StartingCount = _foragedItemDeck.Count;
            _foragedItemDeck.Add(_card);
            bool _wasAdded = _foragedItemDeck.Count == StartingCount + 1;
            return _wasAdded;
        }

        private void AddNightCards()
        {



            NightCard rain = new NightCard("Rain", CardType.Weather, -1, "Rain", "You're starting to think the sky hates you.", false);
            _nightcards.Add(rain);
            NightCard theCalm = new NightCard("The Calm", CardType.Emotion, 0, "The Calm", "Is anybody else nervous about how quiet it is tonight?", false);
            _nightcards.Add(theCalm);
            NightCard theElk = new NightCard("The Elk", CardType.Animal, 5, "The Elk", "Wounded, it limps into camp and collapses. You're too hungry to wonder what happened.", false);
            _nightcards.Add(theElk);
            NightCard theRescue = new NightCard("Rescue", CardType.Rescue, 5, "The Plane, the plane!!!", "A cool shadow covers you as the rescue plane blots out the sun, congrate on survivial", false);
            _nightcards.Add(theRescue);
            NightCard thebirds = new NightCard("The Birds", CardType.Animal, -1, "TheBirds", "Your supplies are going missing, and large, black feathers are found in their place.", false);
            _nightcards.Add(thebirds);
            NightCard theWolves = new NightCard("The Wolves", CardType.Animal, -2, "The Wolves The Wolves", "They Came to wwelcome you to the neighborhood, but they're not leaving without dinner.", true);
            _nightcards.Add(theWolves);
            NightCard theGuilt = new NightCard("The Guilt", CardType.Emotion, -1, "TheGuilt", "Maybe the people who died in the crash were actually the lucky ones...", true);
            _nightcards.Add(theGuilt);
            NightCard theDeer = new NightCard("The Deer", CardType.Animal, 3, "TheDeer", "Wounded, it limps into camp and collapses. You're too hungry to wonder what happened.", false);
            _nightcards.Add(theDeer);
            NightCard theWeasels = new NightCard("The Weasels", CardType.Animal, -1, "TheWeasels", "You wake just in time to see several furry thieves scurry into the underbrush.", false);
            _nightcards.Add(theWeasels);
            NightCard theFear = new NightCard("The Fear", CardType.Emotion, -1, "TheFear, The night brings unknown terrors.", "It's difficult to sleep when the fear of impending death is constantly looming over you.", true);
            _nightcards.Add(theFear);
            NightCard wolverine = new NightCard("Wolverine", CardType.Animal, -1, "Wolverine", "This angry scavenger looks nothing like Hugh Jackman.", true);
            _nightcards.Add(wolverine);
            NightCard theWind = new NightCard("The Wind", CardType.Weather, -1, "TheWind", "Furious gusts of wind tear branches from the trees, as if pursuing an ancient grudge.", false);
            _nightcards.Add(theWind);
            NightCard theBadNatives = new NightCard("The Natives", CardType.Weather, 100, "The Natives", "Those natives that have been watch you decide to feed you and heal your wounds", false);
            _nightcards.Add(theBadNatives);
            NightCard theNatives = new NightCard("The Natives", CardType.Weather, -1000, "The Natives", "You wander into a grove a find a village. The natives invite you to dinner. But you are the meal!!!", false);
            _nightcards.Add(theNatives);
















        }

        private void AddForagedItem()
        {
            ForagedItem mushrooms = new ForagedItem(Forage.Mushroom, 0, "cute little psycotropic", false, true);
            _foragedItemDeck.Add(mushrooms);
            ForagedItem grub = new ForagedItem(Forage.Grub, 1, "Disgusting and Nutritous", false, false);
            _foragedItemDeck.Add(grub);
            ForagedItem waspNest = new ForagedItem(Forage.WaspNest, -1, "an agonizing discovery of a", true, false);
            _foragedItemDeck.Add(waspNest);
            ForagedItem chantrelle = new ForagedItem(Forage.Chantrelle, 2, "an agonizing discovery of a ", false, false);
            _foragedItemDeck.Add(chantrelle);
            ForagedItem rabbit = new ForagedItem(Forage.Rabbit, 3, "a hearty meal of ", false, false);
            _foragedItemDeck.Add(rabbit);
            ForagedItem hornets = new ForagedItem(Forage.Hornets, -1, "an agonizing discovery of a ", true, false);
            _foragedItemDeck.Add(hornets);
            ForagedItem taser = new ForagedItem(Forage.Taser, 1, "defends against animal attacks", false, false);
            _foragedItemDeck.Add(taser);
            ForagedItem minnows = new ForagedItem(Forage.Minnows, 2, "tiny but tasty ", false, false);
            _foragedItemDeck.Add(minnows);
            ForagedItem wildOnion = new ForagedItem(Forage.WildOnion, 1, "sweet and sticky ", false, false);
            _foragedItemDeck.Add(wildOnion);
            ForagedItem berries = new ForagedItem(Forage.Berries, 1, "seemingly edible ", false, false);
            _foragedItemDeck.Add(berries);
            ForagedItem moose = new ForagedItem(Forage.Moose, 4, "sweet and sticky ", true, false);
            _foragedItemDeck.Add(moose);







        }


        public int SetHealth()
        {
            Random random = new Random();
            int health = random.Next(3, 7);
            return health;
        }

        public int SetRisk()
        {
            string risk = Console.ReadLine();
            int holdRisk = Int32.Parse(risk);
            return holdRisk;

        }



        private NightCard GetRandomNightCard()
        {
            Random rand = new Random();
            int index = rand.Next(_nightcards.Count);
            NightCard nightCard = _nightcards[index];
            _nightcards.Remove(nightCard);
            _currentCard = nightCard;
            return nightCard;
        }

        private ForagedItem GetRandomForageCard()
        {
            Random rand = new Random();
            int index = rand.Next(_foragedItemDeck.Count);
            ForagedItem forageCard = _foragedItemDeck[index];
            return forageCard;
        }

        public void CalculateHealth(int damage)
        {
            _health += damage;


        }

        public void CalculateHealthAfterRisk(int userInput)
        {
            _health -= userInput;
        }






    }

}


