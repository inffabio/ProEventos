using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using AutoMapper;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        public IGeralPersist _geralPersist { get; }
        public IEventoPersist _eventoPersist { get; }
        public IMapper _mapper { get; }

        public EventoService(IGeralPersist geralPersist, 
                             IEventoPersist eventoPersist,
                             IMapper mapper)
        {
           
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
            _mapper = mapper;

        }
        public async Task<EventoDto> AddEventos(EventoDto model)
        {
          
           try
           {

              var evento = _mapper.Map<Evento>(model);
               _geralPersist.Add<Evento>(evento);
               if (await _geralPersist.SaveChangesAsync())
               {
                 var eventoRetorno = await _eventoPersist.GetEventoByIdAsync(evento.Id, false);
                  return _mapper.Map<EventoDto>(eventoRetorno);
               }

               return null;

           }
           catch (Exception ex)
           {
            
            throw new Exception(ex.Message);
           } 
        }

        public async Task<EventoDto> UpdateEvento(int EventoId, EventoDto model)
        {
         
            try
           {
            

            var evento = await _eventoPersist.GetEventoByIdAsync(EventoId, false);
               if (evento == null) return null; 

            model.Id = evento.Id;


            _mapper.Map(model, evento);
         
            _geralPersist.Update<Evento>(evento);

              if (await _geralPersist.SaveChangesAsync())
               {
              
                
               var eventoRetorno =  await _eventoPersist.GetEventoByIdAsync(evento.Id, false);

                return _mapper.Map<EventoDto>(eventoRetorno);

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

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
           try
           {
             var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
             if (eventos == null) return null;

             var resultado = _mapper.Map<EventoDto[]>(eventos);

             return resultado;
           }
           catch (Exception ex)
           {
            
             throw new Exception(ex.Message);
           }
        }

        public async Task<EventoDto[]> GetAllEventosByTemasAsync(string tema, bool includePalestrantes = false)
        {
            try
           {
             var eventos = await _eventoPersist.GetAllEventosByTemasAsync(tema, includePalestrantes);
             if (eventos == null) return null;

            
             var resultado = _mapper.Map<EventoDto[]>(eventos);

             return resultado;
           }
           catch (Exception ex)
           {
            
             throw new Exception(ex.Message);
           }

        }

        public async Task<EventoDto> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
              try
           {
             var evento = await _eventoPersist.GetEventoByIdAsync(EventoId, includePalestrantes);
             if (evento == null) return null;

            var resultado = _mapper.Map<EventoDto>(evento);

             return resultado;
           }
           catch (Exception ex)
           {
            
             throw new Exception(ex.Message);
           }
        }

        
    }
}
