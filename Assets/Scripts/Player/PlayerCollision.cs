using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData playerData;
    private bool canDamage = true;
    private float cooldown = 1f;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        playerData = gameObject.GetComponent<PlayerData>();
    }

    private void Update() {
        time += Time.deltaTime;
        if(time > cooldown) canDamage = true;
    }

    private void OnCollisionStay(Collision other) {

        if ( other.gameObject.CompareTag("Enemy")){
            EnemyData data = other.gameObject.GetComponent<EnemyData>();
            if ( playerData.animator.GetCurrentAnimatorStateInfo(0).IsName("ATTACK") && canDamage){
                data.Health -= playerData.Damage;
                canDamage = false;
                time = 0f;
            }
        }
    }
}
