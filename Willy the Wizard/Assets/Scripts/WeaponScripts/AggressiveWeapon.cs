using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AggressiveWeapon : Weapon
{
    protected SO_AggressiveWeaponData aggressiveWeaponData;
    
    private List<IDamageable> detectedDamageables = new List<IDamageable>();
    private List<IKnockback> detectedKnockbacks = new List<IKnockback>();

    protected override void Awake()
    {
        base.Awake();
        if (weaponData.GetType() == typeof(SO_AggressiveWeaponData))
        {
            aggressiveWeaponData = (SO_AggressiveWeaponData)weaponData;
        }
        else Debug.LogError("Wrong data for the weapon!");
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();
        CheckMeleeAttack();
    }

    public void AddToDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Added");
            detectedDamageables.Add(damageable);
        }

        IKnockback knockback = collision.GetComponent<IKnockback>();
        if (knockback != null)
        {
            detectedKnockbacks.Add(knockback);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Removed");
            detectedDamageables.Remove(damageable);
        }

        IKnockback knockback = collision.GetComponent<IKnockback>();
        if (knockback != null)
        {
            detectedKnockbacks.Remove(knockback);
        }
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggressiveWeaponData.AttackDetails[attackCounter];
        
        foreach (IDamageable item in detectedDamageables.ToList())
        {
            item.Damage(details.damageAmount);
        }

        foreach (IKnockback item in detectedKnockbacks.ToList())
        {
            item.Knockback(details.knockbackAngle, details.knockbackStrength, core.Movement.FacingDir);
        }
    }
}
