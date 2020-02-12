namespace DependencyInjectionDemo.InheritanceOverFactory
{
    public interface IRepo<TConfig> where TConfig : RepoConfig, new()
    {
        string GetSomething();
    }
}
