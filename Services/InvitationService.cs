using AutoMapper;
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
    public class InvitationService : IInvitationService
    {
        private readonly IGenericRepository<Invitation> _invitationRepository;
        private readonly IMapper _mapper;

        private readonly Expression<Func<Invitation, object>>[] _includes = new Expression<Func<Invitation, object>>[]
        {
            i => i.Event,
            i => i.User
        };

        public InvitationService(IGenericRepository<Invitation> invitationRepository, IMapper mapper)
        {
            _invitationRepository = invitationRepository;
            _mapper = mapper;
        }

        public async Task<InvitationVM> AddAsync(InvitationVM model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var allInvitations = await _invitationRepository.GetAllAsync();
            var exists = allInvitations.Any(i => i.EventId == model.EventId && i.UserId == model.UserId);

            if (exists)
                throw new InvalidOperationException("This user is already invited to this event.");

            var entity = _mapper.Map<Invitation>(model);
            await _invitationRepository.AddAsync(entity);

            var created = await _invitationRepository.GetByIdAsync(entity.ID, _includes);
            return _mapper.Map<InvitationVM>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _invitationRepository.GetByIdAsync(id);
            if (existing == null) return false;

            await _invitationRepository.SoftDeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<InvitationVM>> GetAllAsync()
        {
            var invitations = await _invitationRepository.GetAllAsync(_includes);
            return _mapper.Map<IEnumerable<InvitationVM>>(invitations);
        }

        public async Task<InvitationVM> GetByIdAsync(int id)
        {
            var entity = await _invitationRepository.GetByIdAsync(id, _includes);
            return entity == null ? null : _mapper.Map<InvitationVM>(entity);
        }

        public async Task UpdateAsync(InvitationVM model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var entity = await _invitationRepository.GetByIdAsync(model.ID);
            if (entity == null)
                throw new KeyNotFoundException($"Invitation with ID {model.ID} not found.");

            _mapper.Map(model, entity);
            await _invitationRepository.UpdateAsync(entity);
        }
    }
}
