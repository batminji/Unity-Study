using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy_Goblin : Enemy
{
    private void Awake()
    {
        moveSpeed = 10.0f;
    }

    protected override void Attack()
    {
        base.Attack();

        StealMoney();
    }

    private void StealMoney()
    {
        Debug.Log(enemyName + " steals your money!");
    }
}
