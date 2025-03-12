using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Models;
namespace Infrastructure.Services{
    public class MedicalRecordService : IMedicalRecordService{
        private readonly IRepository<MedicalRecord> _repository;
        private readonly IMapper _mapper;
        public MedicalRecordService(IRepository<MedicalRecord> repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }
        public bool Create (MedicalRecordCreateModel model){
            if (model.AnimalId <= 0)
                throw new ArgumentException("Не дійсне Id тварини");
            _repository.Add(_mapper.Map<MedicalRecord>(model));
            _repository.SaveChanges();
            return true;
        }
        public List<MedicalRecord> GetAll(){
            return _repository.GetQuery().ToList();
        }
        public MedicalRecord? GetById(int id){
            return _repository.GetById(id);
        }
        public bool Delete(int id){
            var record = _repository.GetById(id);
            if (record != null){
                _repository.Delete(record);
                _repository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
