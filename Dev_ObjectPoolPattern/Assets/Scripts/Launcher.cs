using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;

    private IObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(
            CreateBullet,
            OnGet,
            OnRelease,
            OnDestroyed,
            maxSize: 5
        );
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity);
        bullet.SetPool(bulletPool);
        return bullet;
    }

    private void OnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position;
    }

    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyed(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            bulletPool.Get();
        }
    }
}
