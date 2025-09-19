using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Entities;
using Backend.Context;
using Microsoft.EntityFrameworkCore;
using Backend.DTOs;
using Backend.Services;


namespace Backend.Controllers
{
    [ApiController] //.net reconoce esto como una api
    [Route("api/[controller]")]//ruta bae del controlador
    public class CarreraController : ControllerBase
    {
        private readonly CarreraService _carreraService; // variable privada que guarda una referencia de la base de datos
        public CarreraController(CarreraService carreraService)
        {
            _carreraService = carreraService;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<CarreraDTO>>> Get()
        {
            return Ok(await _carreraService.lista());
        }
    }
}

