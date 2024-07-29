using AutoMapper;
using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models.PetRegistration;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Services
{
    public class PetRegistrationService
    {
        private readonly PetRegistrationDbContext _context;
        private readonly IMapper _mapper;

        public PetRegistrationService(PetRegistrationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PetRegistrationDto>> GetAllAsync()
        {
            var registrations = await _context.TblPetRegistration.ToListAsync();
            return _mapper.Map<IEnumerable<PetRegistrationDto>>(registrations);
        }

        public async Task<PetRegistrationDto?> GetByIdAsync(string petRegistrationID)
        {
            var registration = await _context.TblPetRegistration.FindAsync(petRegistrationID);
            if (registration == null) return null;

            return _mapper.Map<PetRegistrationDto>(registration);
        }

        public async Task<PetRegistrationDto> CreateAsync(PetRegistrationDto dto, string userId)
        {
            var registration = _mapper.Map<PetRegistrationModel>(dto);
            registration.ClientID = userId;

            _context.TblPetRegistration.Add(registration);
            await _context.SaveChangesAsync();

            return _mapper.Map<PetRegistrationDto>(registration);
        }

        public async Task<bool> UpdateAsync(string petRegistrationID, PetRegistrationDto dto)
        {
            var registration = await _context.TblPetRegistration.FindAsync(petRegistrationID);
            if (registration == null) return false;

            _mapper.Map(dto, registration);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string petRegistrationID)
        {
            var registration = await _context.TblPetRegistration.FindAsync(petRegistrationID);
            if (registration == null) return false;

            _context.TblPetRegistration.Remove(registration);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PetRegistrationModel> GetPetRegistrationWithClientAsync(string petRegistrationId)
        {
            return await _context.TblPetRegistration
                .Include(pr => pr.Client) // Load related ApplicationUser
                .FirstOrDefaultAsync(pr => pr.PetRegistrationID == petRegistrationId);
        }
    }
}
