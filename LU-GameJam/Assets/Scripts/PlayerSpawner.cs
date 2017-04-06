using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public GameObject player;
    public Canvas UICanvas;
    public Transform mainCamera;

    private CameraController cameraScript;
    private PlayerController playerScript;
    private Vector3 startingPlayerPosition;
    private Quaternion startingPlayerRotation;
    private Vector3 startingCameraPosition;
    private Quaternion startingCameraRotation;

    // Use this for initialization
    void Start () {
        startingPlayerPosition = new Vector3(mainCamera.position.x, mainCamera.position.y, 0);
        startingPlayerRotation = new Quaternion(mainCamera.rotation.x, mainCamera.rotation.y, mainCamera.rotation.z, mainCamera.rotation.w);
        startingCameraPosition = new Vector3(mainCamera.position.x, mainCamera.position.y, mainCamera.position.z);
        startingCameraRotation = new Quaternion(mainCamera.rotation.x, mainCamera.rotation.y, mainCamera.rotation.z, mainCamera.rotation.w);

        SpawnPlayer();
	}
	
	// Spawn the player
    void SpawnPlayer()
    {
        GameObject instantiatedPlayer = Instantiate(player, startingPlayerPosition, startingPlayerRotation);
        Canvas instantiatedCanvas = Instantiate(UICanvas);
        Transform instantiatedCamera = Instantiate(mainCamera, startingCameraPosition, startingCameraRotation);

        // Set up player
        playerScript = instantiatedPlayer.GetComponent<PlayerController>();
        playerScript.textScript = instantiatedCanvas.GetComponentInChildren<TextStuff>();            

        // Set up UI

        // Set up the camera
        instantiatedCamera.tag = "MainCamera";
        cameraScript = instantiatedCamera.GetComponent<CameraController>();
        cameraScript.player = instantiatedPlayer;
    }
}
