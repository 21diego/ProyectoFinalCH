using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 20;
    [SerializeField] private int reward = 1;

    public Animator animator;
    private float DestructionLapse = 1f;
    public int Health { get => health; set => health = value; }

    public int Damage { get => damage; set => damage = value; }
    public int Reward { get => reward; set => reward = value; }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 0) DestroyMe();
    }

    private void DestroyMe()
    {
        animator.SetBool("WALKING", false);
        animator.SetTrigger("DIE");
        Invoke("DestroyDelay", DestructionLapse);
    }

    void DestroyDelay()
    {
        Destroy(gameObject);
    }
}
