//using BusinessLogic.authorization;
//using Domain.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MapsterMapper;
//using BusinessLogic.Helpers;
//using Microsoft.Extensions.Options;
//using BusinessLogic.Models.Accounts;
//using Domain.Models;
//using Microsoft.EntityFrameworkCore.Update;
//using System.Data;

//namespace BusinessLogic.Services
//{
//    public class AccountService : IAccountService
//    {
//        private readonly IRepositoryWrapper _repositoryWrapper;
//        private readonly IJwtUtils _jwtUtils;
//        private readonly IMapper _mapper;
//        private readonly AppSettings _appSettings;
//        private readonly IEmailService _emailService;

//        public AccountService(
//            IRepositoryWrapper repositoryWrapper,
//            IJwtUtils jwtUtils, 
//            IMapper mapper, 
//            IOptions<AppSettings> appSettings, 
//            IEmailService emailService)
//        {
//            _repositoryWrapper = repositoryWrapper;
//            _jwtUtils = jwtUtils;
//            _mapper = mapper;
//            _appSettings = appSettings.Value;
//            _emailService = emailService;
//        }

//        public Task<AccountResponse> Create(CreateRequest model)
//        {
//            throw new NotImplementedException();
//        }

//        public Task Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task ForgotPassword(ForgotPasswordRequest model, string origin)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IEnumerable<AccountResponse>> GetAll()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<AccountResponse> GetById(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<AuthenticateResponse> RefreshToken(string token, string ipAddress)
//        {
//            throw new NotImplementedException();
//        }

//        public Task Register(RegisterRequest model, string origin)
//        {
//            throw new NotImplementedException();
//        }

//        public Task ResetPassword(ResetPasswordRequest model)
//        {
//            throw new NotImplementedException();
//        }

//        public Task RevokeToken(string token, string ipAddress)
//        {
//            throw new NotImplementedException();
//        }

//        public Task ValidateResetToken(ValidateResetTokenRequest model)
//        {
//            throw new NotImplementedException();
//        }

//        public Task VerifyEmail(string token)
//        {
//            throw new NotImplementedException();
//        }

//        Task<AccountResponse> IAccountService.Update(int id, UpdateRequest model)
//        {
//            throw new NotImplementedException();
//        }

//        private void removeOldRefreshToken(User account)
//        {
//            account.RefreshTokens.RemoveAll(x =>
//                !x.IsActive &&
//                x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
//        }

//        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress)
//        {
//            var account = await _repositoryWrapper.User.GetByEmailWithToken(model.Email);

//            if (account == null || !account.IsVerified || !BCrypt.Net.BCrypt.Verify(model.Password, account.PasswordHash))
//                throw new AppException("Email or password is incorrect");

//            var jwtToken = _jwtUtils.GenerateJwtToken(account);

//            // Дожидаемся завершения задачи для получения RefreshToken
//            var refreshTokenTask = _jwtUtils.GenerateRefreshToken(ipAddress);
//            var refreshToken = await refreshTokenTask;

//            account.RefreshTokens.Add(refreshToken);

//            removeOldRefreshToken(account);

//            await _repositoryWrapper.User.Update(account);
//            await _repositoryWrapper.Save();

//            var response = _mapper.Map<AuthenticateResponse>(account);
//            response.JwtToken = jwtToken;
//            response.RefreshToken = refreshToken.Token;

//            return response;
//        }
//    }
//}