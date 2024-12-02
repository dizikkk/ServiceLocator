using System;
using System.Collections.Generic;

namespace ServiceLocator.Runtime.Core
{
    public class ServiceLocator : IServiceLocator
    {
        private static volatile IServiceLocator instance;
        
        private readonly Dictionary<Type, object> registeredObjects = new();
        
        private readonly object @lock = new();
        
        public IServiceLocator Instance
        {
            get
            {
                if (instance != null) return instance;
                lock (@lock) instance ??= new ServiceLocator();
                return instance;
            }
        }
        
        public void Add<T>(T obj)
        {
            if (obj == null) return;
            Type type = typeof(T);
            registeredObjects.TryAdd(type, obj);
        }

        public T Get<T>()
        {
            Type type = typeof(T);
            if (registeredObjects.TryGetValue(type, out object obj)) return (T)obj;
            throw new Exception($"Object {type.Name} not registered in ServiceLocator");
        }
    }
}