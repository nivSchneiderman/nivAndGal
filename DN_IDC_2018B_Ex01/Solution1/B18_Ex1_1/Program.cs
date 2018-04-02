using System;

namespace B18_Ex1_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] threeBinaryNumbers = new int[3];
            short[] threeDecimalNumbers = new short[3];
            string[] numPosition = { "first", "second", "third" };
            for (int currentNum = 0; currentNum < 3; currentNum++)
            { // initialize the binary and decimal arrays

                System.Console.WriteLine(string.Format("Please enter the {0} number:",
                    numPosition[currentNum]));
                threeBinaryNumbers[currentNum] = legalNumInput();
                System.Console.WriteLine("Thank you!");
                threeDecimalNumbers[currentNum] = convertToDecimal(threeBinaryNumbers[currentNum]);
            }
            byte averageOnes = countAverageOnes(threeBinaryNumbers);
            byte averageZeroes = (byte)(9 - averageOnes);
            string toPrint = string.Format(
                @"Average Zeroes: {0}
Average Ones: {1}
{2} numbers are power of 2
{3} numbers are a descending sequence
Average of the three numbers: {4}.", averageZeroes, averageOnes, countPowerOf2(threeDecimalNumbers),
                countDescendingSequence(threeDecimalNumbers), averageOfDecimalNumbers(threeDecimalNumbers));
            System.Console.WriteLine(toPrint);
            System.Console.ReadLine();
        }

        // converts the binary formatted number given to a decimal number
        private static short convertToDecimal(int i_BinaryNum)
        {
            short decimalNum = 0;
            for (int degreeOfPower = 0; i_BinaryNum > 0; degreeOfPower++)
            {
                if (i_BinaryNum % 2 == 1)
                { // the conversion from binary to decimal
                    decimalNum = (short)(decimalNum + (short)Math.Pow(2, degreeOfPower));
                }
                i_BinaryNum /= 10;
            }
            return decimalNum;
        }

        // computes the average value of the numbers in the given array
        private static float averageOfDecimalNumbers(short[] i_ThreeDecimalNumbers)
        {
            float averageOfDecimalNumbers = 0f;
            for (int currentNum = 0; currentNum < i_ThreeDecimalNumbers.Length; currentNum++)
            {
                averageOfDecimalNumbers += (float)i_ThreeDecimalNumbers[currentNum];
            }
            return averageOfDecimalNumbers / (float)i_ThreeDecimalNumbers.Length;
        }

        // counts how many numbers in the given array have a desceding sequence of digits
        private static byte countDescendingSequence(short[] i_ThreeDecimalNumbers)
        {
            byte numOfDescendingSequences = 0;
            for (int currentNumIndex = 0; currentNumIndex < i_ThreeDecimalNumbers.Length; currentNumIndex++)
            {
                bool descending = true;
                short currentNum = i_ThreeDecimalNumbers[currentNumIndex];
                while (descending && currentNum >= 10)
                {
                    if ((currentNum % 10) >= ((currentNum / 10) % 10))
                    {
                        descending = false;
                    }
                    currentNum /= 10;
                }
                if (descending)
                {
                    numOfDescendingSequences++;
                }
            }
            return numOfDescendingSequences;
        }

        // counts how many numbers in the given array are equal to a power of 2, up to 2^9(9 digits in binary)
        private static byte countPowerOf2(short[] i_ThreeDecimalNumbers)
        {
            byte numOfPower2 = 0;
            for (int currentNumIndex = 0; currentNumIndex < i_ThreeDecimalNumbers.Length; currentNumIndex++)
            {
                for (int currentPower = 0; currentPower < 10; currentPower++)
                { // checks if the number is 2^0,2^1,...,up to 2^9
                    if (i_ThreeDecimalNumbers[currentNumIndex] == Math.Pow(2, currentPower))
                    {
                        numOfPower2++;
                        break;
                    }
                }
            }
            return numOfPower2;
        }

        // counts the average number of '1' of the numbers in the given array
        private static byte countAverageOnes(int[] i_ThreeBinaryNumbers)
        {
            byte countAverageOnes = 0;
            for (int currentNumIndex = 0; currentNumIndex < i_ThreeBinaryNumbers.Length; currentNumIndex++)
            {
                int currentNum = i_ThreeBinaryNumbers[currentNumIndex];
                while (currentNum > 0)
                { // each time we check if the digit is even or not, which in binary is equal to '1' or '0'.
                    if (currentNum % 2 == 1)
                    {
                        countAverageOnes++;
                    }
                    currentNum /= 10;
                }
            }
            return (byte)(countAverageOnes / 3);
        }

        // checks whether the given input is legal: a binary number with size 9.
        private static int legalNumInput()
        {
            int legalNum = 0;
            bool goodInput = false;
            while (!goodInput)
            {
                String inputString = System.Console.ReadLine();
                goodInput = int.TryParse(inputString, out legalNum);
                int length = inputString.Length;
                for (int currentIndex = 0; currentIndex < 9; currentIndex++)
                {
                    if ((length != 9) || 
                        (inputString[currentIndex] != '0' && inputString[currentIndex] != '1'))
                    {
                        goodInput = false;
                        System.Console.WriteLine("Please enter a legal number");
                        break;
                    }
                }
            }

            return legalNum;
        }

    }
}
