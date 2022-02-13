namespace Infrastructure
{
    public static class Reader
    {
        public static string path = @"H:\DesignPatternsProjectDatabase.txt";
        
        public static int ReadContextChoice()
        {
            if (!File.Exists(path))
            {
                return 0; //default
            }
            return int.Parse(System.IO.File.ReadAllText(path));
        }

    }
}
