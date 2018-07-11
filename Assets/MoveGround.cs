using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour {

    private void Update() {
        if (SpawnGround.player.transform.position.x > transform.position.x + SpawnGround.lengthInUnits) {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame

}
