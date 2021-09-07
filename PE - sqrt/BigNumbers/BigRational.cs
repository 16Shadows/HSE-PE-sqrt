using System.Numerics;
using System;
using System.Globalization;

namespace PE___sqrt.BigNumbers
{
    class BigRational : IComparable<BigRational>, IEquatable<BigRational>
    {
        public static readonly BigRational Zero = new BigRational(0, 1);
        public static readonly BigRational One = new BigRational(1, 1);
        public static readonly BigRational MinusOne = new BigRational(-1, 1);
        public static readonly BigRational Half = new BigRational(1, 2);
        public static readonly BigRational Two = new BigRational(2, 1);

        private BigInteger numerator;
        private BigInteger denominator;

        public BigRational()
        {
            numerator = 0;
            denominator = 1;
        }

        public BigRational(BigInteger num)
        {
            numerator = num;
            denominator = 1;
        }

        public BigRational(BigInteger num, BigInteger denum)
        {
            if(denominator < 0)
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

        public BigRational(BigRational other)
        {
            numerator = other.numerator;
            denominator = other.denominator;
        }

        public BigRational(string str)
        {
            BigRational res = Parse(str);
            numerator = res.numerator;
            denominator = res.denominator;
        }

        public static BigRational FromDouble(double value, int precision)
        {
            precision = precision>99?99:precision<0?0:precision;

            string str = value.ToString("F"+precision, CultureInfo.InvariantCulture);

            BigRational res = Parse(str);
            return res;
        }

        public BigRational Reduce()
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);

            if(gcd > 1)
            {
                numerator /= gcd;
                denominator /= gcd;
            }
            
            return this;
        }

        private static readonly char[] parseToTrim1 = { '0' };
        private static readonly char[] parseToTrim2 = { '.' };

        public static BigRational Parse(string str)
        {
            BigRational result = new BigRational();

            str = str.Trim().TrimEnd(parseToTrim1).TrimEnd(parseToTrim2);

            int index = str.IndexOf('.');

            if(index != -1)
            {
                str = str.Remove(index, 1);
                result.denominator = BigInteger.Pow(10, str.Length - index);
            }
            else result.denominator = 1;

            result.numerator = BigInteger.Parse(str, CultureInfo.InvariantCulture);

            result.Reduce();

            return result;
        }

        public static bool TryParse(string str, out BigRational result)
        {
            result = new BigRational();

            str = str.Trim().TrimEnd(parseToTrim1).TrimEnd(parseToTrim2);

            int index = str.IndexOf('.');

            if(index != -1)
            {
                str = str.Remove(index, 1);
                result.denominator = BigInteger.Pow(10, str.Length - index);
            }
            else result.denominator = 1;

            if(!BigInteger.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out result.numerator)) return false;            

            result.Reduce();

            return true;
        }

        public static BigRational Reduce(BigRational value)
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(value.numerator, value.denominator);

            return gcd>1?
                new BigRational(value.numerator/gcd, value.denominator/gcd) :
                new BigRational(value.numerator, value.denominator);
        }

        public static BigRational operator+(BigRational lhs, BigRational rhs)
        {
            BigRational result = new BigRational();

            result.numerator = lhs.numerator * rhs.denominator + rhs.numerator * lhs.denominator;
            result.denominator = lhs.denominator * rhs.denominator;

            result.Reduce();

            return result;
        }

        public BigRational Add(BigRational rhs, bool reduce = true)
        {
            numerator = numerator * rhs.denominator + denominator * rhs.numerator;
            denominator *= rhs.denominator;
            if(reduce) Reduce();
            return this;
        }

        public static BigRational operator-(BigRational lhs, BigRational rhs)
        {
            BigRational result = new BigRational();

            result.numerator = lhs.numerator * rhs.denominator - rhs.numerator * lhs.denominator;
            result.denominator = lhs.denominator * rhs.denominator;

            result.Reduce();

            return result;
        }

        public BigRational Subtract(BigRational rhs, bool reduce = true)
        {
            numerator = numerator * rhs.denominator - denominator * rhs.numerator;
            denominator *= rhs.denominator;
            if(reduce) Reduce();
            return this;
        }

        public static BigRational operator*(BigRational lhs, BigRational rhs)
        {
            BigRational result = new BigRational();

            result.numerator = lhs.numerator * rhs.numerator;
            result.denominator = lhs.denominator * rhs.denominator;

            result.Reduce();

            return result;
        }
        
        public BigRational Multiply(BigRational rhs, bool reduce = true)
        {
            numerator *= rhs.numerator;
            denominator *= rhs.denominator;
            if(reduce) Reduce();
            return this;
        }

        public static BigRational operator/(BigRational lhs, BigRational rhs)
        {
            BigRational result = new BigRational();

            result.numerator = lhs.numerator * rhs.denominator;
            result.denominator = lhs.denominator * rhs.numerator;

            result.Reduce();

            return result;
        }

        public BigRational Divide(BigRational rhs, bool reduce = true)
        {
            numerator *= rhs.denominator;
            denominator *= rhs.numerator;
            if(reduce) Reduce();
            return this;
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

        public BigRational Sqr()
        {
            numerator *= numerator;
            denominator *= denominator;
            return this;
        }

        public static BigRational Sqr(BigRational value)
        {
            return new BigRational(value.numerator*value.numerator, value.denominator*value.denominator);
        }

        public static BigRational Sqrt(BigRational value, int precision = 0)
        {
            BigRational result = new BigRational();

            //Step 1 - shift
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
            return new BigRational(sqrtValue, BigInteger.Pow(10, precision)).Reduce();
        }

        public static BigRational Abs(BigRational value)
        {
            return new BigRational(BigInteger.Abs(value.numerator), value.denominator);
        }

        public BigRational Abs()
        {
            numerator = BigInteger.Abs(numerator);
            return this;
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

        public string ToRationalString()
        {
            return $"{numerator} / {denominator}";
        }

        public string ToString(int precision = 0)
        {
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
                    result = result.Insert(this<Zero?digits+2:digits+1, ".").TrimEnd(parseToTrim1);
                }
                else
                {
                    result += "0.";
                    quotient = BigInteger.Divide( value.numerator * BigInteger.Pow(10, precision), value.denominator );
                    digits = (int)Math.Floor(BigInteger.Log10(quotient));
                    result += new string('0', precision - digits - 1);
                    result += quotient.ToString().TrimEnd(parseToTrim1);
                }
            }
            else result += quotient.ToString(CultureInfo.InvariantCulture);

            return result;
        }
    }
}
