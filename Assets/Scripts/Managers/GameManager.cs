using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private Transform spawnPointPlayer;
    [SerializeField] private Transform spawnPointEnemy;
    private GameObject player;
    private GameObject enemy;
    private int[] _layers = new int[2];
    public int[] Layers => _layers;
    public Transform SpawnPointPlayer => spawnPointPlayer;
    private void Awake()
    {
        _layers[0] = spawnPointPlayer.gameObject.layer;
        _layers[1] = spawnPointEnemy.gameObject.layer;
        SpawnPlayer();
        SpawnEnemy();
    }
    private void SpawnPlayer()
    {
        player = Instantiate(character, spawnPointPlayer);
        player.gameObject.name = "BarbarianPlayer";
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.enabled = true;
    }
    private void SpawnEnemy()
    {
        enemy = Instantiate(character, spawnPointEnemy);
        enemy.gameObject.name = "BarbarianEnemy";
        AI enemyController = enemy.GetComponent<AI>();
        //enemyController.enabled = true;
    }



}
