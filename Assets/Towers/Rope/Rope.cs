using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] [Range(0,1000)] float length = 1f;
    [SerializeField] float partDistance = .21f;

    [SerializeField] GameObject partPrefab, parentObject;

    [SerializeField] bool reset, spawn, snapFirst, snapLast;

    void Update()
    {
        if (reset)
        {
            RopeSegment[] segments = parentObject.GetComponentsInChildren<RopeSegment>();
            foreach (RopeSegment segment in segments)
            {
                Destroy(segment.gameObject);
            }

            reset = false;
        }

        if (spawn)
        {
            Spawn();
            spawn = false; 
        }
    }

    void Spawn()
    {
        int count = (int) (length / partDistance);

        for (int i = 0; i < count; i++)
        {
            GameObject tmp = Instantiate(partPrefab, new Vector3(transform.position.x, transform.position.y + partDistance * (i+1), transform.position.z), Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles = new Vector3(180, 0 ,0);

            tmp.name = parentObject.transform.childCount.ToString();

            if (i == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }
    }
}
