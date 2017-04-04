using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // lifetime of bullet in seconds
        float lifeTime = 5;
        Destroy(this.gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
