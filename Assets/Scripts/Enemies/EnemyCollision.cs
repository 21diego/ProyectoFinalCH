using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private EnemyData enemyData;
    private bool canDamage = true;
    private float cooldown = 2f;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyData = gameObject.GetComponent<EnemyData>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > cooldown) canDamage = true;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMechanics data = other.gameObject.GetComponent<PlayerMechanics>();
            if (enemyData.animator.GetCurrentAnimatorStateInfo(0).IsName("ATTACK") && canDamage)
            {
                data.Damage(enemyData.Damage);
                canDamage = false;
                time = 0f;
            }
        }
    }
}
