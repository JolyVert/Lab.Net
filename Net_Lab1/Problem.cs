using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Lab1
{
    internal class Problem
    {
        public int n;
        public List<Item> items = new List<Item>();

        public Problem(int n, int seed)
        {
            this.n = n;

            Random random = new Random(seed);

            for (int i = 0; i < n; i++)
            {
                int value = random.Next(1, 11);
                int weight = random.Next(1, 11);

                items.Add(new Item(value, weight));
            }
        }

        public Result Solve(int capacity)
        {
            Result result = new Result();

            List<int> order = Enumerable.Range(0, n).ToList();

            order.Sort((a, b) =>
                ((double)items[b].value / items[b].weight)
                .CompareTo((double)items[a].value / items[a].weight));

            int currentWeight = 0;

            foreach (int i in order)
            {
                if (currentWeight + items[i].weight <= capacity)
                {
                    result.items.Add(i);
                    result.totalWeight += items[i].weight;
                    result.totalValue += items[i].value;
                    currentWeight += items[i].weight;
                }
            }

            return result;
        }

        public override string ToString()
        {
            string text = "";

            for (int i = 0; i < items.Count; i++)
            {
                text += "Item " + i +
                        " value=" + items[i].value +
                        " weight=" + items[i].weight + "\n";
            }

            return text;
        }
    }
}
