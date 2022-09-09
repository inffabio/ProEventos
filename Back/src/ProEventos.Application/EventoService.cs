using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        public IGeralPersist _geralPersist { get; }
        public IEventoPersist _eventoPersist { get; }

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
          
        }
        public async Task<Evento> AddEventos(Evento model)
        {
           try
           {
               _geralPersist.Add<Evento>(model);
               if (await _geralPersist.SaveChangesAsync())
               {
                 return await _eventoPersist.GetEventoByIdAsync(model.Id, false);

               }

               return null;

           }
           catch (Exception ex)
           {
            
            throw new Exception(ex.Message);
           }
        }

        public async Task<Evento> UpdateEvento(int EventoId, Evento model)
        {
           try
           {
            
            var evento = await _eventoPersist.GetEventoByIdAsync(EventoId, false);
               if (evento == null) return null; 

            model.Id = evento.Id;

            _geralPersist.Update(model);

              if (await _geralPersist.SaveChangesAsync())
               {
                 return await _eventoPersist.GetEventoByIdAsync(model.Id, false);

               }

               return null;

           }
           catch (Exception ex)
           {
            
             throw new Exception(ex.Message);
           }
        }

        public async Task<bool> DeleteEvento(int EventoId)
        {
            try
           {
            
            var evento = await _eventoPersist.GetEventoByIdAsync(EventoId, false);
               if (evento == null) throw new Exception("Evento parar delete não encontrado") ;

            _geralPersist.Delete(evento);

              return await _geralPersist.SaveChangesAsync();

           }
           catch (Exception ex)
           {
            
             throw new Exception(ex.Message);
           }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
           try
           {
             var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
             if (eventos == null) return null;

             return eventos;
           }
           catch (Exception ex)
           {
            
             throw new Exception(ex.Message);
           }
        }

        public async Task<Evento[]> GetAllEventosByTemasAsync(string tema, bool includePalestrantes = false)
        {
            try
           {
             var eventos = await _eventoPersist.GetAllEventosByTemasAsync(tema, includePalestrantes);
             if (eventos == null) return null;

             return eventos;
           }
           catch (Exception ex)
           {
            
             throw new Exception(ex.Message);
           }

        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
              try
           {
             var eventos = await _eventoPersist.GetEventoByIdAsync(EventoId, includePalestrantes);
             if (eventos == null) return null;

             return eventos;
           }
           catch (Exception ex)
           {
            
             throw new Exception(ex.Message);
           }
        }

        
    }
}
