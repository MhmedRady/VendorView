using VendorView.Domain;
using VendorView.Shared;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;

namespace VendorView.Application;

public class ApplicationUserManager : IApplicationUserManager
{
    public Task<OperationResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult> ForgotPasswordAsync(ForgotPasswordDto model)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResultDto> Login(LoginDto model)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult> ResetPasswordAsync(ResetPasswordDto model)
    {
        throw new NotImplementedException();
    }

    public Task AddPermissionClaim(ApplicationUser applicationUser, string role, string module)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UsersCountInRole> GetUsersCountInRole()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<VendorDto>> GetAll(Expression<Func<ApplicationUser, bool>> expression, int? take, int? skip, Expression<Func<ApplicationUser, object>> orderBy,
        string orderDirection = Constanties.ORDERASC, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<VendorDto>> GetAll(Expression<Func<ApplicationUser, bool>> expression, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public VendorDto GetBy(Expression<Func<ApplicationUser, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<VendorDto> GetById(string Id)
    {
        throw new NotImplementedException();
    }

    public Task<ApplicationUser> GetModelById(string Id)
    {
        throw new NotImplementedException();
    }

    public Task<VendorDto> AddAsync(CreateUserInput dto)
    {
        throw new NotImplementedException();
    }

    public VendorDto Add(CreateUserInput dto)
    {
        throw new NotImplementedException();
    }

    public Task<VendorDto> Update(CreateUserInput dto, string id)
    {
        throw new NotImplementedException();
    }

    public bool Remove(ApplicationUser entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistedAsync(Expression<Func<ApplicationUser, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public bool IsExisted(Expression<Func<ApplicationUser, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public int Count(Expression<Func<ApplicationUser, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<List<IdentityRoleClaim<string>>> GetUserPermisson(string userid)
    {
        throw new NotImplementedException();
    }
}


