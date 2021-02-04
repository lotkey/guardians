using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    public Entity entity;
    public Animator animator;
    public Vector2 input, prevInput;
    public Vector2 facing, wasFacing;

    private void Start()
    {
        input = new Vector2(0, 0);
    }

    private void Update()
    {
        // wasFacing = facing;
        prevInput = input;
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if ((input.x != 0 || input.y != 0) && !(prevInput.x != 0 || prevInput.y != 0))
        {
            animator.SetTrigger("isWalking");
        }
        else if ((input.x == 0 && input.y == 0) && !(prevInput.x == 0 && prevInput.y == 0))
        {
            animator.SetTrigger("isIdle");
        }



        if (input.y > 0)
        {
            animator.SetBool("facingN", true);
            animator.SetBool("facingS", false);
        }
        else if (input.y < 0)
        {
            animator.SetBool("facingS", true);
            animator.SetBool("facingN", false);
        }
        if (input.x > 0)
        {
            animator.SetBool("facingE", true);
            animator.SetBool("facingW", false);
        }
        else if (input.x < 0)
        {
            animator.SetBool("facingW", true);
            animator.SetBool("facingE", false);
        }
    }
}
