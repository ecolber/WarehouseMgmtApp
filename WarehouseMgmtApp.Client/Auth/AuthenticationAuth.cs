using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using WarehouseMgmtApp.Client.Services.Dtos;

namespace WarehouseMgmtApp.Client.Auth
{
    public class AuthenticationAuth : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthenticationAuth(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task UpdateAuthState(UserDto? userSession)
        {
            ClaimsPrincipal mainClaims;

            if (userSession != null)
            {
                mainClaims = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userSession.UserName),
                    new Claim(ClaimTypes.Email,userSession.Email),
                    new Claim(ClaimTypes.Role,userSession.Role)
                }, "JwtAuth"));

                await _sessionStorage.SaveStorage("sesionUsuario", userSession);
            }
            else
            {
                mainClaims = _sinInformacion;
                await _sessionStorage.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(mainClaims)));

        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var userSession = await _sessionStorage.GetStorage<UserDto>("userSession");

            if (userSession == null)
                return await Task.FromResult(new AuthenticationState(_sinInformacion));

            var mainClaims = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                   new Claim(ClaimTypes.Name,userSession.UserName),
                    new Claim(ClaimTypes.Email,userSession.Email),
                    new Claim(ClaimTypes.Role,userSession.Role)
                }, "JwtAuth"));


            return await Task.FromResult(new AuthenticationState(mainClaims));

        }
    }
}
