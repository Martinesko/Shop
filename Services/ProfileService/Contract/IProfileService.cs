﻿using Shop.Models.Profile;

namespace Shop.Services.ProfileService.Contract
{
    public interface IProfileService
    {
        Task<ProfileViewModel> GetProfileAsync(Guid userId);

        Task EditProfileAsync(Guid UserId,ProfileViewModel model);
    }
}
