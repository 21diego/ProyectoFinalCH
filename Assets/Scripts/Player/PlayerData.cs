using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] int actualHealth;
    [SerializeField] int maxHealth;
    [SerializeField] private int damage = 30;

    public Animator animator;
    public int ActualHealth { get => actualHealth; set => actualHealth = value; }
    public int Damage { get => damage; set => damage = value; }

    

}
