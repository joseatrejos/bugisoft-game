using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    // Sound Effects
    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip gameOverSound;


    bool confuse = true;

    Rigidbody rb;

    void Start()
    {
        
    }

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

        // Use of the SoundManager to play a random movement sound
        SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
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
        }

        if(other.tag == "confuse")
        {
            confuse=true;
        }
    }
    /* Once you die
        SoundManager.instance.PlaySingle(gameOverSound);
        SoundManager.instance.musicSource.Stop();
    */

}
