using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Models;
namespace Infrastructure.Services{
    public class AppointmentService : IAppointmentService{
        private readonly IRepository<Appointment> _repository;
        private readonly IMapper _mapper;
        public AppointmentService(IRepository<Appointment> repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }
        public bool Create(AppointmentCreateModel model){
            if (model.AnimalId <= 0)
                throw new ArgumentException("Не дійсне Id тварини");
            _repository.Add(_mapper.Map<Appointment>(model));
            _repository.SaveChanges();
            return true;
        }
        public List<Appointment> GetAll(){
            return _repository.GetQuery().ToList();
        }
        public Appointment? GetById(int id){
            return _repository.GetById(id);
        }
        public bool Delete(int id){
            var appointment = _repository.GetById(id);
            if (appointment != null){
                _repository.Delete(appointment);
                _repository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}