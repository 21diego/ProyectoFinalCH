using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMechanics : MonoBehaviour
{

    [SerializeField] PlayerData playerData;
    [SerializeField] Animator playerAnimator;
    private float cooldown = 1f;
    private bool canAttack = true;
    private float time = 0f;

    //Eventos
    public event Action OnDead;
  

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

    public void Damage(int damageToReceive)
    {
        playerData.ActualHealth -= damageToReceive;
        HUDManager.SetHPBar(playerData.ActualHealth);
        Debug.Log(playerData.ActualHealth);
        //if (playerData.ActualHealth  <= 30) OnLastLife?.Invoke();
        if (playerData.ActualHealth <= 0) OnDead?.Invoke();

    }
}
