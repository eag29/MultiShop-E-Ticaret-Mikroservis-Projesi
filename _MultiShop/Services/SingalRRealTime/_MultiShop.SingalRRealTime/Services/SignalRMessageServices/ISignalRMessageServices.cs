namespace _MultiShop.SingalRRealTime.Services.SignalMessageServices
{
    public interface ISignalRMessageServices
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
