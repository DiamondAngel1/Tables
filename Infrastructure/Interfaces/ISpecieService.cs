using Infrastructure.Entities;
using Infrastructure.Models;
namespace Infrastructure.Interfaces{
    public interface ISpecieService{
        bool Create(SpecieCreateModel model);
        List<Specie> GetAll();
        Specie? GetById(int id);
        void Delete(int id);
    }
}