using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float jumpSpeed;

    public float gravity;

    public bool isGrounded; //result of raycast below the player
    bool movementFinal = false;
    

    public KeyCode jumpKey;

    public AudioSource soundManager;
    public AudioClip jump;
    public AudioClip land;

	public Animator kermitAnim;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //JUMPING
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
			kermitAnim.SetInteger ("State", 3);
			AudioManager.Instance.audioSource.PlayOneShot(jump);
            movementFinal = true;
        }
        
    }

    void FixedUpdate()
    {
        //DO GROUNDED CHECK: shoot raycast just a little past bottom of capsule
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.4f);

        if (movementFinal)
        {
            _rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            movementFinal = false;

        }
        else if (!isGrounded)
        {
            _rigidbody.AddForce(Vector3.down * gravity);
        }
    }
}
