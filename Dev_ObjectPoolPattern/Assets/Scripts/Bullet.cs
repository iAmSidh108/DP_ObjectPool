using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 speed;

    private void Update()
    {
        transform.position += speed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }

    

}
