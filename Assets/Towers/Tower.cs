using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
[SerializeField] Transform weapon;

    ObjectPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ClosestEnemy(), Vector3.up);
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ClosestEnemy().position, 0.5f);
    }

    Transform ClosestEnemy()
    {
        List<GameObject> pool = objectPool.ActivePool();
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
}
