using System;
using System.Text;

namespace B18_Ex01_2
{
    public class Program
    {
        protected const int k_NumOfLines = 5;

        public static void Main(string[] args)
        {
            PrintHourglass(k_NumOfLines);
            Console.WriteLine(@"
Press Any Key to Exit...");
            Console.ReadKey();
        }

        public static void PrintHourglass(int i_Hight)
        {
            //if the Hourglass hight is even number we will increase it by one
            if (i_Hight % 2 == 0)
            {
                i_Hight += 1;
            }
            int numOfstars = i_Hight;
            StringBuilder starStringBuilder = new StringBuilder();

            //building  stars lines and append them to starStringBuilder
            for (int i = 0; i < i_Hight; i++)
            {
                //calculate the number of stars in the next desired line
                if (i != 0 && i <= i_Hight / 2)
                {
                    numOfstars -= 2;
                }
                else if (i != 0)
                {
                    numOfstars += 2;
                }
                //produce new stars line and append it to starStringBuilder
                starStringBuilder.Append(starsLineMaker(i_Hight, numOfstars));
                //move to new line in starStringBuilder after each line
                starStringBuilder.AppendLine();
            }

            Console.Write(starStringBuilder);
        }

        //produce new stars line of size i_lineSize with i_numOfStars stars in the middle
        private static string starsLineMaker(int i_LineSize, int i_NumOfStars)
        {
            StringBuilder starsLine = new StringBuilder();
            int numOfSpace = i_LineSize - i_NumOfStars;

            for (int i = 0; i < i_LineSize; i++)
            {
                //append space or star to the line - depand on the current index of i 
                //(i represent index of letter in the line)
                if (i < numOfSpace/2)
                {
                    starsLine.Append(' ');
                }
                else if (i >= i_LineSize - numOfSpace/2)
                {
                    starsLine.Append(' ');
                } 
                else
                {
                    starsLine.Append('*');
                }
            }
            
            return starsLine.ToString();
        }
    }
}
