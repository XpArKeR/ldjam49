using System;

using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class TransformExtensions
    {
        public static T FindComponentOfChildByName<T>(this Transform transform, String name)
        {
            if ((transform != default) && (!String.IsNullOrEmpty(name)))
            {
                var child = transform.Find(name);

                if (child != default)
                {
                    return child.GetComponent<T>();
                }
            }

            return default;
        }
    }
}
