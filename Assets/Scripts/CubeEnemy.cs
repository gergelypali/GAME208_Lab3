using UnityEngine;

// child class from enemy, attack function is custom to this class
public class CubeEnemy : Enemy
{
    public override void Attack()
    {
        Debug.Log("CubeEnemy attack!");
    }
}
