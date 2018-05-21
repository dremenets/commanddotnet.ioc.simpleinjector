using System.Reflection;
using SimpleInjector;

namespace CommandDotNet.IoC.SimpleInjector
{
    public static class Extension
    {
        public static AppRunner<T> UseSimpleInjector<T>(this AppRunner<T> appRunner, Container container) where T : class
        {
            var type = typeof(AppRunner<T>);
            var fieldInfo = type.GetField("DependencyResolver", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(appRunner, new SimpleInjectorResolver(container));

            return appRunner;
        }
    }}
