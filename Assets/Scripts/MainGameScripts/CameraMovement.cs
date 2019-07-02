using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform Player;
	
    // The camera always follows the position of the player
	void Update () {
        transform.position = new Vector3(Player.position.x, Player.position.y, Player.position.z - 10);
	}
}
