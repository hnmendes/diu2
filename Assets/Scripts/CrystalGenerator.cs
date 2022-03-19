using Assets.Util;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CrystalGenerator : MonoBehaviour
{
    private const string SPAWN_BASE_TAG = "Spawn";
    private const int TOTAL_SPAWN_POINTS = 6;

    public GameObject Crystal;
    public static CrystalGenerator Instance { get; private set; }
    private int CrystalNumber;
    private IDictionary<int, string> spawnPoints;
    private IList<int> randomList;

    private void Awake()
    {
        CrystalNumber = 0;

        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        Generate3NewCrystals();
    }

    public void Generate3NewCrystals()
    {
        Create3Crystals();
        CrystalNumber += 3;
    }

    public int GetCrystalNumber()
    {
        return CrystalNumber;
    }

    public void SetCrystalNumber(int n)
    {
        CrystalNumber = n;
    }

    private void Create3Crystals()
    {
        spawnPoints = SpawnHelper.GetSpawnPoints(SPAWN_BASE_TAG, TOTAL_SPAWN_POINTS);
        randomList = GenericHelper.GetRandomIntList(TOTAL_SPAWN_POINTS);

        var random1 = randomList[2];
        var random2 = randomList[0];
        var random3 = randomList[4];
        CreateSpawnPoints(random1, random2, random3);
    }

    private void CreateSpawnPoints(int random1, int random2, int random3)
    {
        var spawnPointTag1 = SpawnHelper.GetSpawnPoint(random1, spawnPoints, SPAWN_BASE_TAG);
        var spawnPointTag2 = SpawnHelper.GetSpawnPoint(random2, spawnPoints, SPAWN_BASE_TAG);
        var spawnPointTag3 = SpawnHelper.GetSpawnPoint(random3, spawnPoints, SPAWN_BASE_TAG);
        InstantiateCrystals(spawnPointTag1, spawnPointTag2, spawnPointTag3);        
    }

    private void InstantiateCrystals(string spawnPointTag1, string spawnPointTag2, string spawnPointTag3)
    {
        var spawnPoint1 = GameObject.FindGameObjectWithTag(spawnPointTag1);
        var spawnPoint2 = GameObject.FindGameObjectWithTag(spawnPointTag2);
        var spawnPoint3 = GameObject.FindGameObjectWithTag(spawnPointTag3);

        var tran1 = spawnPoint1.transform;
        var tran2 = spawnPoint2.transform;
        var tran3 = spawnPoint3.transform;

        var crystal1 = Instantiate(Crystal, new Vector3(tran1.position.x, tran1.position.y, 0), tran1.rotation);
        var crystal2 = Instantiate(Crystal, new Vector3(tran2.position.x, tran2.position.y, 0), tran2.rotation);
        var crystal3 = Instantiate(Crystal, new Vector3(tran3.position.x, tran3.position.y, 0), tran1.rotation);        
    }
}
