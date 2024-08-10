using Bunnisses.Security.Interface;
using Data.DTO;
using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers.Implements;
[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContexts _context;

    public LoginController(ApplicationDbContexts context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        // Buscar al usuario en la base de datos
        var user = await _context.user
            .FirstOrDefaultAsync(u => u.Nombre_usuario == loginRequest.UserId && u.Contraseña == loginRequest.Password && u.State);

        if (user != null)
        {
            //obtener los roles de los usarios
            var roles = await _context.user_role
            .Where(ur => ur.UserId == user.Id && ur.State)
            .Include(ur => ur.role) // Incluir la entidad Role
            .Select(ur => ur.role.Nombre) // Seleccionar solo el nombre del rol
            .ToListAsync();

            // Obtener las vistas asociadas a los roles
            var views = await _context.role_view
                .Where(rv => roles.Contains(rv.role.Nombre) && rv.State) 
                .Select(rv => rv.view.Nombre) 
                .ToListAsync();

            var response = new
            {
                
                Roles = roles,
                Views = views,
                User = user
            };

           
            return Ok(response);
        }
        else
        {
            return Unauthorized("Usuario o contraseña incorrectos.");
        }
    }

    

    public class LoginRequest
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}


    






    
