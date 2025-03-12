using Infrastructure.Entities;
using Infrastructure.Models;
namespace Infrastructure.Interfaces{
    public interface IMedicalRecordService{
        bool Create(MedicalRecordCreateModel model);
        List<MedicalRecord> GetAll();
        MedicalRecord? GetById(int id);
        bool Delete(int id);
    }
}