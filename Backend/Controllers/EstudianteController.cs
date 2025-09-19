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
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteServicie _estudianteServicie;
        public EstudianteController(EstudianteServicie estudianteServicie)
        {
            _estudianteServicie = estudianteServicie;
        }

        //listar estudiantes
        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<EstudianteDTO>>> Get()
        {
            return Ok(await _estudianteServicie.lista());
        }

        [HttpGet]
        [Route("buscar/{IdEstudiante}")]
        public async Task<ActionResult<EstudianteDTO>> Get(int IdEstudiante)
        {
            var EstudianteDTO = await _estudianteServicie.buscar(IdEstudiante); 
            if (EstudianteDTO == null)
                return NotFound("Estudiante no encontrado");

            return Ok(EstudianteDTO);
        }

        [HttpPost]
        [Route("guardar")]
        public async Task<ActionResult<EstudianteDTO>> guardar(EstudianteDTO estudianteDTO)
        {
            var mensaje = await _estudianteServicie.guardar(estudianteDTO);
            return Ok(mensaje);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<ActionResult<EstudianteDTO>> Editar(EstudianteDTO estudianteDTO)
        {
            var mensaje = await _estudianteServicie.editar(estudianteDTO);
            return Ok(mensaje);
        }
 
        [HttpDelete]
        [Route("eliminar/{IdEstudiante}")]
        public async Task<ActionResult<EstudianteDTO>> Eliminar(int IdEstudiante)
        {
            var mensaje = await _estudianteServicie.eliminar(IdEstudiante); 
            if (mensaje == "Estudiante no encontrado")
                return NotFound(mensaje);

            return Ok(mensaje);
        }
    }
}
