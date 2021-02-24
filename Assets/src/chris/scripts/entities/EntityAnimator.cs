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
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
        }
        else if ((input.x == 0 && input.y == 0) && !(prevInput.x == 0 && prevInput.y == 0))
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
        }

        if (entity.movement.IsFacingNorth())
        {
            animator.SetBool("facingN", true);
            animator.SetBool("facingE", false);
            animator.SetBool("facingS", false);
            animator.SetBool("facingW", false);
        }
        else if (entity.movement.IsFacingSouth())
        {
            animator.SetBool("facingN", false);
            animator.SetBool("facingE", false);
            animator.SetBool("facingS", true);
            animator.SetBool("facingW", false);
        }
        else if (entity.movement.IsFacingSouthEast() || entity.movement.IsFacingEast() || entity.movement.IsFacingNorthEast())
        {
            animator.SetBool("facingN", false);
            animator.SetBool("facingE", true);
            animator.SetBool("facingS", false);
            animator.SetBool("facingW", false);
        }
        else if (entity.movement.IsFacingSouthWest() || entity.movement.IsFacingWest() || entity.movement.IsFacingNorthWest())
        {
            animator.SetBool("facingN", false);
            animator.SetBool("facingE", false);
            animator.SetBool("facingS", false);
            animator.SetBool("facingW", true);
        }
    }
}
