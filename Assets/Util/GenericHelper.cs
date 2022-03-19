using System.Collections.Generic;

namespace Assets.Util
{
    public static class GenericHelper
    {
        public static IList<int> GetRandomIntList(int randomListLength)
        {
            IList<int> randomInts = new List<int>();

            for (int i = 0; i < randomListLength; i++)
            {
                randomInts.Add(i);
            }

            randomInts.Shuffle();

            return randomInts;
        }
    }
}