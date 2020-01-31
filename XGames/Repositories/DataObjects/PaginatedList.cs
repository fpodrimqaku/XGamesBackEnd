using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XGames.DTModels
{
    public class PaginatedList<T> :List <T>
    {
        
        public static int DEFAULT_PAGE_SIZE=9;
        public static int DEFAULT_PAGE_INDEX = 1;

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        private PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

       

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {

            pageIndex = ( pageIndex < 1) ? DEFAULT_PAGE_INDEX : pageIndex;
            pageSize = ( pageSize < 0) ? DEFAULT_PAGE_INDEX : pageSize;

            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        //this method is invoked in case when no page parameters are provided 
        //e.g. first request for entities
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source)
        {
            int pageIndex = DEFAULT_PAGE_INDEX;
            int pageSize = DEFAULT_PAGE_SIZE;

            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

    }
}
