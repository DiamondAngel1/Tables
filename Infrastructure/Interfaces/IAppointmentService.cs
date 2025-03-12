using Infrastructure.Entities;
using Infrastructure.Models;
namespace Infrastructure.Interfaces{
    public interface IAppointmentService{
        bool Create(AppointmentCreateModel model);
        List<Appointment> GetAll();
        Appointment? GetById(int id);
        bool Delete(int id);
    }
}
