using Infrastructure.Entities;
using Infrastructure.Models;
namespace Infrastructure.Interfaces{
    public interface ICustomerService{
        bool Create(CustomerCreateModel model);
        List<Customer> GetAll();
        Customer? GetById(int id);
        bool Delete(int id);
    }
}