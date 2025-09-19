using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Entities;
using Backend.Context;
using Microsoft.EntityFrameworkCore;
using Backend.DTOs;


namespace Backend.Services
{
    public class CarreraService
    {
        private readonly AppDbContext _context; // variable privada que guarda una referencia de la base de datos
        public CarreraService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarreraDTO>> lista()
        {
            var listaDTO =new List<CarreraDTO>();
            var listaDB = await _context.Carreras.ToListAsync();

            foreach (var item in listaDB)
            {
                listaDTO.Add(new CarreraDTO
                {
                    IdCarrera = item.IdCarrera,
                    Nombre = item.Nombre,
                });
            }

            return listaDTO;
        }
    }
}