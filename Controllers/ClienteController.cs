using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorClientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private static List<Cliente> clientes = new List<Cliente>();
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return clientes;
        }
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            Cliente cliente = null;
            foreach (var p in clientes)
            {
                if (p.Id == id)
                {
                    cliente = p;
                    break;
                }
            }
            if (cliente == null)
                return NotFound();
            return cliente;

        }
        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            cliente.Id = clientes.Count + 1;
            clientes.Add(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, Cliente clienteAtualizado)
        {
            Cliente cliente = null;

            foreach (var p in clientes)
            {
                if (p.Id == id)
                {
                    cliente = p;
                    break;
                }
            }
             if (cliente == null)
                return NotFound();

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;
            cliente.Telefone = clienteAtualizado.Telefone;

            return NoContent();
        }
         [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Cliente clienteParaRemover = null;

            foreach (var p in clientes)
            {
                if (p.Id == id)
                {
                    clienteParaRemover = p;
                    break;
                }
            }

            if (clienteParaRemover == null)
                return NotFound();

            clientes.Remove(clienteParaRemover);
            return NoContent();
        }
    }
}
