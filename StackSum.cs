namespace StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            int[] initialNumbers = inputLine.Split(" ").Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(initialNumbers);

            string comand;
            while((comand = Console.ReadLine().ToLower()) != "end")
            {
                string[] comandParts = comand.Split(' ');
                if (comandParts[0] == "add")
                {
                    int n1 = int.Parse(comandParts[1]);
                    int n2 = int.Parse(comandParts[2]);

                    stack.Push(n1);
                    stack.Push(n2);
                }
                else if (comandParts[0] == "remove")
                {
                    int n = int.Parse(comandParts[1]);
                    if(stack.Count >= n)
                    {
                        for(int i = 0; i < n; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

            }
            int sum = 0;
            for(int i = 0; comand.Length >= i; i ++)
            {
                int digit = Convert.ToInt32(i);
                sum += digit;

            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}