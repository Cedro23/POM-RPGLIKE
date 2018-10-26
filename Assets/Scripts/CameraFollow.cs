using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 playerPos;
    
	// Update is called once per frame
	void Update () {
        playerPos = player.transform.position;
        this.transform.position = playerPos + new Vector3( 0, 0, -1);
	}
}
