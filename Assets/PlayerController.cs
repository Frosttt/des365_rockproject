using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameObject Camera;
    
    public float MovementSpeed = 5.0f;
    private bool FallDownPipe = false;
    private Rigidbody rb;

    private float ForwardAxis = 0;
    private float RightAxis = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ForwardAxis = Input.GetAxisRaw("Vertical");
        RightAxis = Input.GetAxisRaw("Horizontal");

        Vector3 inputvector = new Vector3(RightAxis, 0, ForwardAxis);

        rb.velocity = MovementSpeed * inputvector;
    }
}
