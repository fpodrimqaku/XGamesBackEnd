using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XGames.DTModels
{
    public class PageModel<T>
    {
        private PageModel(int TotalPages,int PageIndex,ICollection<T> items) {
            this.TotalPages = TotalPages;
            this.PageIndex = PageIndex;
            this.items = items;
            this.ItemsCount = items.Count();
        }
        public static PageModel<T> Create(PaginatedList<T> paginatedList) {
            return new PageModel<T>(paginatedList.TotalPages,paginatedList.PageIndex,paginatedList.ToList());
        }


        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int ItemsCount { get; private set; }
        public ICollection<T> items { get; private set; }


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

      


    }
}
