using System.Web.Mvc;
namespace SurgeryDepartment.Infastructure.DI
{
    public interface IDependencyResolverFactory
    {
        IDependencyResolver Create();

    }

}