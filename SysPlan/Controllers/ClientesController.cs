using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysPlan.Data;
using SysPlan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysPlan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteData _clienteData;
        public ClientesController(IClienteData clienteData)
        {
            _clienteData = clienteData;
        }

        [HttpGet]
      
        public IActionResult GetClientes()
        {
            return Ok(_clienteData.GetClientes());
        }

        [HttpGet("{id}")]
        public IActionResult GetClientes(Guid id)
        {
            var cliente = _clienteData.GetCliente(id);
            if (cliente!=null)
            {
                return Ok(cliente);
            }
            
            return NotFound($"Cliente com id: {id} não encontrado.");
            
        }

        [HttpPost]
      
        public IActionResult AddCliente(Cliente cliente)
        {

            _clienteData.AddCliente(cliente);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + cliente.Id, cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(Guid id)
        {
            var cliente = _clienteData.GetCliente(id);

            if (cliente != null)
            {
                _clienteData.DeleteCliente(cliente);
                return Ok($"Cliente com id: {id} foi excluido com sucesso.");
            }

            return NotFound($"Cliente com id: {id} não encontrado.");

        }

        [HttpPut("{id}")]
        public IActionResult EditCliente(Guid id, Cliente cliente)
        {
            var clienteAtual = _clienteData.GetCliente(id);


            if (clienteAtual != null)
            {
                cliente.Id = clienteAtual.Id;
                _clienteData.EditCliente(cliente);
                return Ok($"Cliente com id: {id} foi editado com sucesso.");
            }

            return NotFound($"Cliente com id: {id} não encontrado.");

        }
    }
}
