using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Models;
namespace Infrastructure.Services{
    public class SpecieService : ISpecieService{
        private readonly IRepository<Specie> _repository;
        private readonly IMapper _mapper;
        public SpecieService(IRepository<Specie> repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }
        public bool Create (SpecieCreateModel model){
            if (_repository.GetQuery().Any(x => x.Name == model.Name)){
                throw new ArgumentException("Назва виду повинна бути унікальною");
            }
            var specieEntity = _mapper.Map<Specie>(model);
            if (_repository.GetQuery().Any(s => s.Name == specieEntity.Name)){
                throw new ArgumentException("Назва виду повинна бути унікальною");
            }
            _repository.Add(_mapper.Map<Specie>(model));
            _repository.SaveChanges();
            return true;
        }
        public List<Specie> GetAll (){
            return _repository.GetQuery().ToList();
        }
        public Specie? GetById (int id) {
            return _repository.GetById(id);
        }
        public void Delete(int id){
            var specie = _repository.GetById(id);
            if (specie != null){
                _repository.Delete(specie);
                _repository.SaveChanges();
            }
        }
    }
}
