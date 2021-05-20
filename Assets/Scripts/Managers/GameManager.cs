using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
public class GameManager : Singleton<GameManager>
{
    InputMaster controls;
    [SerializeField] private GameObject ui;
    

    private bool isPaused = false;
    private PlayerController focusedPlayerController;


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

       // PlayerController playerController = player.GetComponent<PlayerController>();
       // playerController.enabled = true;
       // var playerInput = PlayerInput.Instantiate(player, 0, "Keyboard and Mouse",0, Keyboard.current);
     //   playerInput.DeactivateInput();
     // playerInput.uiInputModule = ui;
     //   playerInput.SwitchCurrentActionMap("UI");
    //    Debug.Log(playerInput.uiInputModule);
        
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
         //   enemyController.enabled = true;
        }
        else
        {
          //  PlayerInput enemyInput = enemy.GetComponent<PlayerInput>();

          //  playerInput.SwitchCurrentControlScheme("Gamepad",Gamepad.all[0]);
          //  PlayerController enemyController = enemy.GetComponent<PlayerController>();
          //  enemyController.enabled = true;
        }
    }


    public void TogglePauseState(PlayerController newFocusedPlayerController)
    {
        focusedPlayerController = newFocusedPlayerController;
    
        isPaused = !isPaused;

        ToggleTimeScale();

       // UpdateActivePlayerInputs();

        SwitchFocusedPlayerControlScheme();

        UpdateUIMenu();

        

    }

    /*
    void UpdateActivePlayerInputs()
    {
        for (int i = 0; i < activePlayerControllers.Count; i++)
        {
            if (activePlayerControllers[i] != focusedPlayerController)
            {
                activePlayerControllers[i].SetInputActiveState(isPaused);
            }

        }
    }
    */
    void SwitchFocusedPlayerControlScheme()
    {
        switch (isPaused)
        {
            case true:
                focusedPlayerController.EnablePauseMenuControls();
                break;

            case false:
                focusedPlayerController.EnableGameplayControls();
                break;
        }
    }

    void ToggleTimeScale()
    {
        float newTimeScale = 0f;

        switch (isPaused)
        {
            case true:
                newTimeScale = 0f;
                break;

            case false:
                newTimeScale = 1f;
                break;
        }
       

        Time.timeScale = newTimeScale;
    }
    void UpdateUIMenu()
    {
        if (isPaused)
        {
            ui.SetActive(true);
        }
        else
        {
            ui.SetActive(false);
        }
    }



}
