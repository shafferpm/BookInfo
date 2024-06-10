using BookInfo.API.Entities;

namespace BookInfo.API.Services
{
    public interface IBookInfoRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();

        // Add the GetAuthorAsync method to the IBookInfoRepository interface.
        // The method returns a Task of Author and takes an authorId parameter.
        // The method retrieves an author from the database based on the authorId.
        // If the author is not found, the method returns null.
        Task<Author?> GetAuthorAsync(string authorId, bool includeTitleAuthor);

        Task<IEnumerable<Titleauthor>> GetTitleAuthorsForAuthorAsync(string authorId);
        Task<Titleauthor?> GetTitleAuthorForAuthorAsync(string authorId, 
            string titleId);
        Task<bool> AuthorExistsAsync(string authorId);

        Task AddTitleAuthorForAuthorAsync(string authorId, Titleauthor titleAuthor);

        void AddAuthor(Author author);
        void DeleteAuthor(Author author);

        Task<bool> SaveChangesAsync();
    }
}
