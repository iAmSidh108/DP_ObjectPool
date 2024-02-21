using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 speed;

    private IObjectPool<Bullet> bulletPool;

    public void SetPool(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }


    private void Update()
    {
        transform.position += speed * Time.deltaTime;
        
    }

    private void OnBecameInvisible()
    {
        bulletPool.Release(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            bulletPool.Release(this);

        }
    }



}
