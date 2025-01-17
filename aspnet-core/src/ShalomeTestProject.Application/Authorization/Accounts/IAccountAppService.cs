﻿using System.Threading.Tasks;
using Abp.Application.Services;
using ShalomeTestProject.Authorization.Accounts.Dto;

namespace ShalomeTestProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
