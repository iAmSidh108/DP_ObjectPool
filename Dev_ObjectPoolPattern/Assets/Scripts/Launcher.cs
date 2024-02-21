using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bulletPrefab,bulletSpawnPos.position, Quaternion.identity);
        }
    }
}
