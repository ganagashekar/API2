using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVExtentions
{
    public class PagedList<T> where T : class
    {
        public PagedList()
        {
            Data = new List<T>();
        }

        public List<T> Data { get; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }
}
