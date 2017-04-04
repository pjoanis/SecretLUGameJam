using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        animationComplete();
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    public void animationComplete()
    {
        Destroy(this.gameObject,10);
    }
}
