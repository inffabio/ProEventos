using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        public ProEventosContext _context { get; }

        public EventoPersist(ProEventosContext context)
        {
            _context = context;
           _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }



        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
           .Include(e => e.Lotes)
           .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
            query = query
            .OrderBy(e => e.Id)
            .Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemasAsync(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
             .Include(e => e.Lotes)
             .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
            query = query.OrderBy(e => e.Id)
                   .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }


    }
}
