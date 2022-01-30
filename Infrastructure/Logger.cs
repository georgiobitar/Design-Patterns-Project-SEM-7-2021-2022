﻿namespace Infrastructure
{
    public static class Logger
    {
        public static string path = @"H:\DesignPatternsProjectLogs.txt";

        public static void Log(string text)
        {
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);
                }
            }
            else
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }

        }
    }

}
