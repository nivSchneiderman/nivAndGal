using System;

namespace B18_Ex01_5
{
    class Program
    {
        protected const byte k_NumOfDigits = 6;

        public static void Main(string[] args)
        {
            analyzeNumber();
        }

        private static void analyzeNumber()
        {
            int number = getValidNumber();
            byte largestDigit = getLargestDigitInNumber(number);
            byte smallestDigit = getSmallestDigitInNumber(number);
            byte numOfEvenDigits = getNumberOfEvenDigitsInNumber(number);
            byte numOfSmallers = getNumberOfSmallersDigits(number);

            string msg = string.Format(
@"The largest digit in the number is: {0}
The Smallest digit in the number is: {1}
The number contains {2} even digits
and {3} digits that are lesser than the units digit", largestDigit, smallestDigit, numOfEvenDigits,numOfSmallers);

            Console.WriteLine(msg);
            Console.WriteLine(@"
Press Any Key to Exit...");
            Console.ReadKey();
        }

        private static int getValidNumber()
        {
            string numberInStringInput = "";
            int number = -1;
            bool isNumber = false;
            string askForFirstNumber = string.Format("Please enter an {0} digit Number: ", k_NumOfDigits);
            string askForValidNumber = string.Format("Invalid input please enter an {0} digit Number: ", k_NumOfDigits);

            Console.WriteLine(askForFirstNumber);
            while (!isNumber || numberInStringInput.Length != 6)
            {
                numberInStringInput = Console.ReadLine();
                isNumber = int.TryParse(numberInStringInput, out number);
                if (!isNumber || numberInStringInput.Length != k_NumOfDigits)
                {
                    Console.WriteLine(askForValidNumber);
                }
            }

            return number;
        }

        private static byte getLargestDigitInNumber(int i_Number)
        {
            byte currentDigit = (byte)(i_Number % 10);
            byte maxDigit = currentDigit;

            i_Number /= 10;
            while (i_Number > 0)
            {
                currentDigit = (byte)(i_Number % 10);
                if (currentDigit > maxDigit)
                {
                    maxDigit = currentDigit;
                }
                i_Number /= 10;
            }

            return maxDigit;
        }

        private static byte getSmallestDigitInNumber(int i_Number)
        {
            byte currentDigit = (byte)(i_Number % 10);
            byte minDigit = currentDigit;
            i_Number /= 10;

            while (i_Number > 0)
            {
                currentDigit = (byte)(i_Number % 10);
                if (currentDigit < minDigit)
                {
                    minDigit = currentDigit;
                }
                i_Number /= 10;
            }

            return minDigit;
        }

        private static byte getNumberOfEvenDigitsInNumber(int i_Number)
        {
            byte evenDigitsCounter = 0;

            while (i_Number > 0)
            {
                byte currentDigit = (byte)(i_Number % 10);
                if (currentDigit % 2 == 0)
                {
                    evenDigitsCounter++;
                }
                i_Number /= 10;
            }
            return evenDigitsCounter;
        }

        private static byte getNumberOfSmallersDigits(int i_Number)
        {
            byte firstDigit = (byte)(i_Number % 10);
            byte currentDigit;
            byte smallerDigitsCounter = 0;

            i_Number /= 10;
            while (i_Number > 0)
            {
                currentDigit = (byte)(i_Number % 10);
                if (currentDigit < firstDigit)
                {
                    smallerDigitsCounter++;
                }
                i_Number /= 10;
            }

            return smallerDigitsCounter;
        }
    }
}