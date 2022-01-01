using Assets.Scripts.Caching;

using System;
using System.Collections.Generic;

using UnityEngine;

public class ResourceCache
{
    private Cache<AudioClip> audioClipCache = new Cache<AudioClip>("Audio");
    readonly Dictionary<String, Sprite> spriteCache = new Dictionary<String, Sprite>();
    
    public Sprite GetSprite(string path)
    {
        return Get(path, spriteCache);
    }

    public AudioClip GetAudioClip(String path)
    {
        return audioClipCache.Get(path);
    }

    private T Get<T>(String path, IDictionary<String, T> cache) where T : UnityEngine.Object
    {
        if (!cache.TryGetValue(path, out T cachedItem))
        {
            cachedItem = Resources.Load<T>(path);

            if (cachedItem != default(T))
            {
                cache[path] = cachedItem;
            }
        }

        return cachedItem;
    }
}
