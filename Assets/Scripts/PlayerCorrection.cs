using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerCorrection : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 5f)] float rayDistance = 2.5f;
    [SerializeField] float moveSpeed;
    [SerializeField] int state=2;

    // Animation of the main player
    protected Animator anim;

    // Spawn point of the player
    private Vector3 spawnPoint;

    // Sound Effects
    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip gameOverSound;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            GameManager.instance.GameData = SaveSystem.LoadGameState();

            GameManager.instance.Player = gameObject; 

            GameManager.instance.PlayerPos = new Vector3(
                GameManager.instance.GameData.position[0],
                GameManager.instance.GameData.position[1],
                GameManager.instance.GameData.position[2]
            );

            GameManager.instance.Player.transform.position = GameManager.instance.PlayerPos;
        } else {
            Debug.Log("Save file not found in" + path);
        }
    }

    /// <summary>
    /// Gets the movement axis when the horizontal and/or vertical axes inputs are used.
    /// </summary>
    public Vector3 Axis
    {
        get => new Vector3(Input.GetAxis("Horizontal"), 0f,Input.GetAxis("Vertical"));
    }

    /// <summary>
    /// Gets the movement axis times delta time when the horizontal and/or vertical axes inputs are used.
    /// </summary>
    public Vector3 AxisDelta
    {
        get => new Vector3(Input.GetAxis("Horizontal"), 0f,Input.GetAxis("Vertical")) * Time.deltaTime;
    }

    /// <summary>
    /// Moves (and rotates) the player in the direction of the axis.
    /// </summary>
    /// <param name="speed">The speed (float) at which the player moves</param>
    void MoveTopDown3D(float speed)
    {
        transform.Translate(Vector3.forward * AxisDelta.magnitude * speed);
        if (Axis != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Axis);
        }
        anim.SetFloat("magnitude", Mathf.Abs(Axis.magnitude));
    }

    /// <summary>
    /// Moves (and rotates) the player in the opposite direction of the axis.
    /// </summary>
    /// <param name="speed">The speed (float) at which the player moves</param>
    void MoveTopDown3DConfuse(float speed)
    {
        transform.Translate(Vector3.back * AxisDelta.magnitude * speed);
        if (Axis != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Axis);
        }
        anim.SetFloat("magnitude", Mathf.Abs(Axis.magnitude));
    }

    /// <summary>
    /// Moves (and rotates) the player in random directions of the axis.
    /// </summary>
    /// <param name="speed">The speed (float) at which the player moves</param>
    void MoveTopDown3DConfusePart2(float speed)
    {
        transform.Translate(Vector3.left * AxisDelta.magnitude * speed);
        if (Axis != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Axis);
        }
        anim.SetFloat("magnitude", Mathf.Abs(Axis.magnitude));
    }

    void Update()
    {
        if (state == 0)
        {
            MoveTopDown3D(moveSpeed);
            if (WallHit)
            {
                moveSpeed = 0;
            }
            else
                moveSpeed = 3f;
        }
        else if (state == 1)
        {
            MoveTopDown3DConfuse(moveSpeed);
            if (WallHitConfused)
            {
                moveSpeed = 0;
            }
            else
                moveSpeed = 3f;
        }
        else if (state == 2)
        {
            MoveTopDown3DConfusePart2(moveSpeed);
            if (WallHitConfusedPart2)
            {
                moveSpeed = 0;
            }
            else
                moveSpeed = 3f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "desconfuse")
        {
            state = 0;
        }

        else if(other.tag == "confuse")
        {
            state = 1;
        }

        else if(other.tag == "confusePart2")
        {
            state = 2;
        }
    }

    protected bool WallHit
    {
        get => Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), rayDistance, layer);
    }
    protected bool WallHitConfused
    {
        get => Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), rayDistance, layer);
    }
    protected bool WallHitConfusedPart2
    {
        get => Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), rayDistance, layer);
    }

    /// <summary>
    /// Draws the players raycast.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;

        if (state == 0)
        {
            Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance);
        }
        else
        if (state == 1)
        {
            Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * rayDistance);
        }
        else
        if (state == 2)
        {
            Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * rayDistance);
        }
    }

    /// <summary>
    /// Returns the player to its starting position.
    /// </summary>
    void Respawn()
    {
        this.transform.position = spawnPoint;
    }

    /// <summary>
    /// Fades the camera to the death screen and stops the music.
    /// </summary>
    void Death()
    {
        SoundManager.instance.PlaySingle(gameOverSound);
        SoundManager.instance.musicSource.Stop();
    }

}
