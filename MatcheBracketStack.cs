namespace MatchingBracketsStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine(); 
            Stack<int> indecies = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indecies.Push(i);
                }
                else if (expression[i] == ')')
                {
                    var openBracketIndex = indecies.Pop();
                    var closeBracketIndex = i;
                    Console.WriteLine(expression.Substring(openBracketIndex,
                        closeBracketIndex - openBracketIndex + 1));
                }
            }
        }
    }
}