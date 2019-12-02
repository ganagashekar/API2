using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace EMSVUAPIBusiness.Mapper
{
    public static class DbHelpers
    {

        public static List<T> DataReaderMapToList<T>(this IDataReader dr)
        {
            List<T> list = new List<T>();

            try
            {

                T obj = default(T);
                while (dr.Read())
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            try
                            {
                                prop.SetValue(obj, dr[prop.Name], null);
                            }
                            catch (Exception ex)
                            {
                                return null;
                            }
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                list = null;

            }
        }
    }
}
