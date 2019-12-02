using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EMSVExtentions
{
    public static class ObjectExtensions
    {
        private static readonly string[] _ExcludedProperties = new string[] { };

        static ObjectExtensions()
        {
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsNotNull(this object obj)
        {
            return !obj.IsNull();
        }

        public static bool IsNotValidCollection(this ICollection value)
        {
            if (value.IsNull() || value.Count == 0)
                return true;
            return false;
        }


        public static object GetPropValue(object src, string propName)
        {
            if (src.GetType().GetProperty(propName) != null)
                return src.GetType().GetProperty(propName).GetValue(src, null);
            else
                return null;
        }

        public static double ParseDouble(this object value)
        {
            double output;
            if (value == null)
                return 0.0;
            Double.TryParse(value.ToString(), out output);
            return output;
        }

        public static string ParseString(this object value)
        {
            if (value == null)
                return "0.0";
            return value.ToString();
        }

        public static decimal ParseDecimal(object value)
        {
            decimal output;
            if (value == null)
                return decimal.Zero;
            decimal.TryParse(value.ToString(), out output);
            return output;
        }

        public static string ParseDoubleToSigleDecimal(object value)
        {
            double output;
            if (value == null)
                return string.Empty;
            Double.TryParse(value.ToString(), out output);
            return output == 0.0 ? string.Empty : Math.Abs(Math.Round(output, 1)).ToString();
        }

        public static double? ParseNullableDouble(object value)
        {
            double output;
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return null;
            double.TryParse(value.ToString(), out output);
            return output;
        }

        public static string ParseStringByRounding(object value)
        {
            double output;
            if (value == null || value.ToString().ToUpper() == "infinity".ToUpper() || value.ToString().ToUpper() == "NaN".ToUpper())
                return string.Empty;
            Double.TryParse(value.ToString(), out output);
            return String.Concat(Math.Abs(Math.Round(output, 1)).ToString(), " x");
        }

        public static int ParseInt(object value)
        {
            int output;
            if (value == null)
                return (int)decimal.Zero;
            Int32.TryParse(value.ToString(), out output);
            return output;
        }

        public static int ToParseInt(this object value)
        {
            int output;
            if (value == null)
                return (int)decimal.Zero;
            Int32.TryParse(value.ToString(), out output);
            return output;
        }

        public static T ToInstance<T>(this T entity) where T : new()
        {
            return entity.IsNotNull() ? entity : new T { };
        }

        public static T GetDeserialize<T>(this string jsonString) where T : class, new()
        {
            if (jsonString.IsNull())
                return new T { };
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static string GetserializeJsonString(this object obj)
        {
            if (obj.IsNull())
                return string.Empty;
            return JsonConvert.SerializeObject(obj);
        }

        public static string GetserializeJsonStringEncrypt(this object obj)
        {
            if (obj.IsNull())
                return string.Empty;
            return JsonConvert.SerializeObject(obj).Encrypt();
        }


        public static bool IsExist(this string[] data, string code)
        {
            if (data.IsNull() || code.IsNull())
                return false;
            return data.Any(x => x.IsEqualsIgnoreCase(code));
        }

        public static bool ToLongIsZero(this long Number)
        {
            if (Number==0)
                return true;
            return false;
        }

        public static bool ToStringIsZero(this string Number)
        {
            if (Number.IsNumeric() &&  !string.IsNullOrEmpty(Number) && Number=="0")
                return true;
            return false;
        }

        public static string[] ToGetProperties(this Type type)
        {
            if (type.IsNull())
                return new string[] { };
            return type.GetProperties().Select(s => s.Name).ToArray();
        }

        public static string ToAppString(this object data)
        {
            if (data.IsNull())
                return string.Empty;
            return data.ToString();
        }


        public static bool HasChanges<T>(this T source, T otherSource, string[] excludedProperties) where T : class
        {
            excludedProperties = excludedProperties ?? new string[] { };
            if (source.IsNull() && otherSource.IsNull())
                return false;
            if ((source.IsNull() && otherSource.IsNotNull()) || (source.IsNotNull() && otherSource.IsNull()))
                return true;
            var status = false;
            var includedProperties = typeof(T).GetProperties().Where(x => !x.PropertyType.IsClass || (x.PropertyType.IsClass && x.PropertyType.FullName.IsEqualsIgnoreCase("System.String")))
    .Where(x => !excludedProperties.Any(s => s.IsEqualsIgnoreCase(x.Name)) && !x.PropertyType.FullName.IsStartWithIgnoreCase("System.Collections.Generic."));
            foreach (var property in includedProperties)
            {
                var soureValue = source.GetPropertyValue(property.Name).ToAppString();
                var otherSourceValue = otherSource.GetPropertyValue(property.Name).ToAppString();
                if (!soureValue.IsEqualsIgnoreCase(otherSourceValue))
                {
                    status = true;
                    break;
                }
            }
            return status;
        }


        public static TResult ToFirstOrDefult<TEntity, TResult>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
            where TEntity : class
        {
            return query.Where(predicate).Select(selector).FirstOrDefault();
        }

        public static double? GetValue<T>(this List<T> src, string propName, bool isAll = true) where T : class
        {
            if (propName == null)
                return 0;

            if (isAll)
                return src.Sum(x => (double?)x.GetValue(propName));
            else
                return (double?)src.FirstOrDefault().GetValue(propName);
        }

        public static object GetValue<T>(this T src, string propName) where T : class
        {
            if (src.GetType().GetProperty(propName) != null)
                return src.GetType().GetProperty(propName).GetValue(src, null);
            else
                return null;
        }

        public static TEntity[] ToFilteredArray<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
          where TEntity : class
        {
            return query.Where(predicate).ToArray();
        }

        public static TResult[] ToFilteredArray<TEntity, TResult>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
            where TEntity : class
            where TResult : class
        {
            return query.Where(predicate).Select(selector).ToArray();
        }

        public static bool IsNumeric(this string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        public static bool IsNumericLong(this string input)
        {
            long test;
            return long.TryParse(input, out test);
        }

        public static long ToNumericLong(this string input)
        {
            long test;
            if (long.TryParse(input, out test))
            {
                return test;
            }
            return 0;
        }
    }
}
