using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.GraphicsBuffer;

public class Launcher : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;
    [SerializeField] int maxBulletSpawnCount=10;

    void InstantiateBullets()
    {
        GameObject bullet = BulletPoolHandler.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPos.transform.position;
            bullet.transform.rotation = bulletSpawnPos.transform.rotation;
            bullet.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantiateBullets();
        }
    }


}
