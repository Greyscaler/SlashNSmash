using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private Transform spawnPointPlayer;
    [SerializeField] private Transform spawnPointEnemy;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask enemyLayer;
    private GameObject player;
    private GameObject enemy;
    public Transform SpawnPointPlayer => spawnPointPlayer;
    private void Awake()
    {
        SpawnPlayer();
        SpawnEnemy();

        
    }

    private void SpawnPlayer()
    {
        player = Instantiate(character, spawnPointPlayer);
        player.gameObject.name = "BarbarianPlayer";
        player.layer = spawnPointPlayer.gameObject.layer;
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.enabled = true;
    }
    private void SpawnEnemy()
    {
        enemy = Instantiate(character, spawnPointEnemy);
        enemy.gameObject.name = "BarbarianEnemy";
        enemy.layer = spawnPointEnemy.gameObject.layer;
        AI enemyController = enemy.GetComponent<AI>();
        enemyController.enabled = true;
    }

}
