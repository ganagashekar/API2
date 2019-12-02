using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace EMSVExtentions
{
    public static class CoreMapExtension
    {
        public static TDest ToDestination<TSource, TDest>(this TSource source, TDest dest = null)
    where TSource : class, new()
    where TDest : class, new()
        {
            if (source.IsNull())
                return null;
            if (dest.IsNull())

                return Mapper.Map<TSource, TDest>(source);
            return Mapper.Map<TSource, TDest>(source, dest);
        }

        public static TDest ToDestination<TSource, TDest>(this TSource source, Action<IMappingOperationOptions> opts)
    where TSource : class, new()
    where TDest : class, new()
        {
            if (source.IsNull())
                return null;
            if (opts.IsNull())
                return Mapper.Map<TSource, TDest>(source);
            return Mapper.Map<TSource, TDest>(source, opts);
        }

        public static TDest ToDestination<TSource, TDest>(this TSource source, TDest dest, Action<IMappingOperationOptions> opts = null)
    where TSource : class, new()
    where TDest : class, new()
        {
            if (source.IsNull())
                return null;
            if (opts.IsNull())
                return Mapper.Map<TSource, TDest>(source, dest);
            return Mapper.Map<TSource, TDest>(source, dest, opts);
        }

        public static async Task<TDest> ToDestinationAsync<TSource, TDest>(this Task<TSource> source, TDest dest = null)
    where TSource : class, new()
    where TDest : class, new()
        {
            if (source.IsNull())
                return null;
            var data = await source;
            if (dest.IsNull())
                return Mapper.Map<TSource, TDest>(data);
            return Mapper.Map<TSource, TDest>(data, dest);
        }

        public static TDestination[] ToDestinationArray<TSource, TDestination>(this ICollection<TSource> list, Action<IMappingOperationOptions> opts = null)
    where TSource : class, new()
    where TDestination : class, new()
        {
            if (list.IsNull())
                return new TDestination[] { };

            if (opts.IsNotNull())
                return Mapper.Map<TSource[], TDestination[]>(list.ToArray());
            return Mapper.Map<TSource[], TDestination[]>(list.ToArray(), opts);

            return Mapper.Map<TSource[], TDestination[]>(list.ToArray());
        }

        public static TDestination[] ToDestinationArray<TSource, TDestination>(this IEnumerable<TSource> list)
    where TSource : class, new()
    where TDestination : class, new()
        {
            if (list.IsNull())
                return new TDestination[] { };
            return Mapper.Map<TSource[], TDestination[]>(list.ToArray());
        }

        public static async Task<TDestination[]> ToDestinationArrayAsync<TSource, TDestination>(this IQueryable<TSource> source)
    where TSource : class, new()
    where TDestination : class, new()
        {
            if (source.IsNull())
                return new TDestination[] { };
            var data = await source.ToArrayAsync();
            return data.ToDestinationArray<TSource, TDestination>();
        }

        public static IEnumerable<TDest> ToDestinationEnumerable<TSource, TDest>(this ICollection<TSource> source, Action<IMappingOperationOptions> opts = null)
    where TSource : class, new()
    where TDest : class, new()
        {
            if (source.IsNull())
                return new TDest[] { };
            if (opts.IsNotNull())
                return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDest>>(source.AsEnumerable());
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDest>>(source.AsEnumerable(), opts);
        }

        public static List<TDest> ToDestinationList<TSource, TDest>(this IEnumerable<TSource> source, Action<IMappingOperationOptions> opts = null)
    where TSource : class, new()
    where TDest : class, new()
        {
            if (source.IsNull())
                return new List<TDest> { };
            if (opts.IsNull())
                return Mapper.Map<List<TSource>, List<TDest>>(source.ToList());
            return Mapper.Map<List<TSource>, List<TDest>>(source.ToList(), opts);
        }



        public static TDest ToDestinationPaged<Tsource, TDest>(this PagedList<Tsource> source, Action<IMappingOperationOptions> opts = null)
            where Tsource : class, new()
             where TDest : class, new()
        {
            if (source.IsNull())
                return null;

            return Mapper.Map<TDest>(source);
        }

        public static int[] ToIntArray(this string value, char separator)
        {
            return Array.ConvertAll(value.Split(separator), s => int.Parse(s));
        }

        public static long[] ToLongArrayComma(this string str)
        {
            return str.Split(",".ToCharArray()).Select(x => long.Parse(x.ToString())).ToArray();
        }
    }
}
