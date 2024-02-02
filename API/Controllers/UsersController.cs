using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    //private readonly DataContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    // commented out due to IRepository Pattern
    // public UsersController(DataContext context) // context is scope with http request and return http response and later this context is disposed
    // {
    //     this._context = context;
    // }

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        //var users = await _context.Users.ToListAsync();
        //return users;

        //return Ok(await _userRepository.GetUsersAsync());

        // var users = await _userRepository.GetUsersAsync();

        // var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);

        // return Ok(usersToReturn);

        var users = await _userRepository.GetMembersAsync();

        return Ok(users);
    }

    // [HttpGet("{id}")] // /api/users/2
    // public async Task<ActionResult<AppUser>> GetUser(int id)
    // {
    //     return await _context.Users.FindAsync(id);
    // }

    [HttpGet("{username}")] // /api/users/lisa
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        //return await _userRepository.GetUserByUsernameAsync(username);

        //var user = await _userRepository.GetUserByUsernameAsync(username);

        //return _mapper.Map<MemberDto>(user);

        return await _userRepository.GetMemberAsync(username);
    }
}
