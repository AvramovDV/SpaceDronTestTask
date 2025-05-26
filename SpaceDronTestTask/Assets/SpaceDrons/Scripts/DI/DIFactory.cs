using Zenject;

namespace Avramov.SpaceDrons
{
    public class DIFactory
    {
        private DiContainer _container;

        public DIFactory(DiContainer container)
        {
            _container = container;
        }

        public T Get<T>() => _container.Resolve<T>();
    }
}
