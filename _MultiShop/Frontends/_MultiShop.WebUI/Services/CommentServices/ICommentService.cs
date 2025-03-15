using _MultiShop.DtoLayer.CommentDtos;

namespace _MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(string id);
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task<GetByIdCommentDto> GetByIdCommentAsync(string id);
        Task<List<ResultCommentDto>> CommentListByProductId(string id);
    }
}
