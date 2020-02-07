namespace SimpleInjectorDemo
{
    public class ConcreteService : IConcreteService
    {
        private ConcreteRepository _repository;
        public ConcreteService()
        {
            _repository = new ConcreteRepository();
        }

        public bool DoSomething()
        {
            return _repository.GetABool();
        }
    }

    public interface IConcreteService
    {
        bool DoSomething();
    }
}
