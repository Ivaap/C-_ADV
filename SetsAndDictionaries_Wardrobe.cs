namespace SetsAndDictionaries_Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int count = int.Parse(Console.ReadLine());

            for(int i = 0; i < count; i++)
            {
                string[] inputArg = Console.ReadLine().Split("-> ");
                string color = inputArg[0];
                string[] clothes = inputArg[1].Split(",");
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach(var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }
                    wardrobe[color][item]++;
                }
            }
            string[] targetClothes = Console.ReadLine().Split();

            foreach(var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach(var (clothe, value ) in color.Value)
                {
                    if(clothe == targetClothes[1] && color.Key == targetClothes[0])
                    {
                        Console.WriteLine($"* {clothe} - {value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"*{clothe} - {value}");
                    }
                }
            }
        }
    }
}