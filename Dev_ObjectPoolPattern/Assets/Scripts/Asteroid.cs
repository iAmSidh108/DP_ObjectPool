using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Asteroid : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DisableGameObject());
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {

            gameObject.SetActive(false);

        }

        if (collision.gameObject.tag == "ship")
        {
            Player.instance.GetDamage(10);
            gameObject.SetActive(false);
            

        }
    }

    

    IEnumerator DisableGameObject()
    {
        yield return new WaitForSeconds(5);

        gameObject.SetActive(false);
    }


}
