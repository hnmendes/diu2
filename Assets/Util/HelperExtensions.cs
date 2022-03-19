using System;
using System.Collections.Generic;

namespace Assets.Util
{
    public static class HelperExtensions
    {
        private static readonly Random Random = new Random();

        public static void Shuffle<T>(this IList<T> intListToRandom)
        {
            int n = intListToRandom.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                T value = intListToRandom[k];
                intListToRandom[k] = intListToRandom[n];
                intListToRandom[n] = value;
            }
        }

    }
}