using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Lab1
{
    internal class Result
    {
        public List<int> items = new List<int>();
        public int totalValue = 0;
        public int totalWeight = 0;

        public override string ToString()
        {
            string text = "Items in backpack: ";

            foreach (int i in items)
                text += i + " ";

            text += "\nTotal value: " + totalValue;
            text += "\nTotal weight: " + totalWeight;

            return text;
        }
    }
}
