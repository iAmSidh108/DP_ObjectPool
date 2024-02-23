using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;

    private IObjectPool<Bullet> bulletPool;
    [SerializeField] int maxSizeOfPool = 15;

    private float _lastFireTime = 0f;  // Added to track last fire time
    [SerializeField] private float _fireRate = 0.5f;  // Added fire rate variable



    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(
            CreateBullet,
            OnGet,
            OnRelease,
            OnDestroyed,
            collectionCheck: true,
            maxSize: maxSizeOfPool
        ) ;
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
        if (Input.GetKeyDown(KeyCode.F) && !Player.instance.CheckIsDead() && Time.time - _lastFireTime >= _fireRate)
        {
            _lastFireTime = Time.time; // Update last fire time
            bulletPool.Get();
        }
    }


}
