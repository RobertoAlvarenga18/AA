using ForParts.DTOs.Budget;
using ForParts.IRepository.Generic;
using ForParts.Models;
using ForParts.Models.Budgets;

namespace ForParts.IService.Buget;

public interface IBudgetService 
{
    public Task <Budget> CreateBudgetAsync(BudgetCreateDto dto);

}
