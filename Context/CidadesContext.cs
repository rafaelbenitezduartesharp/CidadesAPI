using CidadeAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CidadeAPI.Context
{
    public class CidadesContext : DbContext
    {
        public CidadesContext(DbContextOptions<CidadesContext> options) : base(options)
        {

        }
        public DbSet<Cidades> Cidade { get; set; }
    }
}