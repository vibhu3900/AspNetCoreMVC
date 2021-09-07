using Microsoft.AspNetCore.Identity;
using OnlineGroceryStore.Models.SignInModel;
using OnlineGroceryStore.Models.SignUpUserModel;
using System.Threading.Tasks;

namespace OnlineGroceryStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();

    }
}