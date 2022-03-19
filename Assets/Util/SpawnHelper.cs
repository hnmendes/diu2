using System.Collections.Generic;

namespace Assets.Util
{
    public static class SpawnHelper
    {
        public static IDictionary<int, string> GetSpawnPoints(string spawnBaseTag, int numberOfSpawnPoints)
        {
            var spawnPoints = new Dictionary<int, string>();

            for (int i = 0; i < numberOfSpawnPoints; i++)
            {
                spawnPoints.Add(i, $"{spawnBaseTag}{i + 1}");
            }
            return spawnPoints;
        }

        public static string GetSpawnPoint(int index, IDictionary<int, string> dic, string spawnBaseTag)
        {
            if (dic.ContainsKey(index))
            {
                return dic[index];
            }
            return $"{spawnBaseTag}{dic.Count - 1}";
        }
    }
}