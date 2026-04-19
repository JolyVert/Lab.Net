using Net_Lab1;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void buttonSolve_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(textBoxNN.Text);
                int seed = int.Parse(textBoxSeed.Text);
                int capacity = int.Parse(textBoxCapacity.Text);

                Problem p = new Problem(n, seed);
                Result r = p.Solve(capacity);

                string output = "";

                // lista przedmiotów
                output += "=== ITEMS ===\r\n";
                for (int i = 0; i < p.items.Count; i++)
                {
                    output += "Item " + i +
                              " -> value: " + p.items[i].value +
                              " weight: " + p.items[i].weight + "\r\n";
                }

                // wynik
                output += "\r\n=== RESULT ===\r\n";

                output += "Chosen items: ";
                foreach (int i in r.items)
                    output += i + " ";

                output += "\r\nTotal value: " + r.totalValue;
                output += "\r\nTotal weight: " + r.totalWeight;

                textBoxResult.Text = output;
            }
            catch
            {
                textBoxResult.Text = "B³¹d danych!";
            }
        }


    }
}
