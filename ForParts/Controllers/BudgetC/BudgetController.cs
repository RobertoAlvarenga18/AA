using ForParts.DTOs.Budget;
using ForParts.Exceptions.Budget;
using ForParts.Services;
using ForParts.IService.Buget;
using Microsoft.AspNetCore.Mvc;

namespace ForParts.Controllers.BudgetC
{
    public class BudgetController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]

        public class PresupuestoController : Controller
        {
            private readonly IBudgetService _budgetService;

            public PresupuestoController(IBudgetService budgetService)
            {
                _budgetService = budgetService;
            }

            [HttpPost("crearPresupuesto")]
            public IActionResult Crear([FromBody] BudgetCreateDto dto)
            {
                //Antes de ingresar a logica, valida los ModelState
                try
                {
                    var presupuesto = _budgetService.CreateBudgetAsync(dto);
                    return Ok(presupuesto);
                }
                catch (BudgetException ex)
                {
                    return BadRequest(new { state = 400, mensaje = ex.Message });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { mensaje = ex.Message });
                }
            }

        }
    }
}
