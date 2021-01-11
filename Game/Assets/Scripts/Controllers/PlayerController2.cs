using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 2f;

    private Vector3 moveDirection;
    private Rigidbody2D playerRigidBody;
    private CharacterAnimator animator;
    private CapsuleCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<CharacterAnimator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(horizontal, vertical).normalized;
        animator.setDirection(horizontal, vertical);
    }

    void FixedUpdate()
    {
        playerRigidBody.velocity = moveDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Start Room")
        {
            playerRigidBody.transform.position = new Vector3(-11.5f, 0.75f); //(-12.5f, 0.5f) <steph's scene
        }
        else if (collision.gameObject.name == "End Room")
        {
            playerRigidBody.transform.position = new Vector3(-7.25f, 0.75f);
        }
    }

}
