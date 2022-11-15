using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameObject PlayerCamera;
    
    public float MovementSpeed = 5.0f;
    private bool FallDownPipe = false;
    private Rigidbody rb;
    private float minmove = .1f;
    private float ForwardAxis = 0;
    private float RightAxis = 0;

    float TurnSmoothVelocity;
    float turnSmoothTime = .1f;


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

        Vector3 inputvector = new Vector3(RightAxis, 0, ForwardAxis).normalized;
        if (inputvector.sqrMagnitude > minmove * minmove)
        {
            float targetAngle = Mathf.Atan2(inputvector.x, inputvector.z) * Mathf.Rad2Deg + PlayerCamera.transform.eulerAngles.y;
           // Quaternion inputdir = Quaternion.Euler(0, PlayerCamera.transform.eulerAngles.y, 0);
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TurnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 movedir = Quaternion.Euler(0, targetAngle, 0f)  * Vector3.forward;


            rb.velocity = movedir.normalized * MovementSpeed;
        }



        
    }
}
