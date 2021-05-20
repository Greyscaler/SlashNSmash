using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private Transform enemySpawn;
    [SerializeField] private float minZDistance=10f;
    [SerializeField] private float margine = 5.0f;
    private Transform[] characters = new Transform[2];
    private Camera mainCamera;
    private float cosAngle, camPosX = 0f, camPosZ;
    private float minXDistance;
    void Start()
    {
        characters[0] = playerSpawn.GetChild(0);
        characters[1] = enemySpawn.GetChild(0);
        mainCamera = GetComponent<Camera>();

        camPosZ = -minZDistance;
        cosAngle = Mathf.Cos((mainCamera.fieldOfView / 2)*Mathf.Deg2Rad);
        minXDistance = (minZDistance / cosAngle)*2 - margine*2;         //getting min width - margins of minZ
    }
    void Update()
    {
        if (Mathf.Abs(characters[0].position.x - characters[1].position.x) > minXDistance)
        {
            camPosX = (characters[0].position.x + characters[1].position.x) / 2;
            camPosZ = -((Mathf.Abs(characters[0].position.x - transform.position.x) + margine) * cosAngle);

            if (camPosZ > -minZDistance)
            {
                camPosZ = -minZDistance;
            }
        }
        
        else
        {
            foreach (Transform character in characters)
            {
                if (character.position.x > transform.position.x + minXDistance / 2)
                {
                    camPosX = transform.position.x + (Mathf.Abs(character.position.x - transform.position.x) - minXDistance / 2);
                }
                else if(character.position.x < transform.position.x - minXDistance / 2)
                {
                    camPosX = transform.position.x - (Mathf.Abs(character.position.x - transform.position.x) - minXDistance / 2);
                }
            }
        }
        transform.position = new Vector3(camPosX, 0, camPosZ);
    }
}
