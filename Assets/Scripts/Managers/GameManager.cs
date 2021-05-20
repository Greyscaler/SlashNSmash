using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    InputMaster controls;
    PlayerInput playerInput;
    


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
        

        Imovable playerCharacterMove = player.GetComponent<Imovable>();
        playerCharacterMove.SetRotate(Vector3.right);

        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.enabled = true;
    }
    private void SpawnEnemy()
    {
        enemy = Instantiate(character, spawnPointEnemy);
        enemy.gameObject.name = "BarbarianEnemy";
        Imovable enemyCharacterMove = enemy.GetComponent<Imovable>();
        enemyCharacterMove.SetRotate(Vector3.left);
        if (Gamepad.all.Count == 0)
        {
            AI enemyController = enemy.GetComponent<AI>();
            enemyController.enabled = true;
        }
        else
        {
            PlayerInput playerInput = enemy.GetComponent<PlayerInput>();
            playerInput.SwitchCurrentControlScheme("Gamepad",Gamepad.all[0]);
            PlayerController enemyController = enemy.GetComponent<PlayerController>();
            enemyController.enabled = true;
        }
    }



}
