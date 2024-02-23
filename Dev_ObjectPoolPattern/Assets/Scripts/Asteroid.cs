using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Asteroid : MonoBehaviour
{
    private IObjectPool<Asteroid> asteroidPool;
    

    public void SetPool(IObjectPool<Asteroid> pool)
    {
        asteroidPool = pool;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            
            asteroidPool.Release(this);

        }

        if (collision.gameObject.tag == "end")
        {
            
            asteroidPool.Release(this);

        }

        if (collision.gameObject.tag == "ship")
        {
            Player.instance.GetDamage(5);
            asteroidPool.Release(this);

        }
    }




}
