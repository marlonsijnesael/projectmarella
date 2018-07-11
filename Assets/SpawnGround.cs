using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour {

    public GameObject[] prefabsGround;

    public static int lengthInUnits = 10;
    public int maxTilesAmount = 5;
    public static GameObject player;
    private float spawnPoint = 0;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < maxTilesAmount; i++) {
            SpawnTile(Random.Range(0, prefabsGround.Length));
        }
    }

    private void Update() {
        if (player.transform.position.x > (spawnPoint - maxTilesAmount * lengthInUnits)){
            SpawnTile(Random.Range(0, prefabsGround.Length));
        }
    }

    private void SpawnTile(int _SpawnIndex) {
        GameObject tile = Instantiate(prefabsGround[_SpawnIndex]);
        tile.transform.SetParent(this.gameObject.transform);
        tile.transform.position = Vector3.right * spawnPoint;
        spawnPoint += lengthInUnits;
    }
}




