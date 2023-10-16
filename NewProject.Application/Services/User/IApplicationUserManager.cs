using VendorView.Domain;
using VendorView.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using VendorView.Domain.BaseEntities;
using System.Linq.Expressions;

namespace VendorView.Application;

public interface IApplicationUserManager
{
    Task<OperationResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
    Task<OperationResult> ForgotPasswordAsync(ForgotPasswordDto model);
    Task<LoginResultDto> Login(LoginDto model);
    Task<OperationResult> ResetPasswordAsync(ResetPasswordDto model);
    Task AddPermissionClaim(ApplicationUser applicationUser, string role, string module);
    IEnumerable<UsersCountInRole> GetUsersCountInRole();
    public Task<IEnumerable<VendorDto>> GetAll(Expression<Func<ApplicationUser, bool>> expression, int? take, int? skip,
    Expression<Func<ApplicationUser, object>> orderBy,
    string orderDirection = Constanties.ORDERASC, params string[] includes);
    public Task<IEnumerable<VendorDto>> GetAll(Expression<Func<ApplicationUser, bool>> expression, params string[] includes);
    public VendorDto GetBy(Expression<Func<ApplicationUser, bool>> expression);
    public Task<VendorDto> GetById(string Id);
    public Task<ApplicationUser> GetModelById(string Id);
    public Task<VendorDto> AddAsync(CreateUserInput dto);
    public VendorDto Add(CreateUserInput dto);
    public Task<VendorDto> Update(CreateUserInput dto, string id);
    public bool Remove(ApplicationUser entity);
    Task<bool> IsExistedAsync(Expression<Func<ApplicationUser, bool>> expression);
    bool IsExisted(Expression<Func<ApplicationUser, bool>> expression);
    int Count(Expression<Func<ApplicationUser, bool>> expression);
    public Task<List<IdentityRoleClaim<string>>> GetUserPermisson(string userid);
}
