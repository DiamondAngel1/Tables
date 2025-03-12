using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Models;
namespace Infrastructure.Services{
    public class AnimalService : IAnimalService{
        private readonly IRepository<Animals> _repository;
        private readonly IRepository<Specie> _specieRepository;
        private readonly IMapper _mapper;
        public AnimalService(IRepository<Animals> repository, IRepository<Specie> specieRepository, IMapper mapper){
            _repository = repository;
            _specieRepository = specieRepository;
            _mapper = mapper;
        }
        public bool Create(AnimalCreateModel model){
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("Імя тварини не може біти пусте");
            if (!_specieRepository.GetQuery().Any(x => x.Id == model.SpecieId))
                throw new ArgumentException("Такого виду не знайдено");
            if (string.IsNullOrWhiteSpace(model.Description))
                throw new ArgumentException("Опис тварини не може бути пустим");
            if (!_repository.GetQuery().Any(x => x.Name == model.Name)){
                _repository.Add(_mapper.Map<Animals>(model));
                _repository.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Animals> GetAll(){
            return _repository.GetQuery().ToList();
        }
        public Animals? GetById(int id) {
            return _repository.GetById(id);
        }
        public bool Delete(int id){
            var animal = _repository.GetById(id);
            if (animal != null){
                _repository.Delete(animal);
                _repository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}