using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveWeapon : Weapon
{
    protected SO_AggressiveWeaponData aggressiveWeaponData;
    
    private List<IDamageable> detectedDamageables = new List<IDamageable>();

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
        Debug.Log("AddToDetected");
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Added");
            detectedDamageables.Add(damageable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        Debug.Log("Remove from detected");
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Removed");
            detectedDamageables.Remove(damageable);
        }
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggressiveWeaponData.AttackDetails[attackCounter];
        
        foreach (IDamageable item in detectedDamageables)
        {
            item.Damage(details.damageAmount);
        }
    }
}
