using System;
using System.IO;
using System.Linq;
using System.Web;

namespace WebErrorsApplication
{
    public class Logs
    {
        public static void logErrors(string errorMessage)
        {

            try
            {
                string filePath = "C:\\Temp\\logs.txt";
                if (File.Exists(filePath) == false)
                {
                    File.Create(filePath).Close();
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Length > 1024 * 1024 * 100) // 100 MB
                    {
                        string archiveFilePath = "C:\\Temp\\logs_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                        File.Move(filePath, archiveFilePath);
                        File.Create(filePath).Close();
                    }
                }

                StreamWriter writer = new StreamWriter(filePath, true);
                writer.WriteLine();
                writer.WriteLine(DateTime.Now.ToString());
                writer.WriteLine(errorMessage);
                writer.Flush();
                writer.Close();

            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex);

            }

        }

    }
}