using AutoMapper;
using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Repositories.Interfaces;
using Code_Academy___Conference_Management_System.Services.Interfaces;
using System.Linq.Expressions;

namespace Code_Academy___Conference_Management_System.Services
{
    public class EventService : IEventService
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        private readonly Expression<Func<Event, object>>[] _includes = new Expression<Func<Event, object>>[] { };

        public EventService(IGenericRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventVM> AddAsync(EventVM model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<Event>(model);
            await _eventRepository.AddAsync(entity);

            var createdEntity = await _eventRepository.GetByIdAsync(entity.ID, _includes);

            return _mapper.Map<EventVM>(createdEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _eventRepository.GetByIdAsync(id);
            if (existing == null) return false;

            await _eventRepository.SoftDeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<EventVM>> GetAllAsync()
        {
            var entities = await _eventRepository.GetAllAsync(_includes);
            return _mapper.Map<IEnumerable<EventVM>>(entities);
        }

        public async Task<EventVM> GetByIdAsync(int id)
        {
            var entity = await _eventRepository.GetByIdAsync(id, _includes);
            return entity == null ? null : _mapper.Map<EventVM>(entity);
        }

        public async Task UpdateAsync(EventVM model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = await _eventRepository.GetByIdAsync(model.ID);
            if (entity == null)
                throw new KeyNotFoundException($"Event with id {model.ID} not found.");

            _mapper.Map(model, entity);
            await _eventRepository.UpdateAsync(entity);
        }
    }
}
