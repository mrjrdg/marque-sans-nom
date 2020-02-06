using System;
using Services;
using Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Managers
{
    public class EntrepriseManagerSQL : IEntrepriseServices
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EntrepriseManagerSQL> _logger;

        public EntrepriseManagerSQL(AppDbContext context, ILogger<EntrepriseManagerSQL> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Entreprise> Create(Entreprise model)
        {
            var entreprise = await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return entreprise.Entity;

        }

        public async Task<Entreprise> Delete(int id)
        {
            Entreprise entreprise = await _context.Entreprise.FindAsync();

            if(entreprise != null)
            {
                _context.Entreprise.Remove(entreprise);
                await _context.SaveChangesAsync();
            }

            return entreprise;
        }

        public async Task<Entreprise> Edit(Entreprise model)
        {
            var entreprise = _context.Entreprise.Attach(model);
            entreprise.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return entreprise.Entity;

        }

        public async Task<Entreprise> Get(int id)
        {
            var entreprise = await _context.Entreprise.FindAsync(id);
            return entreprise;
        }
    }
}