/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : MonoBehaviour
{
    public enum AttackDirection
    {
        up, down
    }
    public AttackDirection attackDirection2;
    Vector2 attackOffset2;
    Collider2D attackCollider2;
    private void Start()
    {
        attackCollider2 = GetComponent<Collider2D>();
        rightAttackOffset2 = transform.localPosition;
    }
    public void Attack2()
    {
        switch(attackDirection2)
        {
            case AttackDirection2.up:
                AttackUp();
                break;
            case AttackDirection2.down:
                AttackDown();
                break;
        }
    }

    private void AttackDown()
    {
        swordCollider2.enabled = true;
        transform.localPosition = rightAttackOffset2;
    }

    private void AttackUp()
    {
        swordCollider2.enabled = true;
        trasnform.localPosition = new Vector3(rightAttackOffset2.x, rightAttackOffset2.y * -1);
    }

    public void StopAttack2()
    {
        swordCollider2.enabled = false;
    }
}
*/