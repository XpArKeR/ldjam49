using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Extensions
{
    public static class ListExtensions
    {
        public static T GetRandomEntry<T>(this List<T> list, Func<T, Boolean> condition = default)
        {
            T value = default(T);

            if (list != default)
            {
                var baseList = list;

                if (condition != default)
                {
                    baseList = baseList.Where(condition).ToList();
                }

                int index = UnityEngine.Random.Range(0, baseList.Count);

                value = baseList[index];
            }

            return value;
        }
    }
}
