using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockback
{
    public bool isKnockbackActive;
    
    public void LogicUpdate()
    {
        CheckKnockback();
    }
    
    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent + " was damaged.");
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);
        core.Movement.CanSetVelocity = false;
        isKnockbackActive = true;
    }

    private void CheckKnockback()
    {
        if (isKnockbackActive && core.Movement.CurrentVelocity.y <= 0.01f && core.CollisionSenses.Ground)
        {
            isKnockbackActive = false;
            core.Movement.CanSetVelocity = true;
            core.Movement.SetVelocityX(0f);
        }
    }
}
