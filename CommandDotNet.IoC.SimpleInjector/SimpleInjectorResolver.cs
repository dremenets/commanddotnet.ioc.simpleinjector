using System;
using SimpleInjector;

namespace CommandDotNet.IoC.SimpleInjector
{
    public class SimpleInjectorResolver : IDependencyResolver
    {
        private readonly Container _container;

        public SimpleInjectorResolver(Container container)
        {
            _container = container;
        }
        public T Resolve<T>()
        {
            return (T) _container.GetInstance(typeof(T));
        }

        public object Resolve(Type type)
        {
            return _container.GetInstance(type);
        }
    }
}