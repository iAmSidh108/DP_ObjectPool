using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] Asteroid asteroidPrefab;
    [SerializeField] Transform asteroidSpawnPos;

    private IObjectPool<Asteroid> asteroidPool;
    [SerializeField] int maxSizeOfPool = 15;

    private void Awake()
    {
        asteroidPool = new ObjectPool<Asteroid>(
            CreateAsteroid,
            OnGet,
            OnRelease,
            OnDestroyed,

            maxSize: maxSizeOfPool
        );
    }

    private Asteroid CreateAsteroid()
    {
        Asteroid bullet = Instantiate(asteroidPrefab);
        bullet.SetPool(asteroidPool);
        return bullet;
    }

    Vector3 GetRandomPos()
    {
        return asteroidSpawnPos.position + new Vector3(Random.Range(-10, 10), 0, 0);
    }

    private void OnGet(Asteroid asteroid)
    {
        asteroid.transform.position = GetRandomPos();
        asteroid.gameObject.SetActive(true);
        
    }

    private void OnRelease(Asteroid asteroid)
    {
        asteroid.gameObject.transform.position=transform.position;
        asteroid.gameObject.SetActive(false);
    }

    private void OnDestroyed(Asteroid asteroid)
    {
        Destroy(asteroid.gameObject);
    }


    private void Update()
    {
        if (Random.Range(0,100) < 2)
        {
            asteroidPool.Get();
        }
    }
}
