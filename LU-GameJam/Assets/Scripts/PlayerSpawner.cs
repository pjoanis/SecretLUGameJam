using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {    
    private CameraController _cameraScript;
    private PlayerController _playerScript;
    private Vector3 _startingPlayerPosition;
    private Quaternion _startingPlayerRotation;
    private Vector3 _startingCameraPosition;
    private Quaternion _startingCameraRotation;
    private GameObject _instantiatedPlayer;
    private GameObject _player;
    private Canvas _UICanvas;
    private Transform _mainCamera;

    public GameObject Player
    {
        get
        {
            return _player;
        }
        set
        {
            _player = value;
        }
    }

    public Canvas UICanvas
    {
        get
        {
            return _UICanvas;
        }
        set
        {
            _UICanvas = value;
        }
    }

    public Transform MainCamera
    {
        get
        {
            return _mainCamera;
        }
        set
        {
            _mainCamera = value;
        }
    }

    // Use this for initialization
    void Start () {
                
	}
	
	// Spawn the player
    public void SpawnPlayer()
    {
        _startingPlayerPosition = new Vector3(_mainCamera.position.x, _mainCamera.position.y, 0);
        _startingPlayerRotation = new Quaternion(_mainCamera.rotation.x, _mainCamera.rotation.y, _mainCamera.rotation.z, _mainCamera.rotation.w);
        _startingCameraPosition = new Vector3(_mainCamera.position.x, _mainCamera.position.y, _mainCamera.position.z);
        _startingCameraRotation = new Quaternion(_mainCamera.rotation.x, _mainCamera.rotation.y, _mainCamera.rotation.z, _mainCamera.rotation.w);

        _instantiatedPlayer = Instantiate(_player, _startingPlayerPosition, _startingPlayerRotation);
        Canvas instantiatedCanvas = Instantiate(_UICanvas);
        Transform instantiatedCamera = Instantiate(_mainCamera, _startingCameraPosition, _startingCameraRotation);

        // Set up player
        _playerScript = _instantiatedPlayer.GetComponent<PlayerController>();
        _playerScript.textScript = instantiatedCanvas.GetComponentInChildren<TextStuff>();            

        // Set up UI

        // Set up the camera
        instantiatedCamera.tag = "MainCamera";
        _cameraScript = instantiatedCamera.GetComponent<CameraController>();
        _cameraScript.player = _instantiatedPlayer;
    }
}
