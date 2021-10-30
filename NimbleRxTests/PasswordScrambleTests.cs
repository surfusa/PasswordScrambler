using Microsoft.VisualStudio.TestTools.UnitTesting;
using NimbleRx;
using System;
using System.Collections.Generic;
using System.Text;

namespace NimbleRx.Tests
{
    [TestClass()]
    public class PasswordScrambleTests
    {
        private Dictionary<char, char> characterMap = new Dictionary<char, char>();

        [TestInitialize()]
        public void StartUp()
        {
            characterMap.Add('a', 'z');
            characterMap.Add('e', '4');
            characterMap.Add('d', 'y');
            characterMap.Add('p', 'x');
        }

        [TestMethod()]
        public void ScramblePasswordTestSuccess()
        {
            var scrambler = new PasswordScramble();
            var password = "abcdefg2";
            var testString = new List<string>();
            var expectedResult = "zbcy4fg2";
            testString.Add(password);

            var result = scrambler.ScramblePasswords(testString, characterMap);

            Assert.AreEqual(expectedResult, result[password]);
        }

        [TestMethod()]
        public void ScramblePasswordTestMinimumCharacter()
        {
            var scrambler = new PasswordScramble();
            var password = "3nd";
            var testString = new List<string>();
            var expectedResult = "X";
            testString.Add(password);

            var result = scrambler.ScramblePasswords(testString, characterMap);

            Assert.AreEqual(expectedResult, result[password]);
        }

        [TestMethod()]
        public void ScramblePasswordTestDistinctCharacters()
        {
            var scrambler = new PasswordScramble();
            var password = "iiiiiiiih8iiiiiiiiiii";
            var testString = new List<string>();
            var expectedResult = "X";
            testString.Add(password);

            var result = scrambler.ScramblePasswords(testString, characterMap);

            Assert.AreEqual(expectedResult, result[password]);
        }
    }
}

namespace NimbleRxTests
{
    class PasswordScrambleTests
    {
    }
}
