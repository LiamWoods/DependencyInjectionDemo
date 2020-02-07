using System.Threading.Tasks;

namespace DependencyInjectionDemo.Utils.FactoryItems
{
    public class FreshCakeFactory : ICakeFactory
    {
        public Task<Cake> Bake(CakeStyle style)
        {
            return Task.FromResult(new Cake
            {
                Style = style,
                IsFresh = true
            });
        }
    }
}
