using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] Transform spawnPos;


    void InstantiateAsteroids()
    {
        GameObject asteroid = AsteroidPoolHandler.SharedInstance.GetPooledObject();
        if (asteroid != null)
        {
            asteroid.transform.position = GetRandomPos();
            asteroid.SetActive(true);
        }
    }

    Vector3 GetRandomPos()
    {
        return spawnPos.position + new Vector3(Random.Range(-20, 20), 0, 0);
    }

    private void Update()
    {
        if (Random.Range(0, 100) < 5)
        {
            InstantiateAsteroids();
        }

    }
}
