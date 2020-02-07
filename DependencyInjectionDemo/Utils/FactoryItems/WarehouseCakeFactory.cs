using System.Threading.Tasks;

namespace DependencyInjectionDemo.Utils.FactoryItems
{
    public class WarehouseCakeFactory : ICakeFactory
    {
        public Task<Cake> Bake(CakeStyle style)
        {
            return Task.FromResult(new Cake
            {
                Style = style,
                IsFresh = false
            });
        }
    }
}
