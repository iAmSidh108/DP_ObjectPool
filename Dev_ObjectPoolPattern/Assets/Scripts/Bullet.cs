using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 speed;
    public bool isReleased = false; // Flag to track release status
    private IObjectPool<Bullet> bulletPool;

    public void SetPool(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }


    private void Update()
    {
        transform.position += speed * Time.deltaTime;
        StartCoroutine(ReleaseItself());
    }

    IEnumerator ReleaseItself()
    {
        yield return new WaitForSeconds(5);
        bulletPool.Release(this);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            if (!isReleased)
            {
                bulletPool.Release(this);
                isReleased = true;
                Player.instance.AddScore(10);
            }
        }
    }

    

}
