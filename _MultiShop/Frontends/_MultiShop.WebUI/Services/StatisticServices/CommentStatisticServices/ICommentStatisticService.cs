namespace _MultiShop.WebUI.Services.StatisticServices.CommentServices
{
    public interface ICommentStatisticService
    {
        Task<int> GetTotalCommentCount();
        Task<int> GetActiveCommentCount();
        Task<int> GetPassiveCommentCount();
    }
}
