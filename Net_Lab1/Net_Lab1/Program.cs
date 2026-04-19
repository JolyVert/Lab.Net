
namespace Net_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of items:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter seed:");
            int seed = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter capacity:");
            int capacity = int.Parse(Console.ReadLine());

            Problem problem = new Problem(n, seed);

            Console.WriteLine(problem);

            Result result = problem.Solve(capacity);

            Console.WriteLine(result);
        }
    }
}