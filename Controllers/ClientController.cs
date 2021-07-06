using System;
using System.Collections.Generic;
using Library_System.Models;
using Library_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("/clients")]
        public List<Client> GetAll()
        {
            return _clientService.GetAll();
        }

        [HttpGet("/client/{id}")]
        public ActionResult<Client> GetOne(int id)
        {
            return _clientService.GetOne(id);
        }

        [HttpPost("/client")]
        public Client Create(ClientDTO client)
        {
            return _clientService.Create(client);
        }

        [HttpPut("/client")]
        public Client Update(ClientDTO client)
        {
            return _clientService.Update(client);
        }

        [HttpDelete("/client/{id}")]
        public IActionResult Delete(int id)
        {
            var clientDelete = _clientService.GetOne(id);

            if(clientDelete == null)
            {
                return NotFound();
            }

            try
            {
                _clientService.Delete(clientDelete);

                return Ok();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}