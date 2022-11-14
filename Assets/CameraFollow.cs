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
        Vector3 desiredPos = transform.position + offset;
        Vector3 smooth = Vector3.Lerp(transform.position, desiredPos, SmoothSpeed * Time.deltaTime);
        transform.position = smooth;
    }
}
