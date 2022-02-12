using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

namespace Assets.Scripts.Caching
{
    public class Cache<T> where T : UnityEngine.Object
    {
        private IDictionary<String, T> internalCache = new Dictionary<String, T>();

        public Cache(String resourceBasePath)
        {
            LoadResources(resourceBasePath);
        }

        public T Get(String name)
        {
            if (!this.internalCache.TryGetValue(name, out T cachedResource))
            {
                Debug.Log(String.Format("No resource of type '{0}' found with name '{1}'", typeof(T).FullName, name));
            }

            return cachedResource;
        }

        private void LoadResources(string resourceBasePath)
        {
            var loadedResources = UnityEngine.Resources.LoadAll<T>(resourceBasePath);

            foreach (var loadedResource in loadedResources)
            {
                internalCache[loadedResource.name] = loadedResource;
            }
        }
    }
}
