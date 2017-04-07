using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setupMain : MonoBehaviour {
    public GameObject enemySpawner;
    public Transform theDonald;
    public Transform explosion;
    public Transform enemy1;
    public Transform enemy2;
    public GameObject player;
    public Canvas UICanvas;
    public Transform mainCamera;

    private Vector3 _spawner1Position;
    private Vector3 _spawner2Position;
    private SpawnerScript _spawner1Script;
    private SpawnerScript _spawner2Script;
    private float _spawnerTimer1;
    private float _spawnerTimer2;    
    private CameraController _cameraScript;
    private PlayerController _playerScript;
    private Vector3 _startingPlayerPosition;
    private Quaternion _startingPlayerRotation;
    private Vector3 _startingCameraPosition;
    private Quaternion _startingCameraRotation;
    private Canvas _instantiatedCanvas;
    private GameObject _instantiatedPlayer;

    // Use this for initialization
    void Start () {
        SpawnPlayer();
        //SetupSpawners();
    }

    // Setup enemy spawners
    void SetupSpawners()
    {
        _spawner1Position = new Vector3(0, 10, 0);
        _spawner2Position = new Vector3(10, 0, 0);

        GameObject instantiatedSpawner1 = Instantiate(enemySpawner, _spawner1Position, transform.rotation);
        GameObject instantiatedSpawner2 = Instantiate(enemySpawner, _spawner2Position, transform.rotation);

        _spawner1Script = instantiatedSpawner1.GetComponent<SpawnerScript>();
        _spawner2Script = instantiatedSpawner2.GetComponent<SpawnerScript>();

        _spawner1Script.enemy = enemy1;
        _spawner1Script.explosion = explosion;
        _spawner1Script.textScript = _instantiatedCanvas.GetComponentInChildren<TextStuff>();
        _spawner1Script.theDonald = theDonald;
        _spawner1Script.player = _instantiatedPlayer.transform;
        _spawner2Script.enemy = enemy2;
        _spawner2Script.explosion = explosion;
        _spawner2Script.textScript = _instantiatedCanvas.GetComponentInChildren<TextStuff>();
        _spawner2Script.theDonald = theDonald;
        _spawner2Script.player = _instantiatedPlayer.transform;
    }

    // Spawn the player
    void SpawnPlayer()
    {
        _startingPlayerPosition = new Vector3(mainCamera.position.x, mainCamera.position.y, 0);
        _startingPlayerRotation = new Quaternion(mainCamera.rotation.x, mainCamera.rotation.y, mainCamera.rotation.z, mainCamera.rotation.w);
        _startingCameraPosition = new Vector3(mainCamera.position.x, mainCamera.position.y, mainCamera.position.z);
        _startingCameraRotation = new Quaternion(mainCamera.rotation.x, mainCamera.rotation.y, mainCamera.rotation.z, mainCamera.rotation.w);

        _instantiatedPlayer = Instantiate(player, _startingPlayerPosition, _startingPlayerRotation);
        _instantiatedCanvas = Instantiate(UICanvas);
        Transform instantiatedCamera = Instantiate(mainCamera, _startingCameraPosition, _startingCameraRotation);

        // Set up player
        _playerScript = _instantiatedPlayer.GetComponent<PlayerController>();
        _playerScript.textScript = _instantiatedCanvas.GetComponentInChildren<TextStuff>();

        // Set up UI

        // Set up the camera
        instantiatedCamera.tag = "MainCamera";
        _cameraScript = instantiatedCamera.GetComponent<CameraController>();
        _cameraScript.player = _instantiatedPlayer;
    }
}
