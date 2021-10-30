using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NimbleRx
{
    public class FileWriter
    {
        public void WritePasswords(Dictionary<string, string> newPasswords, string path)
        {
            if (Directory.Exists(path))
            {
                var outputPath = path + @"\NewPasswords.txt";
                using (StreamWriter sw = new StreamWriter(outputPath, false))
                {
                    foreach (var password in newPasswords)
                    {
                        StringBuilder sb = new StringBuilder(password.Key);
                        sb.Append("=>");
                        sb.Append(password.Value);

                        sw.WriteLine(sb.ToString());
                    }
                }
            }
            else
            {
                throw new ArgumentException("Export Path is invalid");
            }

        }
    }
}
