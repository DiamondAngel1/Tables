using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Models;
namespace Infrastructure.Services{
    public class CustomerService : ICustomerService{
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;
        public CustomerService(IRepository<Customer> repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }
        public bool Create(CustomerCreateModel model){
            try{
                if (_repository.GetQuery().Any(x => x.Email == model.Email)){
                    throw new ArgumentException("Емейл повинен бути унікальним");
                }
                _repository.Add(_mapper.Map<Customer>(model));
                _repository.SaveChanges();
                return true;
            }
            catch (Exception ex){
                Console.WriteLine($"Помилка при створенні клієнта: {ex.Message}");
                return false;
            }
        }
        public List<Customer> GetAll (){
            return _repository.GetQuery().ToList();
        }
        public Customer? GetById (int id) {
            return _repository.GetById(id);
        }
        public bool Delete (int id){
            var customer = _repository.GetById(id);
            if (customer != null){
                _repository.Delete(customer);
                _repository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}