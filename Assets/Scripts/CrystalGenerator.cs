using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrystalGenerator : MonoBehaviour
{
    public GameObject Crystal;

    // Start is called before the first frame update
    void Start()
    {
        Generate3NewCrystals();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Generate3NewCrystals()
    {
        var spawnPoints = GetSpawnPoints();

        var spawnPoint1Tag = spawnPoints[GetRandomNumber()];
        var spawnPoint2Tag = spawnPoints[GetRandomNumber()];
        var spawnPoint3Tag = spawnPoints[GetRandomNumber()];

        var spawnPoint1 = GameObject.FindGameObjectWithTag(spawnPoint1Tag);
        var spawnPoint2 = GameObject.FindGameObjectWithTag(spawnPoint2Tag);
        var spawnPoint3 = GameObject.FindGameObjectWithTag(spawnPoint3Tag);

        var tran1 = spawnPoint1.transform;
        var tran2 = spawnPoint2.transform;
        var tran3 = spawnPoint3.transform;
                
        var crystal1 = Instantiate(Crystal, new Vector3(tran1.position.x, tran1.position.y, 0), tran1.rotation);
        var crystal2 = Instantiate(Crystal, new Vector3(tran2.position.x, tran2.position.y, 0), tran2.rotation);
        var crystal3 = Instantiate(Crystal, new Vector3(tran3.position.x, tran3.position.y, 0), tran1.rotation);
    }

    private IDictionary<int, string> GetSpawnPoints()
    {
        var spawnPoints = new Dictionary<int, string>();

        for(int i = 0; i < 5; i++)
        {
            spawnPoints.Add(i + 1, $"Spawn{i + 1}");
        }

        return spawnPoints;
    }

    private int GetRandomNumber()
    {
        var random = new System.Random();
        return random.Next(0, 4);
    }
}
