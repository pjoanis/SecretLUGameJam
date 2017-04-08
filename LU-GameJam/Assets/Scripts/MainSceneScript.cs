using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneScript : MonoBehaviour {
    public GameObject playerPrefab;
    public Canvas UIPrefab;
    public Transform mainCameraPrefab;

    private PlayerSpawner _playerSpawner;

	// Use this for initialization
	void Start () {
        _playerSpawner = GetComponent<PlayerSpawner>();
        _playerSpawner.Player = playerPrefab;
        _playerSpawner.UICanvas = UIPrefab;
        _playerSpawner.MainCamera = mainCameraPrefab;
        _playerSpawner.SpawnPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
