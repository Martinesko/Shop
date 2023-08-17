using Shop.Models.Profile;

namespace Shop.Services.ProfileService.Contract
{
    public interface IProfileService
    {
        Task<ProfileViewModel> GetProfileAsync(Guid userId);

        Task EditProfileAsync(Guid UserId,ProfileViewModel model);
        Task<AddressViewModel> GetAddress(Guid UserId);

        Task SaveAddressChangesAsync(AddressViewModel model,Guid userId);
    }
}
