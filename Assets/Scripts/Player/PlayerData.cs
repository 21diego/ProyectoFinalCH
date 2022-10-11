using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int health = 120;
    [SerializeField] private int damage = 30;

    public Animator animator;
    public int Health { get => health; set => health = value; }
    public int Damage { get => damage; set => damage = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
