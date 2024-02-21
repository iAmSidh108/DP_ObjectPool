using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] Asteroid asteroidPrefab;
    [SerializeField] Transform spawnPos;
    [SerializeField] int maxAsteroidSpawnCount = 10;

    private IObjectPool<Asteroid> asteroidPool;

    private void Awake()
    {
        asteroidPool = new ObjectPool<Asteroid>(
            CreateAsteroid,
            OnGet,
            OnRelease,
            OnDestroyed,
            maxSize: maxAsteroidSpawnCount
        ) ;
    }

    private Asteroid CreateAsteroid()
    {
        Asteroid asteroid = Instantiate(asteroidPrefab);
        asteroid.SetPool(asteroidPool);
        return asteroid;
    }

    Vector3 GetRandomPos()
    {
        return spawnPos.position + new Vector3(Random.Range(-20, 20), 0, 0);
    }

    private void OnGet(Asteroid asteroid)
    {
        asteroid.gameObject.SetActive(true);
        asteroid.transform.position = GetRandomPos();   
        
    }

    private void OnRelease(Asteroid asteroid)
    {
        asteroid.gameObject.SetActive(false);
        
    }

    private void OnDestroyed(Asteroid asteroid)
    {
        Destroy(asteroid.gameObject);
    }

    private void Update()
    {
        if (Random.Range(0, 100) < 3)
        {
           asteroidPool.Get();
        }
       
    }
}
