using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NimbleRx
{
    public class FileReader
    {
        public List<string> ReadPasswordList(string path)
        {
            List<string> passwordList = new List<string>();

            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();
                        passwordList.Add(line);
                    }
                }

            }
            else
            {
                throw new ArgumentException("Invalid Path");
            }

            return passwordList;
        }

        public Dictionary<char, char> ReadCharacterMap(string path)
        {
            Dictionary<char, char> characterMap = new Dictionary<char, char>();

            if(File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();
                        string[] splitLine = line.Split("=>");
                        var orig = splitLine[0].ToCharArray()[0];
                        var replacement = splitLine[1].ToCharArray()[0];
                        characterMap.Add(orig, replacement);
                    }
                }

            } 
            else
            {
                throw new ArgumentException("Invalid Path");
            }

            return characterMap;
        }
    }
}
