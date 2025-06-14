using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Repositories.Interfaces;
using Code_Academy___Conference_Management_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Code_Academy___Conference_Management_System.Services
{
    public class EventTypeService : IEventTypeService
    {
        private readonly IEventTypeRepository _eventTypeRepository;

        public EventTypeService(IEventTypeRepository eventTypeRepository)
        {
            _eventTypeRepository = eventTypeRepository;
        }

        public async Task<EventTypeVM> AddAsync(EventTypeVM model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Event type view model cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("Event type name cannot be empty.", nameof(model.Name));
            }

            var entity = new EventType
            {
                Name = model.Name
            };

            await _eventTypeRepository.AddAsync(entity);

            return new EventTypeVM
            {
                ID = entity.ID,
                Name = entity.Name
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingEventType = await _eventTypeRepository.GetByIdAsync(id);
            if (existingEventType == null)
            {
                return false;
            }

            await _eventTypeRepository.SoftDeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<EventTypeVM>> GetAllAsync()
        {
            var entities = await _eventTypeRepository.GetAllAsync();

            return entities.Select(entity => new EventTypeVM
            {
                ID = entity.ID,
                Name = entity.Name
            }).ToList();
        }

        public async Task<EventTypeVM> GetByIdAsync(int id)
        {
            var entity = await _eventTypeRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return null;
            }

            return new EventTypeVM
            {
                ID = entity.ID,
                Name = entity.Name
            };
        }

        public async Task UpdateAsync(EventTypeVM model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Event type view model for update cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("Event type name cannot be empty.", nameof(model.Name));
            }

            var existingEntity = await _eventTypeRepository.GetByIdAsync(model.ID);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Event type with ID {model.ID} not found for update.");
            }

            existingEntity.Name = model.Name;

            await _eventTypeRepository.UpdateAsync(existingEntity);
        }
    }
}