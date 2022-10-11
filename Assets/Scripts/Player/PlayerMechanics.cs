using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{

    [SerializeField] Animator playerAnimator;
    private float cooldown = 1f;
    private bool canAttack = true;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        bool attack = Input.GetMouseButtonDown(0);
        bool block = Input.GetMouseButtonDown(1);

        if(time > cooldown) canAttack = true;

        if (attack && canAttack) {
            playerAnimator.SetTrigger("ATTACK");
            canAttack = false;
            time = 0f;
        }
        if (block) playerAnimator.SetTrigger("BLOCK");
        
    }
}
