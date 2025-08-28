using ForParts.Models.Budgets;
//using ForParts.ForParts

namespace ForParts.IRepository
{
    public interface IBudgetRepository
    {
        Task<Budget?> Add(Budget presupuesto);
    }
}