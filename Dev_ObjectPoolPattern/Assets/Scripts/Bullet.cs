using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 speed;

   


    private void Update()
    {
        transform.position += speed * Time.deltaTime;
        
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {

            gameObject.SetActive(false);

        }
    }



}
