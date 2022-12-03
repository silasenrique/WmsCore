using System.Linq.Expressions;
using Wms.Core.Domain.Owner.Models;
using Wms.Core.Persistence.Common.Repository;
using Wms.Core.Persistence.Configuration;

namespace Wms.Core.Persistence.CustomerPersistence.Repository;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context) : base(context) { }

    public void AddRange(List<Customer> customers)
    {
        _context.Customer.AddRange(customers);
    }

    public Customer? GetByIdWithoutInclude(Guid id)
    {
        Expression<Func<Customer, bool>> expression = e => e.Id == id;

        return Get(expression)?.FirstOrDefault();
    }

    public void DeleteRange(List<Customer> customers)
    {
        _dbSet.RemoveRange(customers);
    }
}