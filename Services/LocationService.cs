using AutoMapper;
using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Repositories.Interfaces;
using Code_Academy___Conference_Management_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Code_Academy___Conference_Management_System.Services
{
    public class LocationService : ILocationService
    {
        private readonly IGenericRepository<Location> _locationRepository;
        private readonly IMapper _mapper;

        private readonly Expression<Func<Location, object>>[] _includes = new Expression<Func<Location, object>>[] { };

        public LocationService(IGenericRepository<Location> locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<LocationVM> AddAsync(LocationVM model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<Location>(model);
            await _locationRepository.AddAsync(entity);

            var createdEntity = await _locationRepository.GetByIdAsync(entity.ID, _includes);

            return _mapper.Map<LocationVM>(createdEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _locationRepository.GetByIdAsync(id);
            if (existing == null) return false;

            await _locationRepository.SoftDeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<LocationVM>> GetAllAsync()
        {
            var entities = await _locationRepository.GetAllAsync(_includes);
            return _mapper.Map<IEnumerable<LocationVM>>(entities);
        }

        public async Task<LocationVM> GetByIdAsync(int id)
        {
            var entity = await _locationRepository.GetByIdAsync(id, _includes);
            return entity == null ? null : _mapper.Map<LocationVM>(entity);
        }

        public async Task UpdateAsync(LocationVM model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = await _locationRepository.GetByIdAsync(model.ID);
            if (entity == null)
                throw new KeyNotFoundException($"Location with id {model.ID} not found.");

            _mapper.Map(model, entity);
            await _locationRepository.UpdateAsync(entity);
        }
    }
}
