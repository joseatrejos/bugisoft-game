using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    bool confuse = false;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public Vector3 Axis
    {
        get => new Vector3(Input.GetAxis("Horizontal"), 0f,Input.GetAxis("Vertical"));
    }

    public Vector3 AxisDelta
    {
        get => new Vector3(Input.GetAxis("Horizontal"), 0f,Input.GetAxis("Vertical")) * Time.deltaTime;
    }

    void MoveTopDown3D(float speed)
    {
        transform.Translate(Vector3.forward * AxisDelta.magnitude * speed);
        if (Axis != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Axis);
        }
    }
    void MoveTopDown3DConfuse(float speed)
    {
        transform.Translate(Vector3.back * AxisDelta.magnitude * speed);
        if (Axis != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Axis);
        }
    }

  
    void Update()
    {
       if(confuse)
        {
            MoveTopDown3DConfuse(moveSpeed);
        }else
        {
            MoveTopDown3D(moveSpeed);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "desconfuse")
        {
            confuse=false;
        }else
        if(other.tag == "confuse")
        {
            confuse=true;
        }

    }
}
