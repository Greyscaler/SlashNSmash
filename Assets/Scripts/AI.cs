using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Character character;
    private GameManager gameManager;
    private Transform player;
    private CharacterController playerCharacterController;
    private void Awake()
    {
        character = GetComponent<Character>();
        gameManager = transform.parent.parent.GetComponent<GameManager>();
        player = gameManager.SpawnPointPlayer.GetChild(0);
        playerCharacterController = player.GetComponent<CharacterController>();

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (character.transform.position.x > player.position.x)
        {
            character.Move(new Vector3(-1, 0, 0));
        }
        else
        {
            character.Move(new Vector3(1, 0, 0));
        }
        float distance = Vector3.Distance(player.position, character.transform.position);

        if (distance < 6* playerCharacterController.radius)
        {
            character.Move(Vector3.zero);
        }
    }

    private void SetDirection()
    {

    }

}
