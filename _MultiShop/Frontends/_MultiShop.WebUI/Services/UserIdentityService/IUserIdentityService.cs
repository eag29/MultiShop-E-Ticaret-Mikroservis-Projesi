using _MultiShop.DtoLayer.IdentityDtos.UserDtos;

namespace _MultiShop.WebUI.Services.UserIdentityService
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUserListAsync();
    }
}
