using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel;

namespace EMSVExtentions
{
    public static class TypeExtensions
    {
        /// <summary>
        ///  To get the value from object using reflection.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="data">Source Objcect</param>
        /// <param name="property">Property Hier.</param>
        /// <returns></returns>
        public static object GetPropertyValue(this object data, string property)
        {
            if (data.IsNull() || property.IsNull())
                return null;
            int dotIdx = property.IndexOf('.');
            if (dotIdx > 0)
            {
                object obj = GetPropertyValue(data, property.Substring(0, dotIdx));
                return GetPropertyValue(obj, property.Substring(dotIdx + 1));
            }
            PropertyInfo propInfo = null;
            Type objectType = data.GetType();

            while (propInfo == null && objectType != null)
            {
                propInfo = objectType.GetProperty(property,
                          BindingFlags.Public
                        | BindingFlags.Instance
                        | BindingFlags.DeclaredOnly);

                objectType = objectType.BaseType;
            }

            if (propInfo != null)
                return propInfo.GetValue(data, null);

            FieldInfo fieldInfo = data.GetType().GetField(property,
                          BindingFlags.Public | BindingFlags.Instance);

            if (fieldInfo.IsNotNull())
                return fieldInfo.GetValue(data);

            return null;
        }

        /// <summary>
        ///  To create instance class with data.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="input">Instance class of specified Type</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyVal"> Value</param>
        public static void SetValue<T>(this T input, string propertyName, object propertyVal)
        {
            //find out the type
            Type type = input.GetType();

            //get the property information based on the type
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            if (propertyInfo != null && propertyVal != null && !(propertyVal is DBNull))
            {
                //find the property type
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType != typeof(string) && ((propertyVal.ToString().ToLower() == "n/a") || (propertyVal.ToString().ToLower() == "")))
                    return;

                //if (propertyType == typeof(DateTime?) && propertyVal.ToString().IsAppDate() && propertyVal.ToString().DefaultDateChecker() == null)
                //    return;

                if (propertyType == typeof(bool) && propertyVal.GetType() != typeof(bool))
                    propertyVal = propertyVal.ToString().Toboolean();

                if (propertyType == typeof(string) && propertyVal.GetType() == typeof(string))
                    propertyVal = propertyVal.ToString().Replace("'", "");

                //Convert.ChangeType does not handle conversion to nullable types
                //if the property type is nullable, we need to get the underlying type of the property
                var targetType = IsNullableType(propertyInfo.PropertyType) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;
                //Returns an System.Object with the specified System.Type and whose value is
                //equivalent to the specified object.
                propertyVal = Convert.ChangeType(propertyVal, targetType);
                //Set the value of the property
                propertyInfo.SetValue(input, propertyVal, null);
            }
        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

        /// <summary>
        /// To get the Description value for property.
        /// </summary>
        /// <typeparam name="T">Type of Class</typeparam>
        /// <typeparam name="TProp">Type of property.</typeparam>
        /// <param name="entity">Class Entity.</param>
        /// <param name="propertySelector">Property Selector.</param>
        /// <returns></returns>
        public static string GetDescription<T, TProp>(this T entity, Expression<Func<T, TProp>> propertySelector)
           where T : class
        {
            var body = (MemberExpression)propertySelector.Body;
            var Name = body.Member.Name;
            var property = typeof(T).GetProperty(Name);
            var attribute = Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute.IsNull() ? string.Empty : attribute.Description;
        }

        private static bool Toboolean(this string value)
        {
            if (value == "x")
                return true;
            else
                return false;
        }
    }
}
