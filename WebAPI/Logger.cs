using System.Management.Automation;
using System.Xml;
using ToastNotifications;
using ToastNotifications.Position;
using WebAPI.Structural;

namespace WebAPI
{
    public static class Logger
    {
        public static string path = @"H:\DesignPatternsProjectLogs.txt";
        //private static string username = "";
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

        public static void Log(string text, string pathh)
        { 
        //{
        //    if (Singleton.GetUser() != null)
        //    { username = Singleton.GetUser().UserName + ": "; }
            // This text is added only once to the file.
            
            if (!File.Exists(pathh))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(pathh))
                {
                    sw.WriteLine(text);
                }
            }
            else
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(pathh))
                {
                    sw.WriteLine(text);
                }
            }
            
        }


    }

}
