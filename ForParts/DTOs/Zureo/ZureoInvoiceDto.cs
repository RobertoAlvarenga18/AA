using ForParts.Models.Customers;
using ForParts.Models.Enums;
using ForParts.Models.Invoice;
using System.ComponentModel.DataAnnotations;
using ForParts.Models.Customers;
using CustomerAlias = ForParts.Models.Customers.Customer;

namespace ForParts.DTOs.Zureo
{
    public class ZureoInvoiceDto
    {

        [Key]
        public int InvoiceId { get; set; }
        public DateTime InvoiceDateCreate { get; set; } = DateTime.Today;
        public string InvoiceCompany { get; set; } = "ED Aluminios";
        public int InvoiceBranchOfCompanyId { get; set; } = 1;
        public string InvoiceCurrencyCode { get; set; } = "USD";
        public decimal TipoCambio { get; set; } = 1;
        public string InvoiceDescription { get; set; } = "Gracias por su compra.";
        public DateTime InvoiceExpirationDate { get; set; } = DateTime.Today.AddDays(30);
        public InvoiceState InvoiceState { get; set; } = InvoiceState.Pendiente;
        public DateTime? FechaEmision { get; set; }
        public string ZureoRespuesta { get; set; } = string.Empty;

        public int CustomerId { get; set; }
        public CustomerAlias Customer { get; set; } = null!;
        public List<InvoiceItem> Items { get; set; } = new();
    }
}

