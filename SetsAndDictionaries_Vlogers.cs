namespace SetsAndDictionaries_Vlogers
{
    class Vlogger
    {
        public string Name { get; set; }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
        public Vlogger(string vloggerName)
        {
            Name = Name;
            Followers = new HashSet<string>();
            Following = new HashSet<string>();
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] parts = input.Split(' ');
                string vloggerName = parts[0];

                if (parts[1] == "joined")
                {
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers[vloggerName] = new Vlogger(vloggerName);
                    }
                }
                else if (parts[1] == "followed")
                {
                    string followedName = parts[2];

                    if (vloggerName != followedName &&
                        vloggers.ContainsKey(vloggerName) &&
                        vloggers.ContainsKey(followedName) &&
                        !vloggers[vloggerName].Following.Contains(followedName))
                    {
                        vloggers[vloggerName].Following.Add(followedName);
                        vloggers[followedName].Followers.Add(vloggerName);
                    }
                }
            }

            PrintStatistics(vloggers);
        }
        static void PrintStatistics(Dictionary<string, Vlogger> vloggers)
        {
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVloggers = vloggers.Values
                .OrderByDescending(v => v.Followers.Count)
                .ThenBy(v => v.Following.Count)
                .ToList();

            var mostFamous = sortedVloggers.First();

            Console.WriteLine($"1. {mostFamous.Name} : {mostFamous.Followers.Count} followers, {mostFamous.Following.Count} following");
            foreach (var follower in mostFamous.Followers.OrderBy(f => f))
            {
                Console.WriteLine($"*  {follower}");
            }

            int rank = 2;
            foreach (var vlogger in sortedVloggers.Skip(1))
            {
                Console.WriteLine($"{rank}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
                rank++;
            }
        }
    }
}
