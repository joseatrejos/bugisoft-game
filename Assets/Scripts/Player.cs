using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
<<<<<<< Updated upstream
=======
    LayerMask layer;

    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 5f)]
    float rayDistance = 2.5f;
    
    [SerializeField]
>>>>>>> Stashed changes
    float moveSpeed;

    bool confuse = true;

    Rigidbody rb;

<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
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
        get => new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

    public Vector3 AxisDelta
    {
        get => new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * Time.deltaTime;
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
        if (confuse)
        {
            MoveTopDown3DConfuse(moveSpeed);
        }
        else
        {
            MoveTopDown3D(moveSpeed);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "desconfuse")
        {
            confuse = false;
        }

        if (other.tag == "confuse")
        {
            confuse = true;
        }

    }

}
