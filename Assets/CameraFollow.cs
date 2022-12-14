using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ActorToFollow;

    [Range(0, 20)]
    public float SmoothSpeed = 10f;

    public Vector3 offset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (ActorToFollow)
        {
            Vector3 desiredPos = ActorToFollow.transform.position + offset;
            Vector3 smooth = Vector3.Lerp(transform.position, desiredPos, SmoothSpeed);
            transform.position = smooth;

        }
    }
}
