
using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.DAL
{
    public class DrinkDal
    {
        private readonly TacoDbContext _context;

        public DrinkDal(TacoDbContext context)
        {
            _context = context;
        }

        public List<Drink> GetDrinks(string sortByCost)
        {
            List<Drink> query = _context.Drink.ToList();

            if (sortByCost == "ascending")
            {
                query = query.OrderBy(d=>d.Cost).ToList();
            }
            else if (sortByCost == "descending")
            {
                query = query.OrderByDescending(d => d.Cost).ToList();
            }

            return query;
        }

        public Drink GetDrinkById(int id)
        {
            return _context.Drink.FirstOrDefault(d => d.ID == id);
        }

        public Drink AddDrink(Drink newDrink)
        {
            _context.Drink.Add(newDrink);
            _context.SaveChanges();
            return newDrink;
        }

        public void UpdateDrink(Drink drink)
        {
            _context.Drink.Update(drink);
            _context.SaveChanges();
        }

        public void DeleteDrink(int id)
        {
            var drink = _context.Drink.FirstOrDefault(d => d.ID == id);
            if (drink != null)
            {
                _context.Drink.Remove(drink);
                _context.SaveChanges();
            }
        }
    }
}
