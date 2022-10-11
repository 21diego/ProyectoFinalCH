using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] respawnPoints;
    [SerializeField] private float DelaySpawn = 1f;
    [SerializeField] private float IntervalSpawn = 2f;
    [SerializeField] private GameObject zombieChaser;
    [SerializeField] private TextMeshProUGUI textoScore;
    [SerializeField] private TextMeshProUGUI textoHealth;
    [SerializeField] private GameObject Player;
    private int score = 0;

    public int Score { get => score; set => score = value; }
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        InvokeRepeating("SpawnZombieChaser", DelaySpawn, IntervalSpawn);
    }

    private void Update()
    {
        textoScore.text = "SCORE: " + (int)Time.time;
        textoHealth.text = "HEALTH: " + Player.GetComponent<PlayerData>().Health;
    }

    private void SpawnZombieChaser()
    {
        var rndPosition = Random.Range(0, respawnPoints.Length);

        Vector3 startPosition = respawnPoints[rndPosition].transform.position;
        var obj = Instantiate(zombieChaser, startPosition, zombieChaser.transform.rotation);
        obj.GetComponent<ZombieBehaviour>().PlayerTransform = Player.transform;
    }

}
