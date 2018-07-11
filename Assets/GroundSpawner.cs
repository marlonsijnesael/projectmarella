using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {

    public GameObject groundPrefab;
    public int speed;
    public float spawnRate;
    public int groundPieces = 0;
    public int maxGroundPieces;
    private GameObject[] spawnedGroundPieces;

    // Use this for initialization
    void Start() {
        StartCoroutine(SpawnGround());
        spawnedGroundPieces = new GameObject[maxGroundPieces];
    }

    private IEnumerator SpawnGround() {
        yield return new WaitForSeconds(spawnRate);
        if (groundPieces < maxGroundPieces) {
            GameObject ground = Instantiate(groundPrefab);
            ground.transform.position = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
            ground.transform.SetParent(this.transform);
            spawnedGroundPieces[groundPieces] = ground;
            groundPieces++;
            StartCoroutine(SpawnGround());
        }
    }
}
