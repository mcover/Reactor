using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEmitterSpawner : MonoBehaviour {
    public GameObject emitterPrefab;
    public Transform spawnPosition;
	
    public void SpawnNewEmitter()
    {
        GameObject newPiece = Instantiate(emitterPrefab, spawnPosition.position, Quaternion.identity) as GameObject;
        Debug.Log("Being called");
    }
}
