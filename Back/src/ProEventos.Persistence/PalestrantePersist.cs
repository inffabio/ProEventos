using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;

        public ProEventosContext Context { get; }
        public PalestrantePersist(ProEventosContext _context)
        {
            Context = _context;
        }


        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
          .Include(e => e.RedesSociais);

            if (includeEventos)
            {
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }
            query = query.OrderBy(p => p.Id)
                .Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
            .Include(pe => pe.RedesSociais);

            if (includeEventos)
            {
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }
            query = query.OrderBy(pe => pe.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
            .Include(e => e.RedesSociais);

            if (includeEventos)
            {
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }
            query = query.OrderBy(p => p.Id)
                .Where(p => p.Nome.ToLower().Contains(Nome.ToLower()));

            return await query.ToArrayAsync();
        }




    }
}
