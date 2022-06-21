using AutoMapper;
using Core.Entities;
using IdentityProject.Models;

namespace IdentityProject.AutoMapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            #region Account
            CreateMap<RegisterModel, ApplicationUser>();
            CreateMap<ApplicationUser, RegisterModel>();
            #endregion
        }
    }
}
