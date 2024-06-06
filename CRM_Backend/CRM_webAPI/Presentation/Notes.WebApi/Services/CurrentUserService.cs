using Notes.Application.Interfaces;
using System.Security.Claims;

namespace Notes.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)=>
            _contextAccessor = contextAccessor;

        public string Username
        { 
            get
            {
            //    var name = _contextAccessor.HttpContext?.User?
            //        .FindFirst(ClaimTypes.Name).Value;
            //    return string.IsNullOrEmpty(name) ? string.Empty : name;
                return "admin";
            } 
        }
    }
}
