using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private Transform enemySpawn;
    [SerializeField] private float minZDistance=10f;
    [SerializeField] private float margine = 5.0f;
    private Transform player;
    private Transform enemy;
    private Camera camera;
    private float cosAngle, camPosX, camPosZ;
    void Start()
    {
        player = playerSpawn.GetChild(0);
        enemy = enemySpawn.GetChild(0);
        camera = GetComponent<Camera>();
        cosAngle = Mathf.Cos((camera.fieldOfView / 2)*Mathf.Deg2Rad);
    }
    void Update()
    {
        camPosX = (player.position.x + enemy.position.x) / 2;
        camPosZ = -((Mathf.Abs(player.position.x - camPosX) + margine) * cosAngle);
        
        if (camPosZ > -minZDistance)
        {
            camPosZ = -minZDistance;
        }
        transform.SetPositionAndRotation(new Vector3(camPosX,0,camPosZ),transform.rotation);
    }
}
