namespace ServiceAPI.Common.Types
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; }
        public int ResultsPerPage { get; }
        public long TotalPages { get; }
        public long TotalResults { get; }

        protected PagedResultBase()
        {
        }

        protected PagedResultBase(int currentPage, int resultsPerPage,
            long totalPages, long totalResults)
        {
            CurrentPage = currentPage > totalPages ? (int)totalPages : currentPage;
            ResultsPerPage = resultsPerPage;
            TotalPages = totalPages;
            TotalResults = totalResults;
        }
    }
}
