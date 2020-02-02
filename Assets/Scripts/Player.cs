using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    // Spawn point of the player
    private Vector3 spawnPoint;

    // Sound Effects
    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip gameOverSound;

    bool confuse = true;

    Rigidbody rb;

    void Start()
    {
        spawnPoint = transform.position;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       if(confuse)
        {
            MoveTopDown3DConfuse(moveSpeed);
        }
        else
        {
            MoveTopDown3D(moveSpeed);
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

        // Use of the SoundManager to play a random movement sound
        SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
        if (Axis != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Axis);
        }
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
