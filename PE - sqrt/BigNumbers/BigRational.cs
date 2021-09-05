using System.Numerics;
using System.Collections.Generic;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PE___sqrt.BigNumbers
{
    struct BigRational : IComparable<BigRational>, IEquatable<BigRational>
    {
        public static readonly BigRational Zero = new BigRational(0, 1);
        public static readonly BigRational One = new BigRational(1, 1);
        public static readonly BigRational MinusOne = new BigRational(-1, 1);
        public static readonly BigRational Half = new BigRational(1, 2);

        private BigInteger numerator;
        private BigInteger denominator;

        public BigRational(BigInteger num)
        {
            numerator = num;
            denominator = 1;
        }

        public BigRational(BigInteger num, BigInteger denum)
        {
            numerator = num;
            denominator = denum;
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

            string str = value.ToString("F"+precision);

            BigRational res = Parse(str);
            return res;
        }

        public void Reduce()
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);

            if(gcd > 1)
            {
                numerator /= gcd;
                denominator /= gcd;
            }
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

        public double SqrtFast()
        {
            return (Math.Pow(10, BigInteger.Log10(numerator)/2))/(Math.Pow(10, BigInteger.Log10(denominator)/2));
        }

        public BigRational Sqrt()
        {
            BigRational result = new BigRational();
            result.denominator = 1;

            double log = BigInteger.Log10(numerator)/2;

            if(log > Int32.MaxValue) return Zero;
            
            int whole = (int)Math.Floor(log);
            log -= whole;

            result.numerator = BigInteger.Pow(10, whole);
            BigRational extra = BigRational.FromDouble(Math.Pow(10, log), 99);
            result.Multiply(extra);

            log = BigInteger.Log10(denominator)/2;

            if(log > Int32.MaxValue) return Zero;
            
            whole = (int)Math.Floor(log);
            log -= whole;

            extra.numerator = BigInteger.Pow(10, whole);
            extra.denominator = 1;
            BigRational extra2 = BigRational.FromDouble(Math.Pow(10, log), 99);
            extra.Multiply(extra2);

            result.Divide(extra);

            return result;
        }

        //Arbitrary precision and input size but very slow
        public BigRational SqrtNewton(int precision = 0)
        {
            BigRational delta = new BigRational(1, BigInteger.Pow(10, precision));
            BigRational result = BigRational.FromDouble(BigInteger.Log(numerator) - BigInteger.Log(denominator), 99);
            BigRational square = Sqr(result);
            square.Subtract(this);
            square.Abs();
            BigRational temp;

            while( square > delta )
            {
                temp = this;
                temp.Divide(result, false);
                temp.Add(result, false);
                temp.Multiply(Half);
                square = result = temp;
                square.Sqr();
                square.Subtract(this, false);
                square.Abs();
            }
            
            return result;
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

        public string ToString(int precision = 0)
        {
            string result;

            BigInteger remainder;
            BigInteger quotient = BigInteger.DivRem(numerator, denominator, out remainder);

            if(precision > 0 && remainder > 0)
            {
                int digits = (int)Math.Floor(BigInteger.Log10(quotient));

                quotient = BigInteger.Divide( numerator * BigInteger.Pow(10, precision), denominator );

                result = quotient.ToString(CultureInfo.InvariantCulture);
                result = result.Insert(digits+1, ".").TrimEnd(parseToTrim1);
            }
            else result = quotient.ToString(CultureInfo.InvariantCulture);

            return result;
        }
    }
}
