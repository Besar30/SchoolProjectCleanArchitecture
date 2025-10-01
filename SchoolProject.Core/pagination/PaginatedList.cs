using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
namespace SchoolProject.Core.pagination
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; private set; }
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        [JsonConstructor]
        public PaginatedList(List<T> items, int pageNumber, int totalPages)
        {
            Items = items;
            PageNumber = pageNumber;
            TotalPages = totalPages;
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var count = await source.CountAsync(cancellationToken);
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return new PaginatedList<T>(items, pageNumber, (int)Math.Ceiling(count / (double)pageSize));
        }
    }
}
