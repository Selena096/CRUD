using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Entities;
using Backend.Context;
using Microsoft.EntityFrameworkCore;
using Backend.DTOs;


namespace Backend.Services
{
    public class EstudianteServicie
    {
        private readonly AppDbContext _context;
        public EstudianteServicie(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<EstudianteDTO>> lista()
        {
            var listaDTO = new List<EstudianteDTO>();
            var listaDB = await _context.Estudiantes.Include(c => c.Carrera).ToListAsync();

            foreach (var item in listaDB)
            {
                listaDTO.Add(new EstudianteDTO
                {
                    IdEstudiante = item.IdEstudiante,
                    NombreCompleto = item.NombreCompleto,
                    Telefono = item.Telefono,
                    Activo = item.Activo,
                    IdCarrera = item.IdCarrera,
                    NombreCarrera = item.Carrera.Nombre
                });
            }

            return listaDTO;
        }

        public async Task<EstudianteDTO> buscar(int IdEstudiante)
        {
            var estudianteDB = await _context.Estudiantes
                .Include(c => c.Carrera)
                .Where(e => e.IdEstudiante == IdEstudiante)
                .FirstAsync();

            return new EstudianteDTO
            {
                IdEstudiante = estudianteDB.IdEstudiante,
                NombreCompleto = estudianteDB.NombreCompleto,
                Telefono = estudianteDB.Telefono,
                Activo = estudianteDB.Activo,
                IdCarrera = estudianteDB.IdCarrera,
                NombreCarrera = estudianteDB.Carrera.Nombre
            };
        }

        public async Task<string> guardar(EstudianteDTO estudianteDTO)
        {
            var estudianteDB = new Estudiante
            {
                NombreCompleto = estudianteDTO.NombreCompleto,
                Telefono = estudianteDTO.Telefono,
                Activo = estudianteDTO.Activo,
                IdCarrera = estudianteDTO.IdCarrera,
            };

            await _context.Estudiantes.AddAsync(estudianteDB);
            await _context.SaveChangesAsync();

            return "Estudiante Agregado";
        }

        public async Task<string> editar(EstudianteDTO estudianteDTO)
        {
            var estudianteDB = await _context.Estudiantes
                .Include(e => e.Carrera)
                .Where(e => e.IdEstudiante == estudianteDTO.IdEstudiante)
                .FirstAsync();

            estudianteDB.NombreCompleto = estudianteDTO.NombreCompleto;
            estudianteDB.Telefono = estudianteDTO.Telefono;
            estudianteDB.Activo = estudianteDTO.Activo;
            estudianteDB.IdCarrera = estudianteDTO.IdCarrera;

            _context.Estudiantes.Update(estudianteDB);
            await _context.SaveChangesAsync();

            return "Estudiante Modificado";
        }
         public async Task<string> eliminar(int IdEstudiante)
        {
            var estudianteDB = await _context.Estudiantes.FindAsync(IdEstudiante);

            if (estudianteDB == null)
                return "Estudiante no encontrado";

            _context.Estudiantes.Remove(estudianteDB);
            await _context.SaveChangesAsync();

            return "Eliminado Correctamente";
        }

        
    }

}