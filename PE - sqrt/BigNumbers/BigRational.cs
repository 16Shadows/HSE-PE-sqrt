using System.Numerics;
using System;
using System.Globalization;

namespace PE___sqrt.BigNumbers
{
    //Represents a rational number with arbitrary precision. Immutable.
    struct BigRational : IComparable<BigRational>, IEquatable<BigRational>
    {
        public static readonly BigRational Zero = new BigRational(0, 1);
        public static readonly BigRational One = new BigRational(1, 1);
        public static readonly BigRational MinusOne = new BigRational(-1, 1);
        public static readonly BigRational Half = new BigRational(1, 2);
        public static readonly BigRational Two = new BigRational(2, 1);

        public bool IsZero
        {
            get
            {
                return numerator == 0;
            }
        }

        public bool Positive
        {
            get
            {
                return numerator > 0;
            }
        }

        public bool Negative
        {
            get
            {
                return numerator < 0;
            }
        }

        public BigRational Sign
        {
            get
            {
                return numerator == 0 ? Zero :
                       numerator > 0 ? One :
                       MinusOne;
            }
        }

        public BigRational SignNoZero
        {
            get
            {
                return numerator >= 0? One: MinusOne;
            }
        }

        private BigInteger numerator;
        private BigInteger denominator;

        //Construct a BigRational with value of num
        public BigRational(BigInteger num)
        {
            numerator = num;
            denominator = 1;
        }

        //Construct a BigRational with value of num/denum
        public BigRational(BigInteger num, BigInteger denum)
        {
            //Make sure that numerator is the negative part
            if(denum < 0)
            {
                numerator = num * -1;
                denominator = denum * -1;
            }
            else
            {
                numerator = num;
                denominator = denum;
            }
        }

        //Construct a BigRational from a string. No exception handling
        public BigRational(string str) : this(str, CultureInfo.InvariantCulture.NumberFormat) { }

        //Construct a BigRational from a string. No exception handling. Supports number format
        public BigRational(string str, NumberFormatInfo format)
        {
            BigRational res = Parse(str, format);
            numerator = res.numerator;
            denominator = res.denominator;
        }

        //Create BigRational from a double (or float). Not a constructor to avoid ambiguity between it and BigRational(BigInteger, BigInteger) for integers
        public static BigRational FromDouble(double value, int precision)
        {
            return new BigRational(new BigInteger(Math.Round(value, precision) * Math.Pow(10, precision)), BigInteger.Pow(10, precision));
        }

        //Reduce this big rational to its simplest form
        public void Reduce()
        {
            if(numerator == 0) return;

            BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);

            if(gcd > 1)
            {
                numerator /= gcd;
                denominator /= gcd;
            }
        }

        //Some data for parse() and tryparse()
        private static readonly char[] parseToTrim = { '0' };

        //Construct a BigRational from a string. No exception handling for underlying BigInteger.Parse() call
        public static BigRational Parse(string str, NumberFormatInfo format = null)
        {
            if(str == null || str.Length == 0) return Zero;

            //Remove spaces, leading and trailing zeroes and trailing decimal separators
            str = str.Replace(" ", "");

            if(str.Length == 0) return Zero;

            str = str.TrimStart(parseToTrim).TrimEnd(parseToTrim);
            
            if(str.Length == 0) return Zero;

            if(format == null) format = CultureInfo.CurrentCulture.NumberFormat;

            int index;
            while( (index = str.LastIndexOf(format.NumberDecimalSeparator)) == str.Length - format.NumberDecimalSeparator.Length )
                str = str.Remove(index);

            //If at this point the string is empty, it contained some variation of 0
            if(str.Length == 0) return Zero;

            BigRational result;

            //Remove number groups separators
            str = str.Replace(format.NumberGroupSeparator, "");

            //Find this number's decimal separator to convert it to for BigInteger/10^n
            index = str.IndexOf(format.NumberDecimalSeparator);

            if(index != -1)
            {
                str = str.Remove(index, format.NumberDecimalSeparator.Length);
                //Set denominator to 10^(number of digits after decimal separator)
                result.denominator = BigInteger.Pow(10, str.Length - index - format.NumberDecimalSeparator.Length + 1);
            }
            else result.denominator = 1;

            result.numerator = BigInteger.Parse(str, format);

            result.Reduce();

            return result;
        }

        //Construct a BigRational from a string. No exceptions thrown. Returns true on success. On failure, value of result is not defined
        public static bool TryParse(string str, out BigRational result, NumberFormatInfo format = null)
        {
            result = Zero;
            if(str == null || str.Length == 0) return false;

            //Remove spaces, leading and trailing zeroes and trailing decimal separators
            str = str.Replace(" ", "");

            if(str.Length == 0) return false;

            str = str.TrimStart(parseToTrim).TrimEnd(parseToTrim);
            
            if(str.Length == 0) return true;

            if(format == null) format = CultureInfo.CurrentCulture.NumberFormat;

            int index;
            while( (index = str.LastIndexOf(format.NumberDecimalSeparator)) == str.Length - format.NumberDecimalSeparator.Length )
                str = str.Remove(index);

            //If at this point the string is empty, it contained some variation of 0
            if(str.Length == 0) return true;

            //Remove number groups separators
            str = str.Replace(format.NumberGroupSeparator, "");

            //Find this number's decimal separator to convert it to for BigInteger/10^n
            index = str.IndexOf(format.NumberDecimalSeparator);

            if(index != -1)
            {
                str = str.Remove(index, format.NumberDecimalSeparator.Length);
                //Set denominator to 10^(number of digits after decimal separator)
                result.denominator = BigInteger.Pow(10, str.Length - index - format.NumberDecimalSeparator.Length + 1);
            }
            else result.denominator = 1;

            if(!BigInteger.TryParse(str, NumberStyles.Integer, format, out result.numerator)) return false;
            
            result.Reduce();

            return true;
        }

        //Reduce this big rational to its simplest form
        public static BigRational Reduce(BigRational value)
        {
            if(value.numerator == 0) return Zero;

            BigInteger gcd = BigInteger.GreatestCommonDivisor(value.numerator, value.denominator);

            return gcd>1?
                new BigRational(value.numerator/gcd, value.denominator/gcd) :
                new BigRational(value.numerator, value.denominator);
        }

        public static BigRational operator-(BigRational value)
        {
            return new BigRational(-value.numerator, value.denominator);
        }

        public static BigRational operator+(BigRational lhs, BigRational rhs)
        {
            BigRational result = new BigRational();

            result.numerator = lhs.numerator * rhs.denominator + rhs.numerator * lhs.denominator;
            result.denominator = lhs.denominator * rhs.denominator;

            result.Reduce();

            return result;
        }

        public static BigRational operator-(BigRational lhs, BigRational rhs)
        {
            BigRational result = new BigRational();

            result.numerator = lhs.numerator * rhs.denominator - rhs.numerator * lhs.denominator;
            result.denominator = lhs.denominator * rhs.denominator;

            result.Reduce();

            return result;
        }

        public static BigRational operator*(BigRational lhs, BigRational rhs)
        {
            BigRational result = new BigRational();

            result.numerator = lhs.numerator * rhs.numerator;
            result.denominator = lhs.denominator * rhs.denominator;

            result.Reduce();

            return result;
        }

        public static BigRational operator/(BigRational lhs, BigRational rhs)
        {
            BigRational result = new BigRational();

            result.numerator = lhs.numerator * rhs.denominator;
            result.denominator = lhs.denominator * rhs.numerator;

            result.Reduce();

            return result;
        }

        public int CompareTo(BigRational other)
        {
            BigInteger t1 = numerator * other.denominator,
                       t2 = denominator *other.numerator;

            if(t1 == t2) return 0;
            else if(t1 > t2) return 1;
            else return -1;
        }

        public bool Equals(BigRational other)
        {
            BigRational t1 = Reduce(this),
                        t2 = Reduce(other);

            return t1.numerator == t2.numerator && t1.denominator == t2.denominator;
        }

        //Find square of the value
        public static BigRational Sqr(BigRational value)
        {
            return new BigRational(value.numerator*value.numerator, value.denominator*value.denominator);
        }

        //Find square root of the value
        public static BigRational Sqrt(BigRational value, int precision = 0)
        {
            if(value.IsZero) return Zero;
            else if(value < Zero) throw new ArithmeticException("Attempted to find square root of a negative BigRational. Use BigComplex instead.");

            precision += 2;

            //Step 1 - shift *precision* digits to the left
            BigInteger decimals = BigInteger.Divide( value.numerator * BigInteger.Pow(10, precision*2), value.denominator );

            //Step 2 - calculate sqrt of decimals digit by digit
            double ddigits = BigInteger.Log10(decimals);

            if(ddigits > Int32.MaxValue) return Zero;
            int digits = ((int)ddigits) - 1;

            BigInteger divisor = BigInteger.Pow(10, digits%2==0?digits:digits+1);
            BigInteger temp;
            BigInteger temp2;
            BigInteger temp3;
            BigInteger sqrtValue;

            int digit;

            //Used algorithm: https://en.wikipedia.org/wiki/Methods_of_computing_square_roots#Digit-by-digit_calculation

            temp = BigInteger.DivRem(decimals, divisor, out decimals);
            divisor /= 100;
            sqrtValue = (int)Math.Sqrt((int)temp);
            temp -= sqrtValue * sqrtValue;

            int i = 0;
            for(; i < digits; i += 2)
            {
                temp = temp * 100 + BigInteger.DivRem(decimals, divisor, out decimals);
                divisor /= 100;
                temp2 = sqrtValue * 20;
                digit = 0;
                do
                {
                    ++digit;
                    temp3 = (temp2 + digit) * digit;
                }
                while( temp >= temp3 );
                --digit;
                temp -= (temp2 + digit) * digit;
                sqrtValue = sqrtValue*10 + digit;
            }

            //Step 3 - return result
            return Reduce(new BigRational(sqrtValue, BigInteger.Pow(10, precision)));
        }

        //Return absolute value of the value
        public static BigRational Abs(BigRational value)
        {
            //Since numerator and denominator are hidden from access and other methods guarantee that 
            return new BigRational(BigInteger.Abs(value.numerator), value.denominator);
        }

        public static bool operator>(BigRational lhs, BigRational rhs)
        {
            return lhs.CompareTo(rhs)==1;
        }
        public static bool operator<(BigRational lhs, BigRational rhs)
        {
            return lhs.CompareTo(rhs)==-1;
        }

        public static bool operator>=(BigRational lhs, BigRational rhs)
        {
            return lhs.CompareTo(rhs)!=-1;
        }

        public static bool operator<=(BigRational lhs, BigRational rhs)
        {
            return lhs.CompareTo(rhs)!=1;
        }

        //Return rational representation of this BigRational (a/b format)
        public string ToRationalString()
        {
            return $"{numerator} / {denominator}";
        }

        //Return decimal representation of this BigRational with *precision* digits after decimal separator
        public string ToString(int precision = 0, NumberFormatInfo format = null)
        {
            if(format == null) format = CultureInfo.CurrentCulture.NumberFormat;
            if(precision < 0) precision = 0;

            BigRational value = Abs(this);

            string result = "";

            if(this < Zero) result += '-';

            BigInteger remainder;
            BigInteger quotient = BigInteger.DivRem(value.numerator, value.denominator, out remainder);

            if(precision > 0 && remainder > 0)
            {
                int digits;
                if(quotient > 0)
                {
                    digits = (int)Math.Floor(BigInteger.Log10(quotient));
                    quotient = BigInteger.Divide( value.numerator * BigInteger.Pow(10, precision), value.denominator );
                    result += quotient.ToString(CultureInfo.InvariantCulture);
                    result = result.Insert(digits + (this<Zero?2:1), format.NumberDecimalSeparator).TrimEnd(parseToTrim);
                }
                else
                {
                    result += "0" + format.NumberDecimalSeparator;
                    quotient = BigInteger.Divide( value.numerator * BigInteger.Pow(10, precision), value.denominator );
                    digits = (int)Math.Floor(BigInteger.Log10(quotient));
                    result += new string('0', precision - digits - 1);
                    result += quotient.ToString().TrimEnd(parseToTrim);
                }
            }
            else result += quotient.ToString(format);

            return result;
        }
    }
}
