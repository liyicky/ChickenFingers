using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
[SerializeField] Transform weapon;
[SerializeField] GameObject projectile;
[SerializeField] float fireRate = 0.3f;
[SerializeField] float fireThrust = 20f;
BulletSpawner bulletSpawner;

    ObjectPool objectPool;


    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
        bulletSpawner = GetComponentInChildren<BulletSpawner>();
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ClosestEnemy().position, 0.5f);
    }

    Transform ClosestEnemy()
    {
        List<GameObject> pool = objectPool.ActiveEnemyPool();
        Transform target = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in pool)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                target = enemy.transform;
                closestDistance = distanceToEnemy;
            }
        }

        Debug.DrawRay(transform.position, target.transform.position, Color.red);
        return target;
    }

    void Aim()
    {
        transform.LookAt(ClosestEnemy(), Vector3.up);
    }

    IEnumerator Shoot()
    {
        GameObject spawnLocation = bulletSpawner.gameObject;
        while (true)
        {
            GameObject bullet = objectPool.ActiveBullet();
            bullet.transform.position = bulletSpawner.transform.position;
            bullet.GetComponent<Rigidbody>().AddForce(0, 0, fireThrust, ForceMode.Impulse);
            yield return new WaitForSeconds(fireRate);
        }

    }
}
