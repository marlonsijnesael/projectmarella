using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour {

    int moveSpeed = 6;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x > 10) {
            transform.position = new Vector3(- 10, transform.position.y, transform.position.z);
        }
	}
}
