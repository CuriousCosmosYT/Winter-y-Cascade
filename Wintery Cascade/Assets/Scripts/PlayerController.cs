using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    public SwordAttack swordAttack2;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if(movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if(!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                    if(!success)
                    {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                }
                animator.SetBool("isMoving", success);
            }
            else{
                animator.SetBool("isMoving", false);
            }
            if(movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if(movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            if(movementInput.y < 0)
            {
                animator.SetBool("movingDown", true);
                animator.SetBool("movingUp", false);
            }
            else if(movementInput.y > 0)
            {
                animator.SetBool("movingUp", true);
                animator.SetBool("movingDown", false);
            }
            else if(movementInput.y == 0)
            {
                animator.SetBool("movingUp", false);
                animator.SetBool("movingDown", false);
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
            direction, 
            movementFilter, 
            castCollisions, 
            moveSpeed * Time.fixedDeltaTime + collisionOffset);
        
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        return true;
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("attack");
    }

    public void SwordAttack() {
        LockMovement();

        if(spriteRenderer.flipX == true){
            swordAttack.AttackLeft();
        } else {
            swordAttack.AttackRight();
        }
    }

    public void EndSwordAttack() {
        UnlockMovement();
        swordAttack.StopAttack();
        
        swordAttack2.StopAttack();
    }

    public void SwordAttackUp() {
        LockMovement();
        swordAttack2.AttackUp();
    }

    public void SwordAttackDown() {
        LockMovement();
        swordAttack2.AttackDown();
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }
}