using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ravine
{
    public enum Forage { Deer, Trout, Squirrel, Minnows, WildOnion, Pine_Nuts, Berries, Taser, Dandelion, Mushroom, Feathers, Grub, Spear, Knife, Whiskey, WaspNest, Rabbit, Chantrelle, Hornets, Moose }
    public class ForagedItem
    {
        public Forage TypeofForage { get; set; }

        public int Value { get; set; }
        public string Description { get; set; }
        public bool GivesDamage { get; set; }
        public bool IsPsychodelic { get; set; }



        public ForagedItem()
        {

        }

        public ForagedItem(Forage forageItem, int value, string description, bool givesDamage, bool isPsychodelic)
        {

            TypeofForage = forageItem;
            Value = value;
            Description = description;
            GivesDamage = givesDamage;
            IsPsychodelic = isPsychodelic; //if psychodelic, make a random choice?
        }









    }
}
