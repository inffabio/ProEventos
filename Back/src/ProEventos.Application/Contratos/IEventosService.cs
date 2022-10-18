using System;
using System.Threading.Tasks;
using ProEventos.Application.Dtos;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<EventoDto> AddEventos(EventoDto model);
        Task<EventoDto> UpdateEvento(int EventoId, EventoDto model);
        Task<bool> DeleteEvento(int EventoId);


        Task<EventoDto[]> GetAllEventosByTemasAsync(string tema, bool includePalestrantes = false);
        Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<EventoDto> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false);

    }
}
