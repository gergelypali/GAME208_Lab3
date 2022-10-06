using UnityEngine;

// child class from enemy, attack function is custom to this class
public class CapsuleEnemy : Enemy
{
    public override void Attack()
    {
        Debug.Log("CapsuleEnemy attack!");
    }
}
