using System.Threading.Tasks;

namespace DependencyInjectionDemo.Utils.FactoryItems
{
    public interface ICakeFactory
    {
        Task<Cake> Bake(CakeStyle style);
    }
}
