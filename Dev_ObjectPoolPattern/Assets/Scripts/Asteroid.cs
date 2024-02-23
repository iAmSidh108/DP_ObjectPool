using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Asteroid : MonoBehaviour
{

    private IObjectPool<Asteroid> asteroidPool;
    private void Update()
    {
        ;
    }

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
            Debug.Log("Hit");
            asteroidPool.Release(this);

        }

        //if (collision.gameObject.tag == "ship")
        //{
        //    Player.instance.GetDamage(10);
        //    gameObject.SetActive(false);


        //}
    }



    IEnumerator DisableGameObject()
    {
        yield return new WaitForSeconds(5);

        gameObject.SetActive(false);
    }


}
