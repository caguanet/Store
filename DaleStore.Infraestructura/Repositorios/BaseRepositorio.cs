using Microsoft.EntityFrameworkCore;
using DaleStore.Infraestructura.Data;

namespace DaleStore.Infraestructura.Repositorios
{
    public class BaseRepositorio<T> where T : class
    {
        private readonly DaleStoreContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepositorio(DaleStoreContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
    }
}
