using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyChargeData", menuName = "Data/Enemy Data/Enemy Charge State Data")]
public class D_EnemyCharge : ScriptableObject
{
    public float chargeSpeed = 5f;
    public float chargeTime = 2f;
}
