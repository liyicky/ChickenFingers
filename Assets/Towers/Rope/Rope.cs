using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

    public List<RopeSegment> ropeSegments;
    [SerializeField] bool reset = false;

    void Update()
    {
        if (reset)
        {
            Reset();
            reset = false;
        }
    }

    public void RegisterSegment(RopeSegment segment)
    {
        ropeSegments.Add(segment);
    }
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Reset()
    {
        foreach (RopeSegment segment in ropeSegments)
        {
            segment.Reset();
        }
    }
}
