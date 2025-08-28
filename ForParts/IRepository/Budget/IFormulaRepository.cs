using ForParts.Models.Budgets;

namespace ForParts.IRepository
{
    public interface IFormulaRepositorio
    {
        Formula GetFormula(string codigoInsumo, string seriePerfil, string tipoProducto, string descripcion);
    }
}
