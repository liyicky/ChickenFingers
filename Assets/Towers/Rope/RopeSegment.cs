using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSegment : MonoBehaviour
{
    private int touchCount;
    Vector3 startPosition, startRotation, cjStartAnchor;
    CharacterJoint cj;
    float cjAngles;
    Rope parentRope;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.eulerAngles;
        cj = GetComponent<CharacterJoint>();
        cjStartAnchor = cj.connectedAnchor;

        parentRope = GetComponentInParent<Rope>();
        parentRope.RegisterSegment(this);
    }

    public void Reset()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        
        transform.position = startPosition;
        transform.eulerAngles = startRotation;
        ToggleSegment(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            touchCount++;
            if (touchCount > 4)
            {
                ToggleSegment(false);
                touchCount = 0;
            }
        }
    }

    private void ToggleSegment(bool toggle)
    {
        this.GetComponent<MeshRenderer>().enabled = toggle;
        this.GetComponent<CapsuleCollider>().enabled = toggle;
    }
}
