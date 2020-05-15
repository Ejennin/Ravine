using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ravine
{
    public enum CardType { Weather, Animal, Emotion, Rescue }
    public class NightCard
    {
        public string Name { get; }

        public CardType CardType { get; }
        public int Damage { get; }
        public string Description { get; }

        public string Consequence { get; }

        public bool AllowFire { get; }

       


        public NightCard()
        {

        }

        public NightCard( string name, CardType cardType, int damage, string description, string consequence, bool allowFire)    
        {
            
            Name = name;
            CardType = cardType;
            Damage = damage;
            Description = description;
            Consequence = consequence;
            AllowFire = allowFire;
            
        }





}
}
