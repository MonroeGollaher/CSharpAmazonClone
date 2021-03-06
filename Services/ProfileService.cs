using System;
using Amazen.Models;
using Amazen.Repositories;

namespace Amazen.Services
{
    public class ProfileService
    {
        private readonly ProfileRepository _repo;

        public ProfileService(ProfileRepository repo)
        {
            _repo = repo;
        }

        public Profile GetOrCreateProfile(Profile userInfo)
        {
            Profile foundProfile = _repo.GetByEmail(userInfo.Email);
            if (foundProfile == null)
            {
                return _repo.Create(userInfo);
            }
            return foundProfile;
        }
    }
}