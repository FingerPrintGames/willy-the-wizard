using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyMeleeAttackData", menuName = "Data/Enemy Data/Enemy Melee Atack State Data")]
public class D_EnemyMeleeAttack : ScriptableObject
{
    public int meleeDamage = 15;
    
    public float attackCoolDown = 0.5f;
    public float attackRadius = 0.5f;

    public LayerMask whatIsPlayer;
}
