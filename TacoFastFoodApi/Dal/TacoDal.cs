
using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.DAL
{

    public class TacoDal
    {
        private readonly TacoDbContext _context;

        public TacoDal(TacoDbContext context)
        {
            _context = context;
        }

        public List<Taco> GetTacos(bool? softShell)
        {
            IQueryable<Taco> query = _context.Taco;

            if (softShell.HasValue)
            {
                query = query.Where(t => t.SoftShell == softShell.Value);
            }
            {
                 query = query.Where(t => t.SoftShell == softShell.Value);
            }
            
            return query.ToList();
        }

        public Taco GetTacosById(int id)
        {
            return _context.Taco.FirstOrDefault(d => d.ID == id);
        }

        public Taco AddTaco(Taco newTaco)
        {
            _context.Taco.Add(newTaco);
            _context.SaveChanges();
            return newTaco;
        }

        public void UpdateTaco(Taco taco)
        {
            _context.Taco.Update(taco);
            _context.SaveChanges();
        }
        public bool DeleteTaco(int id)
        {
            var taco = _context.Taco.FirstOrDefault(t => t.ID == id);
            if (taco == null)
            {
                return false;
            }

            _context.Taco.Remove(taco);
            _context.SaveChanges();
            return true;
        }
    }
}

