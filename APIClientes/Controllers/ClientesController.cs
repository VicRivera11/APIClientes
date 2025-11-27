using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIClientes.Context;
using APIClientes.Dtos;

namespace APIClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<ClienteDto>> TraeClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> TraeCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> CreaCliente(CreaClienteDto clienteNuevo)
        {
            var clienteParaGuardar = new ClienteDto
            {
                Nombre = clienteNuevo.Nombre,
                Apellidos = clienteNuevo.Apellidos,
                Correo = clienteNuevo.Correo,
                Telefono = clienteNuevo.Telefono,
                Direccion = clienteNuevo.Direccion
            };

            _context.Clientes.Add(clienteParaGuardar);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(TraeCliente), new { id = clienteParaGuardar.Id }, clienteParaGuardar);
        }

        [HttpPut]
        public async Task<ActionResult> ActualizaCliente(ClienteDto clienteActualizado)
        {
            var clienteExistente = await _context.Clientes.FindAsync(clienteActualizado.Id);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            clienteExistente.Nombre = clienteActualizado.Nombre;
            clienteExistente.Apellidos = clienteActualizado.Apellidos;
            clienteExistente.Correo = clienteActualizado.Correo;
            clienteExistente.Telefono = clienteActualizado.Telefono;
            clienteExistente.Direccion = clienteActualizado.Direccion;

            await _context.SaveChangesAsync();
            return Ok(clienteExistente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> EliminaCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}