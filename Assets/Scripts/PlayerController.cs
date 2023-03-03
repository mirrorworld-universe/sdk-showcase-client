using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public MyJoystick joystick;

    public GameObject player;

    private Animator animator;

    private void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    private void Update()
    {
        int direction = GetDirection();
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || direction == 3)
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D) || direction == 4)
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W) || direction == 1)
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S) || direction == 2)
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        player.GetComponent<Rigidbody2D>().velocity = speed * dir;
    }

    public int GetDirection()
    {
        if (Mathf.Abs(joystick.Vertical) > Mathf.Abs(joystick.Horizontal))
        {
            if (joystick.Vertical > 0)
            {
                return 1;
            }
            else if (joystick.Vertical < 0)
            {
                return 2;
            }
        }
        else
        {
            if (joystick.Horizontal < 0)
            {
                return 3;
            }
            else if (joystick.Horizontal > 0)
            {
                return 4;
            }
        }

        return 0;
    }
}