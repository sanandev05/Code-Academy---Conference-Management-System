using AutoMapper;
using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Models;
using Code_Academy___Conference_Management_System.Repositories.Interfaces;
using Code_Academy___Conference_Management_System.Services.Interfaces;
using System.Linq.Expressions;


namespace Code_Academy___Conference_Management_System.Services
{
    public class Organizer_Service : IOrganizerService
    {
        private readonly IGenericRepository<Organizer> _organizerRepository;
        private readonly IMapper _mapper;

        private readonly Expression<Func<Organizer, object>>[] _includes = new Expression<Func<Organizer, object>>[] { };

        public Organizer_Service(IGenericRepository<Organizer> organizerRepository, IMapper mapper)
        {
            _organizerRepository = organizerRepository;
            _mapper = mapper;
        }

        public async Task<OrganizerVM> AddAsync(OrganizerVM model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<Organizer>(model);

            await _organizerRepository.AddAsync(entity);

            var createdEntity = await _organizerRepository.GetByIdAsync(entity.ID, _includes);

            return _mapper.Map<OrganizerVM>(createdEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _organizerRepository.GetByIdAsync(id);
            if (existing == null) return false;

            await _organizerRepository.SoftDeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<OrganizerVM>> GetAllAsync()
        {
            var entities = await _organizerRepository.GetAllAsync(_includes);

            return _mapper.Map<IEnumerable<OrganizerVM>>(entities);
        }

        public async Task<OrganizerVM> GetByIdAsync(int id)
        {
            var entity = await _organizerRepository.GetByIdAsync(id, _includes);

            if (entity == null) return null;

            return _mapper.Map<OrganizerVM>(entity);
        }

        public async Task UpdateAsync(OrganizerVM model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = await _organizerRepository.GetByIdAsync(model.ID);
            if (entity == null)
                throw new KeyNotFoundException($"Organizer with id {model.ID} not found.");

            _mapper.Map(model, entity);

            await _organizerRepository.UpdateAsync(entity);
        }
    }
}
