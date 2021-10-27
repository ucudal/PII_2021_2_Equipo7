using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SearchPage<T> where T : IManagableData
    {
        private List<T> searchResults = new List<T>();
        private int currentPage;
        private int pageItemCount = 10;
        private List<T> pageItems = new List<T>();

        /// <summary>
        /// 
        /// </summary>
        public List<T> SearchResults
        {
            get => this.searchResults;
            set => this.searchResults = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public int CurrentPage
        {
            get => this.currentPage;
            set => this.currentPage = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public int PageItemCount
        {
            get => this.pageItemCount;
            set => this.pageItemCount = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<T> PageItems
        {
            get 
            {
                int startIndex = this.currentPage * this.pageItemCount;
                if (this.pageItems.Count >= startIndex)
                {
                    return new List<T>();
                }
                else
                {
                    return this.searchResults.GetRange(startIndex, this.pageItemCount);
                }
            }
        }
    }
}