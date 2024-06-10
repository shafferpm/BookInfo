using AutoMapper;
using Azure;
using BookInfo.API.Models;
using BookInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBookInfoRepository _bookInfoRepository;
        private readonly IMapper _mapper;

        // Inject the IBookInfoRepository repository contract
        // and IMapper contract
        // into the Authors controller.
        public AuthorsController(IBookInfoRepository bookInfoRepository,
            IMapper mapper)
        {
            _bookInfoRepository = bookInfoRepository ?? 
                throw new ArgumentNullException(nameof(bookInfoRepository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<AuthorWithoutTitleDto>>> GetAuthors()
        {
            var authorsEntities = await _bookInfoRepository.GetAuthorsAsync();
            return Ok(_mapper.Map<IEnumerable<AuthorWithoutTitleDto>>(authorsEntities));


            // Manually mapping the Author entity to the AuthorWithoutTitleDto.
            //var results = new List<AuthorWithoutTitleDto>();
            //foreach (var authorEntity in authorsEntities)
            //{
            //    results.Add(new AuthorWithoutTitleDto
            //    {
            //        AuId = authorEntity.AuId,
            //        AuLname = authorEntity.AuLname,
            //        AuFname = authorEntity.AuFname,
            //        Phone = authorEntity.Phone,
            //        Address = authorEntity.Address,
            //        City = authorEntity.City,
            //        State = authorEntity.State,
            //        Zip = authorEntity.Zip,
            //        Contract = authorEntity.Contract
            //    });
            //}
            //return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(
            string id, 
            bool includeTitleAuthor = false)
        {
            var author = await _bookInfoRepository.GetAuthorAsync(id,includeTitleAuthor);

            if (author == null)
            {
                return NotFound();
            }

            if (includeTitleAuthor)
            {
                return Ok(_mapper.Map<AuthorDto>(author));
            }

            return Ok(_mapper.Map<AuthorWithoutTitleDto>(author));
        }

        [HttpPost(Name = "CreateAuthor")]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(
            AuthorForCreationDto newAuthor)
        {
            if (await _bookInfoRepository.AuthorExistsAsync(newAuthor.AuId))
            {
                return NotFound();
            }

            var authorEntity = _mapper.Map<Entities.Author>(newAuthor);

            _bookInfoRepository.AddAuthor(authorEntity); 

            await _bookInfoRepository.SaveChangesAsync();

            // await _bookInfoRepository.AddTitleAuthorForAuthorAsync(id, finalAuthor);    

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(
            string id,            
            AuthorForUpdateDto authorForUpdateDto,
            bool includeTitleAuthor = false)
        {
            if (!await _bookInfoRepository.AuthorExistsAsync(id))
            {
                return NotFound();
            }

            var author = await _bookInfoRepository.GetAuthorAsync(id, includeTitleAuthor);

            if (author == null)
            {
                return NotFound();
            }

            _mapper.Map(authorForUpdateDto, author);    

            await _bookInfoRepository.SaveChangesAsync();

            return Ok("Author updated");
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartiallyUpdateAuthor(
            string id,
            JsonPatchDocument<AuthorForUpdateDto> patchDocument)
        {
            if (!await _bookInfoRepository.AuthorExistsAsync(id))
            {
                return NotFound();
            }

            var author = await _bookInfoRepository.GetAuthorAsync(id, false);

            if (author == null)
            {
                return NotFound();
            }

            var authorToPatch = _mapper.Map<AuthorForUpdateDto>(author);

            patchDocument.ApplyTo(authorToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(authorToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(authorToPatch, author);

            await _bookInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(
            string id,
            bool includeTitleAuthor = false)
        {
            if (!await _bookInfoRepository.AuthorExistsAsync(id))
            {
                return NotFound();
            }

            var author = await _bookInfoRepository.GetAuthorAsync(id, includeTitleAuthor);

            if (author == null)
            {
                return NotFound();
            }

            _bookInfoRepository.DeleteAuthor(author);

            await _bookInfoRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
