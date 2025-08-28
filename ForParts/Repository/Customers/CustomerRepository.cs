using ForParts.Data;
using ForParts.IRepository.Customers;
using ForParts.Models.Customers;

namespace ForParts.Repository.Customers
{
    public class CustomerRepository : ICustomerRespository
    {

        private readonly ContextDb _context;

        public CustomerRepository(ContextDb context)
        {
            _context = context;
        }
        public void Add(Customer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> FindAll()
        {
            throw new NotImplementedException();
        }

        public Customer FindById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public void Update(Customer item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
