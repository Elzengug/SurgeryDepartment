using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SurgeryDepartment.Interfaces.Services;
using SurgeryDepartment.Models.DomainModels;
using SurgeryDepartment.Models.EF;
using SurgeryDepartment.Services;

namespace SurgeryDepartment.Infastructure.DI
{
    public class AutofacConfig
    {
        public IDependencyResolver ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            builder.RegisterType<SurgeryDepartmentDbContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterType<PatientDiseaseService>().As<IPatientDiseaseService>().InstancePerRequest();
            builder.RegisterType<PatientService>().As<IPatientService>().InstancePerRequest();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerRequest();
            builder.RegisterType<DiseaseService>().As<IDiseaseService>().InstancePerRequest();
            builder.RegisterType<RoomService>().As<IRoomService>().InstancePerRequest();
            builder.RegisterType<SymptomService>().As<ISymptomService>().InstancePerRequest();
            builder.RegisterType<TreatmentService>().As<ITreatmentService>().InstancePerRequest();

            builder.RegisterControllers(GetType().Assembly);

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            return new AutofacDependencyResolver(container);
        }
    }
}