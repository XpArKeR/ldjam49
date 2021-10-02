using System;
using System.Collections.Generic;

using UnityEngine;

public class ResourceCache
{
    readonly Dictionary<String, Sprite> spriteCache = new Dictionary<String, Sprite>();
    readonly Dictionary<String, AudioClip> audioClipCache = new Dictionary<String, AudioClip>();

    public Sprite GetSprite(string path)
    {
        return Get(path, spriteCache);
    }

    public AudioClip GetAudioClip(String path)
    {
        return Get(path, audioClipCache);
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
