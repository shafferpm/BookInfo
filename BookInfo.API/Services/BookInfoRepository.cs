using BookInfo.API.DbContexts;
using BookInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookInfo.API.Services
{
    public class BookInfoRepository : IBookInfoRepository
    {
        private readonly PubsContext _context;

        // The PubsContext DbContext is injected into the repository.
        // The injected DbContext is assigned to the private _context field.
        // If the injected DbContext is null, an ArgumentNullException is thrown.
        public BookInfoRepository(PubsContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            // The Add method is called on the Authors DbSet to add the author to the database.
            _context.Authors.Add(author);
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }

        public async Task AddTitleAuthorForAuthorAsync(string authorId, Titleauthor titleAuthor)
        {
            var author = await GetAuthorAsync(authorId, false);

            if (author != null)
            {
                author.Titleauthors.Add(titleAuthor);
            }
        }

        public async Task<bool> AuthorExistsAsync(
            string authorId)
        {
            return await _context.Authors.AnyAsync(c => c.AuId == authorId.ToString());
        }

        public async Task<Author?> GetAuthorAsync(string authorId, bool includeTitleAuthor)
        {
            if (includeTitleAuthor)
            {
                return await _context.Authors
                    .Include(c => c.Titleauthors)
                    .FirstOrDefaultAsync(c => c.AuId == authorId);
            }
            return await _context.Authors
                .FirstOrDefaultAsync(c => c.AuId == authorId);
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.OrderBy(c => c.AuLname).ToListAsync();
        }

        public Task<Titleauthor?> GetTitleAuthorForAuthorAsync(
            string authorId, 
            string titleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Titleauthor>> GetTitleAuthorsForAuthorAsync(
            string authorId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
