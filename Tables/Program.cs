using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Interfaces;
using Infrastructure.Models;
namespace Tables{
    internal class Program{
        static void Main(string[] args){
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            var sp = DIConfiguration.GetServiceProvider();
            var specieService = sp.GetService<ISpecieService>();
            var animalService = sp.GetService<IAnimalService>();
            var customerService = sp.GetService<ICustomerService>();
            var appointmentService = sp.GetService<IAppointmentService>();
            var medicalRecordService = sp.GetService<IMedicalRecordService>();
            int option = 1;
            do{
                Console.WriteLine("Оберіть варіант: ");
                Console.WriteLine("1. Додати дані");
                Console.WriteLine("2. Вивести всі дані");
                Console.WriteLine("3. Видалити всі дані");
                Console.WriteLine("0. Вийти");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice){
                    case 0:
                        option = 0;
                        break;
                    case 1:
                        try{
                            try{
                                var newSpecie1 = new SpecieCreateModel { Name = "Собака" };
                                var newSpecie2 = new SpecieCreateModel { Name = "Кіт" };
                                var newSpecie3 = new SpecieCreateModel { Name = "Хом'як" };
                                specieService.Create(newSpecie1);
                                specieService.Create(newSpecie2);
                                specieService.Create(newSpecie3);
                            }
                            catch (Exception ex){
                                Console.WriteLine($"Помилка при додаванні виду: {ex.Message}");
                            }
                            try{
                                var newAnimal1 = new AnimalCreateModel { Name = "Рижий", SpecieId = 1, Age = 8, Description = "Завжди весела собака" };
                                var newAnimal2 = new AnimalCreateModel { Name = "Пушок", SpecieId = 3, Age = 2, Description = "Комочок щастя :)" };
                                animalService.Create(newAnimal1);
                                animalService.Create(newAnimal2);
                            }
                            catch (Exception ex){
                                Console.WriteLine($"Помилка при додаванні тварини: {ex.Message}");
                            }
                            try{
                                var newCustomer1 = new CustomerCreateModel { Name = "Мудрий Семен Іванович ", Phone = "+(380) 66 046 8593", Email = "mudriy98@ua.fm", Address = "М.Луцьк, просп.Грушевського" };
                                var newCustomer2 = new CustomerCreateModel { Name = "Квітка Леся Миколаївна", Phone = "+(380) 95 877 2643", Email = "lesiakvitka@gmail.com", Address = "М.Луцьк, вул.Лесі країнки" };
                                customerService.Create(newCustomer1);
                                customerService.Create(newCustomer2);
                            }
                            catch (Exception ex){
                                Console.WriteLine($"Помилка при додаванні клієнта: {ex.Message}");
                            }
                            try{
                                var newAppointment1 = new AppointmentCreateModel { AnimalId = 1, Date = DateTime.SpecifyKind(DateTime.Now.AddDays(-1), DateTimeKind.Utc), Description = "Плановий огляд" };
                                var newAppointment2 = new AppointmentCreateModel { AnimalId = 2, Date = DateTime.SpecifyKind(DateTime.Now.AddDays(-4), DateTimeKind.Utc), Description = "Болить живіт" };
                                appointmentService.Create(newAppointment1);
                                appointmentService.Create(newAppointment2);
                            }
                            catch (Exception ex){
                                Console.WriteLine($"Помилка при додаванні запису на прийом: {ex.Message}");
                            }
                            try{
                                var newRecord1 = new MedicalRecordCreateModel { AnimalId = 1, VisitDate = DateTime.SpecifyKind(DateTime.Now.AddDays(-1), DateTimeKind.Utc), Diagnosis = "Здоровий", Treatment = "Немає" };
                                var newRecord2 = new MedicalRecordCreateModel { AnimalId = 2, VisitDate = DateTime.SpecifyKind(DateTime.Now.AddDays(-2), DateTimeKind.Utc), Diagnosis = "Болить живіт через те що багато хомячив", Treatment = "Прописано дієту" };
                                medicalRecordService.Create(newRecord1);
                                medicalRecordService.Create(newRecord2);
                            }
                            catch (Exception ex){
                                Console.WriteLine($"Помилка при додаванні медичного запису: {ex.Message}");
                            }
                            Console.WriteLine("Дані додані");
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Загальна помилка при додаванні даних: {ex.Message}");
                        }
                        break;
                    case 2:
                        try{
                            Console.WriteLine("Список всіх видів: ");
                            var species = specieService.GetAll();
                            foreach (var s in species){
                                Console.WriteLine($"{s.Id}. {s.Name}");
                            }
                            Console.WriteLine("Список всіх клієнтів: ");
                            var customers = customerService.GetAll();
                            foreach (var c in customers){
                                Console.WriteLine($"{c.Id}. {c.Name} - {c.Phone}, {c.Email}, {c.Address}");
                            }
                            Console.WriteLine("Список всіх записів на прийом: ");
                            var appointments = appointmentService.GetAll();
                            foreach (var a in appointments){
                                Console.WriteLine($"{a.Id}. ID Тварини: {a.AnimalId}, Дата: {a.Date}, Опис: {a.Description}");
                            }
                            Console.WriteLine("Список всіх медичних записів: ");
                            var records = medicalRecordService.GetAll();
                            foreach (var r in records){
                                Console.WriteLine($"{r.Id}. ID Тварини: {r.AnimalId}, Дата відвідування: {r.VisitDate}, Діагноз: {r.Diagnosis}, Лікування: {r.Treatment}");
                            }
                            Console.WriteLine("Список всіх тварин: ");
                            var animals = animalService.GetAll();
                            foreach (var animal in animals){
                                Console.WriteLine($"{animal.Id}. {animal.Name} - {animal.SpecieId}, {animal.Age}, {animal.Description}");
                            }
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Помилка при виведенні даних: {ex.Message}");
                        }
                        break;
                    case 3:
                        try{
                            Console.WriteLine("Видалення всіх видів...");
                            var allSpecies = specieService.GetAll();
                            foreach (var specie in allSpecies){
                                specieService.Delete(specie.Id);
                            }
                            Console.WriteLine("Видалення всіх клієнтів...");
                            var allCustomers = customerService.GetAll();
                            foreach (var customer in allCustomers){
                                customerService.Delete(customer.Id);
                            }
                            Console.WriteLine("Видалення всіх записів на прийом...");
                            var allAppointments = appointmentService.GetAll();
                            foreach (var appointment in allAppointments){
                                appointmentService.Delete(appointment.Id);
                            }
                            Console.WriteLine("Видалення всіх медичних записів...");
                            var allRecords = medicalRecordService.GetAll();
                            foreach (var record in allRecords){
                                medicalRecordService.Delete(record.Id);
                            }
                            Console.WriteLine("Видалення всіх тварин...");
                            var allAnimals = animalService.GetAll();
                            foreach (var animal in allAnimals){
                                animalService.Delete(animal.Id);
                            }
                            Console.WriteLine("Всі дані видалені");
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Помилка при видаленні даних: {ex.Message}");
                        }
                        break;
                }
            } while (option != 0);
        }
    }
}