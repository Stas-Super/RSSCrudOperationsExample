using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSSCrudOperationsExample.Business.Dtos.Account;
using RSSCrudOperationsExample.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.ApiServices.Controllers
{
    [ApiController]
    [Route("api/user/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAccountPasswordService _accountPasswordService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(
            IAccountService accountService,
            IAccountPasswordService accountPasswordService,
            ITokenService tokenService,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountPasswordService = accountPasswordService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gives to user rules
        /// </summary>
        /// <param name="dto">Login data transfer object</param>
        /// <returns>Returns user response data transfer object</returns>
        [HttpPost("log-in")]
        public async Task<IActionResult> LogInAsync([FromBody] LogInRequestDto dto)
        {
            var user = await _accountService.GetByEmailAsync(dto.Email);

            var passwordVarificationResult = _accountPasswordService.VarifyPassword(dto.Password, user);
            if(passwordVarificationResult == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
            {
                return Unauthorized("Password is not valid");
            }

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            userResponseDto.AccessToken = accessToken;
            userResponseDto.RefreshToken = refreshToken;

            return Ok(userResponseDto);
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="dto">registration data transfer object</param>
        /// <returns>Returns new user</returns>
        [HttpPost("create")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto dto)
        {
            var user = await _accountService.CreateAsync(dto);

            user.PasswordHash = _accountPasswordService.HashPassword(user, dto.Password);
            if(dto.Password == null)
            {
                return Unauthorized("password is empty");
            }

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            userResponseDto.RefreshToken = refreshToken;
            userResponseDto.AccessToken = accessToken;

            return Ok(userResponseDto);
        }


    }
}
