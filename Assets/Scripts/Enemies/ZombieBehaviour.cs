using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 5f)]
    private float speedMovement = 2f;
    [SerializeField] Animator zombieAnimator;
    enum ZombieTypes { Chibi, Chaser, Boomber };
    [SerializeField] ZombieTypes zombieType;

    //Guardamos una referencia al transform del player para movernos en su dirección.
    [SerializeField] Transform playerTransform;
    private float cooldown = 2f;
    private bool canAttack = true;
    private float time = 0f;

    public Transform PlayerTransform { get => playerTransform; set => playerTransform = value; }

    // Start is called before the first frame update
    void Start()
    {
        EnemyData data = gameObject.GetComponent<EnemyData>();
        switch (zombieType)
        {
            case ZombieTypes.Chibi:
                data.Health = 30;
                data.Damage = 60;
                data.Reward = 5;
                break;
            case ZombieTypes.Chaser:
                data.Health = 100;
                data.Damage = 30;
                data.Reward = 30;
                break;
            case ZombieTypes.Boomber:
                data.Health = 500;
                data.Damage = 300;
                data.Reward = 100;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (zombieType)
        {
            case ZombieTypes.Chibi:
                ChasePlayer(2f);
                break;
            case ZombieTypes.Chaser:
                ChasePlayer(1f);
                break;
            case ZombieTypes.Boomber:
                ChasePlayer(0.2f);
                break;
        }
    }

    private void ChasePlayer(float conditioner)
    {
        LookAtPlayer();
        // Con la resta obtenemos la direccion hacia el objetivo
        Vector3 direction = (playerTransform.position - transform.position);

        // Debe tener un limite de distancia
        if (direction.magnitude > 1f)
        {
            zombieAnimator.SetBool("WALKING", true);
            transform.position += direction.normalized * speedMovement * conditioner * Time.deltaTime;
        }
        else
        {
            AttackPlayer();

        }


    }

    private void LookAtPlayer()
    {
        // Determino la nueva rotacion
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 10f * Time.deltaTime);
    }

    void AttackPlayer()
    {
        // Detengo la animacion de caminar
        zombieAnimator.SetBool("WALKING", false);
        
        time += Time.deltaTime;

        if(time > cooldown) canAttack = true;

        if (canAttack) {
            
            zombieAnimator.SetTrigger("ATTACK");
            canAttack = false;
            time = 0f;
        }

    }


}
