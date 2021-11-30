using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] Bullet bullet;
    [SerializeField] GameObject spawner;
    Renderer rend;
    GameObject[] enemyPool;
    GameObject[] bulletPool;
    [SerializeField] int enemyPoolSize = 10;
    [SerializeField] int bulletPoolSize = 10;

    [SerializeField] float spawnTime = 0.5f;
    // Start is called before the first frame update

    void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        rend = spawner.GetComponent<Renderer>();
        StartCoroutine(SpawnEnemies());
    }

    public GameObject[] EnemyPool()
    {
        return enemyPool;
    }

    public List<GameObject> ActiveEnemyPool()
    {
        List<GameObject> activeEnemyPool = new List<GameObject>();
        foreach (GameObject enemy in enemyPool)
        {
            if (enemy.activeInHierarchy)
            {
                activeEnemyPool.Add(enemy);
            }
        }
        return activeEnemyPool;
    }

    public GameObject ActiveBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        return null;
    }

    void OnDrawGizmosSelected()
    {
        rend = spawner.GetComponent<Renderer>();
        Vector3 center = rend.bounds.center;
        float radius = rend.bounds.extents.magnitude;

        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(rend.bounds.max, 1f);
        Gizmos.DrawWireSphere(center, 1f);
        Gizmos.DrawWireSphere(rend.bounds.min, 1f);

    }

    void PopulatePool()
    {
        enemyPool = new GameObject[enemyPoolSize];
        FillPool(enemyPool, enemyPoolSize, enemy.gameObject);
        
        bulletPool = new GameObject[bulletPoolSize];
        FillPool(bulletPool, bulletPoolSize, bullet.gameObject);
    }

    void FillPool(GameObject[] pool, float poolSize, GameObject gameObject)
    {
        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(gameObject, transform.position, Quaternion.identity, transform);
            pool[i].SetActive(false);
        }
    }

    Vector3 GetRandomXPos()
    {
        Vector3 minBounds = rend.bounds.min;
        Vector3 maxBounds = rend.bounds.max;
        float randomX = Random.Range(minBounds.x, maxBounds.x);
        return new Vector3(randomX, rend.transform.position.y);
    }

    void EnableObjectInPool()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                Vector3 randomXPos = GetRandomXPos();
                enemy.transform.position = randomXPos;
                enemy.SetActive(true);
                break;
            }
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTime);
            
        }
    }
}
