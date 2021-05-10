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
    private void Awake()
    {
        player = Instantiate(character, spawnPointPlayer);
        enemy = Instantiate(character, spawnPointEnemy);
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.enabled = true;

    }


}
