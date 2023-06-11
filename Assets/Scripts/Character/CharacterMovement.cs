using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator animator;

    private Vector2 movementDirection;

    private Rigidbody2D rb;

    [SerializeField]
    private float movementSpeed = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal") * 1.5f, Input.GetAxis("Vertical"));

        if(Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("Vertical", 1);
            animator.SetInteger("Horizontal", 0);
            animator.SetBool("Walking", true);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("Vertical", -1);
            animator.SetInteger("Horizontal", 0);
            animator.SetBool("Walking", true);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("Vertical", 0);
            animator.SetInteger("Horizontal", 1);
            animator.SetBool("Walking", true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("Vertical", 0);
            animator.SetInteger("Horizontal", -1);
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetInteger("Vertical", 0);
            animator.SetInteger("Horizontal",0);
            animator.SetBool("Walking", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
}
