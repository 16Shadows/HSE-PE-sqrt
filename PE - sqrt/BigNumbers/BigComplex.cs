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

        //Construct a BigComlex from a string. No exceptions thrown. Returns true on success. On failure, value of result is not defined
        public static bool TryParse(string str, out BigComplex result, NumberFormatInfo format = null)
        {
            result = Zero;
            if(str == null || str.Length == 0) return false;

            //Remove spaces
            str = str.Replace(" ", "");

            if(str.Length == 0) return false;

            int signs = str.Count( x => { return x == '+' || x == '-'; } );

            if( str.Count( x => { return x == 'i'; } ) > 1 || signs > 2 ) return false;

            int index = str.IndexOf('i');

            //No imaginary unit (thus no imaginary part
            if(index == -1)
                return BigRational.TryParse(str, out result.real, format);
            else
            {
                int index2 = str.LastIndexOf('+');
                int index3 = str.LastIndexOf('-');

                if(index3 > index2) index2 = index3;

                //Imaginary unit is present
                if(signs == 0)
                {
                    if(index != 0 && index != str.Length - 1) return false;

                    //Only imaginary positive part. Guaranteed.
                    str = str.Remove(index, 1);

                    if(str.Length == 0)
                    {
                        result.imaginary = BigRational.One;
                        return true;
                    }

                    return BigRational.TryParse(str, out result.imaginary, format);
                }
                else if(signs == 1)
                {
                    //The trickiest so far. Could be signed imaginary or with both parts
                    if(index2 == 0)
                    {
                        //Has to be signed imaginary, since you can't append another part without a second sign
                        str = str.Remove(index, 1);

                        if(str.Length == 0 || str.Equals("+"))
                        {
                            result.imaginary = BigRational.One;
                            return true;
                        }
                        else if(str.Equals("-"))
                        {
                            result.imaginary = BigRational.MinusOne;
                            return true;
                        }

                        return BigRational.TryParse(str, out result.imaginary, format);
                    }
                    else
                    {
                        //Both parts present
                        if(index < index2)
                        {
                            //Imaginary goes before real

                            string imComp = str.Substring(0, index2);
                            if(index != 0 && index != 1 && index != imComp.Length - 1) return false;

                            imComp = imComp.Remove(imComp.IndexOf('i'), 1);
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
                        
                            if(index != index2+1 && index != str.Length - 1) return false;

                            string imComp = str.Substring(index2);
                            imComp = imComp.Remove(imComp.IndexOf('i'), 1);

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
                else
                {
                    //Both parts present. Guaranteed

                    if(index < index2)
                    {
                        //Imaginary goes before real

                        string imComp = str.Substring(0, index2);
                        if(index != 0 && index != 1 && index != imComp.Length - 1) return false;

                        imComp = imComp.Remove(imComp.IndexOf('i'), 1);
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
                        
                        if(index != index2+1 && index != str.Length - 1) return false;

                        string imComp = str.Substring(index2);
                        imComp = imComp.Remove(imComp.IndexOf('i'), 1);
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
                if(imaginary.CompareTo(BigRational.One) == 0) result = "i";
                else if(imaginary.CompareTo(BigRational.MinusOne) == 0) result = "-i";
                else result = imaginary.ToString(precision, format) + "i";
            }
            else if(!real.IsZero)
            {
                result = real.ToString(precision, format);

                if(!imaginary.IsZero)
                {
                    result += imaginary.Negative?" - ":" + ";
                    if(imaginary.CompareTo(BigRational.One) == 0 || imaginary.CompareTo(BigRational.MinusOne) == 0) result += "i";
                    else result += BigRational.Abs(imaginary).ToString(precision, format) + "i";
                }
            }
            else result = "0";

            return result;
        }
    }
}
