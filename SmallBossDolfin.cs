using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SmallBossDolfin : EnemyDefolt
{
    private void Start()
    {
        hp = 20 + cofHp;
        hpAttack = 2;
        speed = 5f;
        startTimeBtwAttackPlayer = 1.75f;
        timeBtwAttackPlayer = startTimeBtwAttackPlayer;
        scoreForEnemy = 20;
        target = GameObject.FindWithTag("Player").transform;
        isDead = false;
    }
    void Update()
    {
        if (isDead == false)
        {
            Dead(Gun.damage);
            Move();
            Attack();
            bite.pitch = Random.Range(0.7f, 0.9f);
            takeDamage.pitch = Random.Range(0.7f, 0.9f);
        }
    }
}
