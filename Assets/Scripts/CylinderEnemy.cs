using UnityEngine;

// child class from enemy, attack function is custom to this class
public class CylinderEnemy : Enemy
{
    public override void Attack()
    {
        Debug.Log("CylinderEnemy attack!");
    }
}
