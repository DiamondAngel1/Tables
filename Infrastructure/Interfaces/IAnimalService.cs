using Infrastructure.Entities;
using Infrastructure.Models;
namespace Infrastructure.Interfaces{
    public interface IAnimalService{
        bool Create(AnimalCreateModel model);
        List<Animals> GetAll();
        Animals? GetById(int id);
        bool Delete(int id);
    }
}