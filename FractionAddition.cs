/* Converting two single precesion Floating point Numbers To Binary, Adding these binary and converting the resulted binary to Floationg point Number */
using System;
namespace Program
{
    class Demo
    {
        public static void Main(string[] args)
        {
            int ForwardedCarry, CarryBit = 0;
            string DecimalPart1, FractionalPart1, DecimalPart2, FractionalPart2;
            float Num1, Num2, N1, N2;
            Double DecimalResult, FractionResult, FinalResult;

            //Reading inputs from Console   
            Console.WriteLine("Enter Num1");
            Num1 = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter Num2");
            Num2 = Convert.ToSingle(Console.ReadLine());

            //converting decimal parts and fractional parts to Binary 
            N1 = Num1;
            N2 = Num2;
            if (N1 < 0)
            {
                N1 = N1 * -1;
            }
            if (N2 < 0)
            {
                N2 = N2 * -1;
            }
            DecimalPart1 = ConvertDecimalPartToBinary(N1);
            DecimalPart2 = ConvertDecimalPartToBinary(N2);
            FractionalPart1 = ConvertFractionalPartToBinary(N1);
            FractionalPart2 = ConvertFractionalPartToBinary(N2);

            //Converting Binary values stored as Strings to Character arrays for easier manipulation
            char[] DecPart1 = DecimalPart1.ToCharArray();
            char[] DecPart2 = DecimalPart2.ToCharArray();
            char[] FracPart1 = FractionalPart1.ToCharArray();
            char[] FracPart2 = FractionalPart2.ToCharArray();

            //Appending 0's to Binary numbers to make them of equal Length
            if (DecPart1.Length > DecPart2.Length)
            {
                DecPart2 = SetLength(DecPart1, DecPart2);
            }
            else if (DecPart1.Length < DecPart2.Length)
            {
                DecPart1 = SetLength(DecPart2, DecPart1);
            }

            if (Num1 >= 0 && Num2 >= 0 || Num2 <= 0 && Num1 <= 0)
            {
                //Addition Of Binary
                char[] BinaryFractionResult = BinaryAddition(FracPart1, FracPart2, CarryBit, out ForwardedCarry);

                //fowarading leftover carry for Decimal Conversion
                if (ForwardedCarry == 1)
                {
                    CarryBit = 1;
                    ForwardedCarry = 0;
                }
                //Adding Binary values of Decimal part
                char[] BinaryDecimalResult = BinaryAddition(DecPart1, DecPart2, CarryBit, out ForwardedCarry);
                if (ForwardedCarry == 1)
                {
                    Array.Resize(ref BinaryDecimalResult, BinaryDecimalResult.Length + 1);
                    BinaryDecimalResult[BinaryDecimalResult.Length - 1] = '1';
                }

                //Converting Decimal and printing Result
                DecimalResult = BinaryToDecimal(BinaryDecimalResult);
                FractionResult = BinaryToFraction(BinaryFractionResult);
                FinalResult = DecimalResult + FractionResult;
            }
            else
            {
                //Subtraction of Binary
                char[] SubtractionFracResult;
                char[] SubtractionResult;
                if (N2 > N1)
                {
                    SubtractionResult = BinarySubtraction(DecPart2, DecPart1);
                }
                else
                {
                    SubtractionResult = BinarySubtraction(DecPart1, DecPart2);
                }
                DecimalResult = BinaryToDecimal(SubtractionResult);
                if (N2 % 1 > N1 % 1)
                {
                    SubtractionFracResult = BinarySubtraction(FracPart2, FracPart1);
                    FractionResult = BinaryToFraction(SubtractionFracResult);
                    FractionResult = 1 - FractionResult;
                    DecimalResult -= 1;
                }
                else if (N2 > N1)
                {
                    SubtractionFracResult = BinarySubtraction(FracPart1, FracPart2);
                    FractionResult = BinaryToFraction(SubtractionFracResult);
                    FractionResult = 1 - FractionResult;
                    DecimalResult -= 1;
                }
                else
                {
                    SubtractionFracResult = BinarySubtraction(FracPart1, FracPart2);
                    FractionResult = BinaryToFraction(SubtractionFracResult);
                }
                FinalResult = DecimalResult + FractionResult;
                if (Num1 < 0 && Num1 * -1 > Num2)
                {
                    FinalResult *= -1;
                }
                else if (Num2 < 0 && Num2 * -1 > Num1)
                {
                    FinalResult *= -1;
                }
            }
            Console.WriteLine(FinalResult);
            Console.ReadKey();
        }
        public static char[] SetLength(char[] Temp1, char[] Temp2)
        {
            int BitLengthDifference = Temp1.Length - Temp2.Length;
            while (BitLengthDifference > 0)
            {
                BitLengthDifference--;
                Array.Resize(ref Temp2, Temp2.Length + 1);
                Temp2[Temp2.Length - 1] = '0';
            }
            return Temp2;
        }
        public static string ConvertDecimalPartToBinary(float Decimal_Num)
        {
            //Decimal To Binary
            Decimal_Num = (int)Decimal_Num;
            string buffer = "";
            while (Decimal_Num >= 1)
            {
                buffer += (Decimal_Num % 2);
                Decimal_Num = (int)Decimal_Num / 2;
            }
            return buffer;
        }
        static string ConvertFractionalPartToBinary(float Fraction_Num)
        {
            //Fraction To Binary
            Fraction_Num = Fraction_Num % 1;
            int count = 0;
            string buffer = "";
            while (Fraction_Num % 1 != 0 && count < 64)
            {
                if (Fraction_Num * 2 >= 1)
                {
                    buffer = 1 + buffer;
                }
                else
                {
                    buffer = 0 + buffer;
                }
                Fraction_Num = Fraction_Num * 2;
                Fraction_Num = Fraction_Num % 1;
                count++;
            }
            if (count < 64)
            {
                while (count < 64)
                {
                    buffer = 0 + buffer;
                    count++;
                }
            }
            return buffer;
        }
        public static char[] BinaryAddition(char[] Binary_Num1, char[] Binary_Num2, int carry, out int ForwardedCarry)
        {
            //Adding Binary Values
            char[] res = new char[0];
            int xlength = Binary_Num1.Length, i = 0;
            while (xlength > 0 && carry < 64)
            {
                Array.Resize(ref res, res.Length + 1);
                if ((Binary_Num1[i] + Binary_Num2[i] + carry) - 96 == 0)
                {
                    res[i] = '0';
                    carry = 0;
                }
                else if ((Binary_Num1[i] + Binary_Num2[i] + carry) - 96 == 1)
                {
                    res[i] = '1';
                    carry = 0;
                }
                else if ((Binary_Num1[i] + Binary_Num2[i] + carry) - 96 == 2)
                {
                    res[i] = '0';
                    carry = 1;

                }
                else if ((Binary_Num1[i] + Binary_Num2[i] + carry) - 96 == 3)
                {
                    res[i] = '1';
                    carry = 1;
                }
                xlength--;
                i++;
            }
            if (carry == 1)
            {
                ForwardedCarry = 1;
            }
            else
            {
                ForwardedCarry = 0;
            }
            return res;
        }
        public static double BinaryToDecimal(char[] Binary)
        {
            //Converting DecimalPart(Binary) To Decimal
            double Decimal = 0;
            for (int i = 0; i < Binary.Length; i++)
            {
                Decimal += PowerBase2(i) * (Binary[i] - 48);
            }
            return Decimal;
        }
        public static double BinaryToFraction(char[] Fraction_Binary)
        {
            //Converting FractionPart(Binary) To Decimal
            double Fraction_Value = 0;
            int power = -1;
            for (int i = Fraction_Binary.Length - 1; i > 0; i--)
            {
                Fraction_Value += PowerBase2(power) * (Fraction_Binary[i] - 48);
                power--;
            }
            return Fraction_Value;
        }
        public static char[] BinarySubtraction(char[] Binary_Num1, char[] Binary_Num2)
        {
            char[] Subtracted = new char[0];
            int i = 0, j;
            while (i < Binary_Num1.Length)
            {
                Array.Resize(ref Subtracted, Subtracted.Length + 1);
                if (Binary_Num1[i] == '0' && Binary_Num2[i] == '0')
                {
                    Subtracted[i] = '0';
                }
                else if (Binary_Num1[i] == '1' && Binary_Num2[i] == '0')
                {
                    Subtracted[i] = '1';
                }
                else if (Binary_Num1[i] == '1' && Binary_Num2[i] == '1')
                {
                    Subtracted[i] = '0';
                }
                else if (Binary_Num1[i] == '0' && Binary_Num2[i] == '1')
                {
                    j = i;
                    while (Binary_Num1[j] != '1')
                    {
                        j++;
                    }
                    Binary_Num1[j] = '0';
                    j--;
                    while (j != i)
                    {
                        Binary_Num1[j] = '1';
                        j--;
                    }
                    Subtracted[i] = '1';
                }
                i++;
            }
            return Subtracted;
        }
        public static float PowerBase2(int x)
        {
            //Caclulating power with base 2
            int b = 2;
            float y = 1;
            while (x != 0)
            {
                if (x > 0)
                {
                    y = y * b;
                    x--;
                }
                else if (x < 0)
                {
                    y = y / 2;
                    x++;
                }
            }
            return y;
        }
    }
}