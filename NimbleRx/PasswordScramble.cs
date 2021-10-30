using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NimbleRx
{
    public class PasswordScramble
    {
        public List<string> DuplicatePasswords = new List<string>();

        public Dictionary<string, string> ScramblePasswords(List<string> passwords, Dictionary<char, char> characterMap)
        {
            var scrambledPasswords = new Dictionary<string, string>();

            foreach(var password in passwords)
            {
                if(!scrambledPasswords.ContainsKey(password))
                {
                    if (IsPasswordValid(password))
                    {
                        var newPassword = ApplyCharacterMap(characterMap, password);
                        scrambledPasswords.Add(password, newPassword);
                    }
                    else
                    {
                        scrambledPasswords.Add(password, "X");
                    }
                }
                else
                {
                    DuplicatePasswords.Add(password);
                }
            }

            return scrambledPasswords;
        }
        private bool IsPasswordValid(string password)
        {
            // Check if password is minimum 6 characters
            if (password.Length < 6)
            {
                return false;
            }

            // Check if there are 4 distinct characters
            var distinctPassword = password.ToCharArray().Distinct().ToArray();
            if (distinctPassword.Length < 4)
            {
                return false;
            }

            return true;
        }

        private string ApplyCharacterMap(Dictionary<char, char> characterMap, string password)
        {
            var newPassword = new Char[password.Length];
            var passwordArray = password.ToCharArray();
            for (int i = 0; i < passwordArray.Length; i++)
            {
                if (characterMap.ContainsKey(passwordArray[i]))
                {
                    newPassword[i] = characterMap[passwordArray[i]];
                }
                else
                {
                    newPassword[i] = passwordArray[i];
                }
            }

            return new string(newPassword);
        }
    }
}
