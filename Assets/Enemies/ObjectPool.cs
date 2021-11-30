using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject spawner;
    Renderer rend;
    GameObject[] pool;
    [SerializeField] int poolSize = 10;

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

    public GameObject[] Pool()
    {
        return pool;
    }

    public List<GameObject> ActivePool()
    {
        List<GameObject> activePool = new List<GameObject>();
        foreach (GameObject enemy in pool)
        {
            if (enemy.activeInHierarchy)
            {
                activePool.Add(enemy);
            }
        }
        return activePool;
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
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemy.gameObject, transform.position, Quaternion.identity);
            pool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()   
    {
        
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
        foreach (GameObject enemy in pool)
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
