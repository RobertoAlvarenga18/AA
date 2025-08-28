using ForParts.Data;
using ForParts.IRepository;
using ForParts.Models.Budgets;

namespace ForParts.Repository
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly ContextDb _context;

        public BudgetRepository(ContextDb context)
        {
            _context = context;
        }

        public async Task<Budget?> Add(Budget presupuesto)
        { 
             await _context.Budgets.AddAsync(presupuesto);
             await _context.SaveChangesAsync();

            return presupuesto;
        } 
    }
}
