using System;
using System.Linq;
using System.Globalization;

namespace PE___sqrt.BigNumbers
{
    //Represents a complex number with arbitrary precision. Immutable
    struct BigComplex : IEquatable<BigComplex>
    {
        public static readonly BigComplex Zero = new BigComplex(BigRational.Zero, BigRational.Zero);

        public bool IsZero
        {
            get
            {
                return real.IsZero && imaginary.IsZero;
            }
        }

        private BigRational real;
        private BigRational imaginary;

        //Construct a BigComplex from real and imaginary parts
        public BigComplex(BigRational re, BigRational im)
        {
            real = re;
            imaginary = im;
        }

        //Construct a BigComplex from a string. No exception handling for underlying BigRational.Parse() calls
        public static BigComplex Parse(string str, NumberFormatInfo format = null)
        {
            if(str == null || str.Length == 0) return Zero;

            //Remove spaces
            str = str.Replace(" ", "");

            if(str.Length == 0) return Zero;

            int index = str.IndexOf('i');

            if(format == null) format = CultureInfo.CurrentCulture.NumberFormat;

            //No imaginary unit (thus no imaginary part
            if(index == -1) 
                return new BigComplex(BigRational.Parse(str), BigRational.Zero);
            else
            {
                //Imaginary unit is present
                int index2 = str.IndexOf('+');
                if(index2 == -1) index2 = str.IndexOf('-');

                if(index2 == -1)
                {
                    //No real part
                    if(index != str.Length - 1) throw new FormatException("Invalid complex number format!");
                    str = str.Remove(index, 1);
                    return new BigComplex(BigRational.Zero, BigRational.Parse(str));
                }
                else
                {
                    //Imaginary goes before real
                    if(index < index2)
                    {
                        string imComp = str.Substring(0, index);
                        BigRational im;
                        if(imComp.Length == 0) im = BigRational.One;
                        else if(imComp.Length == 1)
                        {
                            if(imComp.Equals('+')) im = BigRational.One;
                            else if(imComp.Equals('-')) im = BigRational.MinusOne;
                            else im = BigRational.Parse(imComp);
                        }
                        else im = BigRational.Parse(imComp);
                        return new BigComplex( BigRational.Parse(str.Substring(index2)), im );
                    }
                    //Real goes before imaginary
                    else
                    {
                        string imComp = str.Substring(index2, index-index2);
                        BigRational im;
                        if(imComp.Length == 0) im = BigRational.One;
                        else if(imComp.Length == 1)
                        {
                            if(imComp.Equals('+')) im = BigRational.One;
                            else if(imComp.Equals('-')) im = BigRational.MinusOne;
                            else im = BigRational.Parse(imComp);
                        }
                        else im = BigRational.Parse(imComp);
                        return new BigComplex( BigRational.Parse(str.Substring(0, index2)), im);
                    }
                        
                }
            }
        }

        //Construct a BigComlex from a string. No exceptions thrown. Returns true on success. On failure, value of result is not defined
        public static bool TryParse(string str, out BigComplex result, NumberFormatInfo format = null)
        {
            result = Zero;
            if(str == null || str.Length == 0) return false;

            //Remove spaces
            str = str.Replace(" ", "");

            if(str.Length == 0) return false;

            if( str.Count( x => { return x == 'i'; } ) > 1 || str.Count( x => { return x == '+'; } ) + str.Count( x => { return x == '-'; } ) > 2 ) return false;

            int index = str.IndexOf('i');

            //No imaginary unit (thus no imaginary part
            if(index == -1)
                return BigRational.TryParse(str, out result.real, format);
            else
            {
                //Imaginary unit is present
                int index2 = str.LastIndexOf('+');
                int index3 = str.LastIndexOf('-');

                if(index3 > index2) index2 = index3;

                if(index2 == -1)
                {
                    if(index != str.Length - 1) return false;

                    //No real part
                    str = str.Remove(index, 1);
                    
                    return BigRational.TryParse(str, out result.imaginary, format);
                }
                else
                {
                    if(index < index2)
                    {
                        //Imaginary goes before real

                        string imComp = str.Substring(0, index);
                        if(imComp.Length == 0) result.imaginary = BigRational.One;
                        else if(imComp.Length == 1)
                        {
                            if(imComp.IndexOf('+') == 0) result.imaginary = BigRational.One;
                            else if(imComp.IndexOf('-') == 0) result.imaginary = BigRational.MinusOne;
                            else if(!BigRational.TryParse(imComp, out result.imaginary, format)) return false;
                        }
                        else if(!BigRational.TryParse(imComp, out result.imaginary, format)) return false;

                        return BigRational.TryParse(str.Substring(index2), out result.real, format);
                    }
                    else
                    {
                        //Real goes before imaginary
                        
                        string imComp = str.Substring(index2, index-index2);
                        Console.WriteLine(imComp);
                        if(imComp.Length == 0) result.imaginary = BigRational.One;
                        else if(imComp.Length == 1)
                        {
                            if(imComp.IndexOf('+') == 0) result.imaginary = BigRational.One;
                            else if(imComp.IndexOf('-') == 0) result.imaginary = BigRational.MinusOne;
                            else if(!BigRational.TryParse(imComp, out result.imaginary, format)) return false;
                        }
                        else if(!BigRational.TryParse(imComp, out result.imaginary, format)) return false;

                        return BigRational.TryParse(str.Substring(0, index2), out result.real, format);
                    }
                }
            }
        }

        public static BigComplex operator-(BigComplex value)
        {
            return new BigComplex(-value.real, -value.imaginary);
        }

        public static BigComplex operator+(BigComplex lhs, BigComplex rhs)
        {
            return new BigComplex(lhs.real + rhs.real, lhs.imaginary + rhs.imaginary);
        }

        public static BigComplex operator-(BigComplex lhs, BigComplex rhs)
        {
            return new BigComplex(lhs.real - rhs.real, lhs.imaginary - rhs.imaginary);
        }

        public static BigComplex operator*(BigComplex lhs, BigComplex rhs)
        {
            return new BigComplex( lhs.real * rhs.real - lhs.imaginary * rhs.imaginary, rhs.real * lhs.imaginary + lhs.real * rhs.imaginary );
        }

        public static BigComplex operator/(BigComplex lhs, BigComplex rhs)
        {
            return new BigComplex( lhs.real * rhs.real + lhs.imaginary * rhs.imaginary, rhs.real * lhs.imaginary - lhs.real * rhs.imaginary );
        }

        //Find square of the value
        public static BigComplex Sqr(BigComplex value)
        {
            return new BigComplex(BigRational.Sqr(value.real) - BigRational.Sqr(value.imaginary), BigRational.Two * value.real * value.imaginary );
        }

        //Find square root of the value
        public static BigComplex Sqrt(BigComplex value, int precision = 0)
        {
            BigRational t = BigRational.Sqrt( BigRational.Sqr(value.real) + BigRational.Sqr(value.imaginary), precision );
            return new BigComplex( BigRational.Sqrt((t + value.real)/BigRational.Two, precision), value.imaginary.SignNoZero * BigRational.Sqrt((t - value.real)/BigRational.Two, precision) );
        }

        public bool Equals(BigComplex other)
        {
            return real.Equals(other.real) && imaginary.Equals(other.imaginary);
        }

        //Return decimal representation of this BigComplex with *precision* digits after decimal separator
        public string ToString(int precision = 0, NumberFormatInfo format = null)
        {
            string result;

            if(real.IsZero && !imaginary.IsZero)
            {
                result = imaginary.ToString(precision, format) + "i";
            }
            else if(!real.IsZero)
            {
                result = real.ToString(precision, format);

                if(!imaginary.IsZero)
                {
                    result += imaginary.Negative?" - ":" + ";
                    result += BigRational.Abs(imaginary).ToString(precision, format) + "i";
                }
            }
            else result = "0";

            return result;
        }
    }
}
