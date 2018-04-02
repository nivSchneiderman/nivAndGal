using System;

namespace B18_Ex1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, please enter a string consisting 8 digits or 8 letters:");
            string inputString = System.Console.ReadLine();
            while (!(CheckLegal(inputString)))
            {
                System.Console.WriteLine("Illegal word");
                inputString = Console.ReadLine();
            }
            bool checkIfPalindrome = isPalindrome(inputString);
            int legalNum = checkAndReturnNum(inputString);
            string toPrint;
            if (legalNum == -1)
            {
                byte lowerCaseAmount = countLowerCase(inputString);
                toPrint = string.Format(
                    @"Palindrome check: {0}
There are {1} small letters", checkIfPalindrome, lowerCaseAmount);
            }
            else
            {
                string evenOrOdd = checkIfEven(legalNum);
                toPrint = string.Format(
                    @"Palindrome check: {0}
The number is {1}.", checkIfPalindrome, evenOrOdd);
            }
            System.Console.WriteLine(toPrint);
            System.Console.ReadLine();
        }

        private static bool isPalindrome(string i_InputString)
        {
            int stringLength = i_InputString.Length;
            bool isPalindrome = true;
            for (int charIndex = 0; charIndex < stringLength; charIndex++)
            {
                if (i_InputString[charIndex] != i_InputString[stringLength - charIndex - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }
            return isPalindrome;
        }

        private static string checkIfEven(int i_LegalNum)
        {
            string evenOrOdd = "";
            if ((i_LegalNum % 2) == 1)
            {
                evenOrOdd = "odd";
            }
            else
            {
                evenOrOdd = "even";
            }
            return evenOrOdd;
        }

        private static byte countLowerCase(string i_InputString)
        {
            byte countLowerCase = 0;
            for (int charIndex = 0; charIndex < i_InputString.Length; charIndex++)
            {
                if (Char.IsLower(i_InputString[charIndex]))
                {
                    countLowerCase++;
                }
            }
            return countLowerCase;
        }

        // checks if the string is a legal number, returns -1 if its illegal.
        private static int checkAndReturnNum(string i_InputString)
        {
            int returnNum = 0;
            bool isNum = int.TryParse(i_InputString, out returnNum);
            if (!isNum)
            {
                returnNum = -1;
            }
            return returnNum;
        }

        private static bool CheckLegal(string i_StringToCheck)
        {
            int stringLength = i_StringToCheck.Length;
            bool isLegalString = true;
            if (stringLength != 8)
            {   
                return !isLegalString;
            }
            int charIndex = 0;
            for (charIndex = 0; charIndex < 8; charIndex++)
            {
                if (!(Char.IsDigit(i_StringToCheck[charIndex])))
                {
                    break;
                }
            }
            if (charIndex == 8)
            { // no 'break' occurred, therefore the string is a number
                return isLegalString;
            }
            for (charIndex = 0; charIndex < 8; charIndex++)
            { // checks if the string has letters only
                char currentChar = i_StringToCheck[charIndex];
                if (!(Char.IsLetter(currentChar)))
                {
                    return !isLegalString;
                }
            }
            return isLegalString;
        }
    }
}
