using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    LayerMask layer;

    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 5f)]
    float rayDistance = 5f;
    
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    int state=2;

    Rigidbody rb;

    string stop = "noHit";

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }



    void Start()
    {
        GameManager.instance.GameData = SaveSystem.LoadGameState();

        GameManager.instance.Player = gameObject; 

        GameManager.instance.PlayerPos = new Vector3(
            GameManager.instance.GameData.position[0],
            GameManager.instance.GameData.position[1],
            GameManager.instance.GameData.position[2]
        );

        GameManager.instance.Player.transform.position = GameManager.instance.PlayerPos;
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
     void MoveTopDown3DConfusePart2(float speed)
    {
        transform.Translate(Vector3.left * AxisDelta.magnitude * speed);
        if (Axis != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Axis);
        }
    }

  
    void Update()
    {
         if(state==0)
        {
            MoveTopDown3D(moveSpeed);
           if(WallHit)
           {
               moveSpeed=0;
           }else
           moveSpeed=10;
        }else if(state==1)
        {
             MoveTopDown3DConfuse(moveSpeed);
          if(WallHitConfused)
          {
              moveSpeed=0;
          }else
           moveSpeed=10;
        }else if(state==2)
        {
            MoveTopDown3DConfusePart2(moveSpeed);
            if(WallHitConfusedPart2)
          {
              moveSpeed=0;
          }else
           moveSpeed=10;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "desconfuse")
        {
            state=0;
        }else
        if(other.tag == "confuse")
        {
            state=1;
        }else
        if(other.tag == "confusePart2")
        {
            state=2;
        }

    }

 
    
    protected bool WallHit
    {
        get=>Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), rayDistance, layer);
    }

    protected bool WallHitConfused
    {
        get=>Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), rayDistance, layer);
    }
    protected bool WallHitConfusedPart2
    {
        get=> Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), rayDistance, layer);
    }

    //Drawing raycast
    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        
        if(state==0)
        {
            Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance);
        }else
        if(state==1)
        {
             Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * rayDistance);
        }else
        if(state==2)
        {
            Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * rayDistance);
        }
    }

}
