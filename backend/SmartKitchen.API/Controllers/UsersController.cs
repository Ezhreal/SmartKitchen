using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartkitchen.API.Data;
using Smartkitchen.API.DTO.Users;
using Smartkitchen.API.Models;
using Smartkitchen.API.Validators;
using System.Text.RegularExpressions;

namespace Smartkitchen.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly SmartKitchenContext _context;

        public UserController(SmartKitchenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] Users user)
        {
            try
            {
                var validator = new UserValidator();
                var validationResult = await validator.ValidateAsync(user);

                if (!validationResult.IsValid)
                {
                    return
                    BadRequest(validationResult.Errors);
                }

                user.PasswordHash = Helpers.HashHelper.GenerateHashPassword(user.Password);
                if (string.IsNullOrEmpty(user.Password))
                {
                    return StatusCode(500, "Erro ao gerar o hash da senha.");
                }

                var userDto = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                };

                _context.Add(user);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, userDto);
            }
            catch (Exception ex)
            {
                // Logar a exceção
                Console.WriteLine(ex);
                return StatusCode(500, "Erro ao criar o usuário.");
            }

        }

 

        [HttpGet]
        public IActionResult GetUser()
        {
            try {
                var users = _context.Users.Select(u => new UserDTO
                {
                    Id = u.Id,
                    Email = u.Email,
                    Name = u.Name
                }).ToList();

                if (users == null)
                {
                    return NotFound();
                }


                return Ok(users);
            }
            catch (Exception ex)
            {
                // Logar a exceção
                Console.WriteLine(ex);
                return StatusCode(500, "Erro ao buscar a lista de usuários.");
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {

            try
            {
                var user = _context.Users.Find(id);

                if (user == null)
                {
                    return NotFound();
                }

                var userDto = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                };
                return Ok(user);
            }

            catch (Exception ex)
            {
                // Logar a exceção
                Console.WriteLine(ex);
                return StatusCode(500, "Erro ao buscar o usuário");
            }
          
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync (int id, [FromBody] UserDTO userDTO)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    return NotFound();
                }


                var validator = new UserDTOValidator();
                var validationResult = await validator.ValidateAsync(userDTO);

                if (!validationResult.IsValid)
                {
                    return
                    BadRequest(validationResult.Errors);

                }
                // Atualiza as propriedades do usuário com os dados do DTO
                user.Name = userDTO.Name;
                user.Email = userDTO.Email;
                _context.SaveChanges();

                return NoContent();

            }
            catch (Exception ex)
            {
                // Logar a exceção
                Console.WriteLine(ex);
                return StatusCode(500, "Erro au atualizar o usuário");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
          

            try
            {
                var user = _context.Users.Find(id);

                if (user == null)
                {
                    return NotFound();
                }
                _context.Remove(user);
                _context.SaveChanges();

                return NoContent();
            }

            catch (Exception ex)
            {
                // Logar a exceção
                Console.WriteLine(ex);
                return StatusCode(500, "Erro ao deletar o usuário");
            }
        }

    }
}
