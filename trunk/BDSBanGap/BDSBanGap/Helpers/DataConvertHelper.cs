using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDSBanGap.Helpers
{
    /// <summary>
    /// The class is a helper class to do type-safe conversion
    /// We should avoid to use any direct type conversion, instead to collect it
    /// in one place for easier to do code maintenance in the future.
    /// </summary>
    public static class DataConvertHelper
    {
        /// <summary>
        /// Function to convert an object type to Boolean.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>boolean return value</returns>
        public static Boolean ToBoolean(object objInputValue)
        {
            //null input supposed to be false.
            Boolean blnReturnValue = default(Boolean);
            if (objInputValue != null)
            {
                Boolean.TryParse(objInputValue.ToString(), out blnReturnValue);
            }
            return blnReturnValue;
        }

        /// <summary>
        /// Function to convert an object type to Byte.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>byte return value</returns>
        public static byte ToByte(object objInputValue)
        {
            byte bytReturnValue = default(byte);
            if (objInputValue != null)
            {
                byte.TryParse(objInputValue.ToString(), out bytReturnValue);
            }
            return bytReturnValue;
        }

        /// <summary>
        /// Function to convert an object type to Signed Byte.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>SByte return value</returns>
        public static sbyte ToSByte(object objInputValue)
        {
            sbyte sbytReturnValue = default(sbyte);
            if (objInputValue != null)
            {
                sbyte.TryParse(objInputValue.ToString(), out sbytReturnValue);
            }
            return sbytReturnValue;
        }

        /// <summary>
        /// Function to convert an object type to Integer.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>Int16 return value</returns>
        public static short ToInt16(object objInputValue)
        {
            short shrReturnValue = default(short);
            if (objInputValue != null)
            {
                short.TryParse(objInputValue.ToString(), out shrReturnValue);
            }
            return shrReturnValue;
        }

        /// <summary>
        /// Function to convert an object type to Unsigned Integer.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>UInt16 return value</returns>
        public static ushort ToUInt16(object objInputValue)
        {
            ushort ushrReturnValue = default(ushort);
            if (objInputValue != null)
            {
                ushort.TryParse(objInputValue.ToString(), out ushrReturnValue);
            }
            return ushrReturnValue;
        }

        /// <summary>
        /// Function to convert an object type to Integer.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>Int32 return value</returns>
        public static int ToInt32(object objInputValue)
        {
            int intReturnValue = default(int);
            if (objInputValue != null)
            {
                int.TryParse(objInputValue.ToString(), out intReturnValue);
            }
            return intReturnValue;
        }

        /// <summary>
        /// Function to convert an object type to Integer.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>Int return value</returns>
        public static int ToInt(object objInputValue)
        {
            return ToInt32(objInputValue);
        }
        /// <summary>
        /// Function to convert an object type to Short.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>Short return value</returns>
        public static short ToShort(object objInputValue)
        {
            return ToInt16(objInputValue);
        }
        ///// <summary>
        ///// Function to convert an object type to Long.
        ///// </summary>
        ///// <param name="objInputValue">object type, indicate value to be parsed.</param>
        ///// <returns>Long return value</returns>
        //public static int ToLong(object objInputValue)
        //{
        //    return ToInt64(objInputValue);
        //}
        /// <summary>
        /// Function to convert an object type to String.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>String return value</returns>
        //public static int ToString(object objInputValue)
        //{
        //    string stringReturnValue = default(string);
        //    if (objInputValue != null)
        //    {
        //        stringReturnValue = objInputValue.ToString();
        //    }
        //    return stringReturnValue;
        //}
        /// <summary>
        /// Function to convert an object type to Unsigned Integer.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>UInt32 return value</returns>
        public static uint ToUInt32(object objInputValue)
        {
            uint uintReturnValue = default(uint);
            if (objInputValue != null)
            {
                uint.TryParse(objInputValue.ToString(), out uintReturnValue);
            }
            return uintReturnValue;
        }

        /// <summary>
        /// Function to convert an object type to Long Integer.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>Int64 return value</returns>
        public static long ToInt64(object objInputValue)
        {
            long lngReturnValue = default(long);
            if (objInputValue != null)
            {
                long.TryParse(objInputValue.ToString(), out lngReturnValue);
            }
            return lngReturnValue;
        }


        /// <summary>
        /// Function to convert an object type to Unsigned Long Integer.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>UInt64 return value</returns>
        public static ulong ToUInt64(object objInputValue)
        {
            ulong ulngReturnValue = default(ulong);
            if (objInputValue != null)
            {
                ulong.TryParse(objInputValue.ToString(), out ulngReturnValue);
            }
            return ulngReturnValue;
        }


        /// <summary>
        /// Function to convert an object type to Single-Precision Floating-Point.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>float return value</returns>
        public static float ToFloat(object objInputValue)
        {
            float fltReturnValue = default(float);
            if (objInputValue != null)
            {
                float.TryParse(objInputValue.ToString(), out fltReturnValue);
            }
            return fltReturnValue;
        }

        /// <summary>
        /// Function to convert an object type to Double-Precision Floating-Point.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>double return value</returns>
        public static double ToDouble(object objInputValue)
        {
            double dblReturnValue = default(double);
            if (objInputValue != null)
            {
                double.TryParse(objInputValue.ToString(), out dblReturnValue);
            }
            return dblReturnValue;
        }


        /// <summary>
        /// Function to convert an object type to Decimal.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>decimal return value</returns>
        public static decimal ToDecimal(object objInputValue)
        {
            decimal decReturnValue = default(decimal);
            if (objInputValue != null)
            {
                //decimal.TryParse(objInputValue.ToString(),System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out decReturnValue);
                decimal.TryParse(objInputValue.ToString(), out decReturnValue);
            }
            return decReturnValue;
        }

        /// <summary>
        /// Function to convert an object type to DateTime.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>DateTime return value</returns>
        public static DateTime ToDateTime(object objInputValue)
        {
            DateTime dtmReturnValue = default(DateTime);
            if (objInputValue != null)
            {
                DateTime.TryParse(objInputValue.ToString(), out dtmReturnValue);
            }
            return dtmReturnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objInputValue"></param>
        /// <returns>If the input value is null then the current time will be returned</returns>
        public static DateTime ToDateTimeFromOADate(object objInputValue)
        {
            DateTime dtmReturnValue = default(DateTime);
            if (objInputValue != null)
            {
                if (objInputValue is double)
                {
                    dtmReturnValue = DateTime.FromOADate((double)objInputValue);
                }
                else
                {
                    DateTime.TryParse((string)objInputValue, out dtmReturnValue);
                }
            }
            else
            {
                dtmReturnValue = DateTime.Now;
            }

            return dtmReturnValue;
        }

        /// <summary>
        /// Function to convert an object type to string.
        /// </summary>
        /// <param name="objInputValue">object type, indicate value to be parsed.</param>
        /// <returns>string return value</returns>
        public static string ToString(object objInputValue)
        {
            string dtmReturnValue = string.Empty;
            if (objInputValue != null)
            {
                dtmReturnValue = objInputValue.ToString();
            }
            return dtmReturnValue;
        }

        public static int getWeek(DateTime date)
        {
            System.Globalization.CultureInfo cult_info = System.Globalization.CultureInfo.CreateSpecificCulture("no");
            System.Globalization.Calendar cal = cult_info.Calendar;
            int weekCount = cal.GetWeekOfYear(date, cult_info.DateTimeFormat.CalendarWeekRule, cult_info.DateTimeFormat.FirstDayOfWeek);
            return weekCount;

        }
    }
}
