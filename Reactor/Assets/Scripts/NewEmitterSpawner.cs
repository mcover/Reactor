using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEmitterSpawner : MonoBehaviour {
    public GameObject emitterPrefab;
    public Transform spawnPosition;
	
    public void SpawnNewEmitter()
    {
        float posHeight = Random.Range(-4, 4);
        float posWidth = Random.Range(-5, 5); 
        GameObject newPiece = Instantiate(emitterPrefab, new Vector3(posWidth, posHeight,0), Quaternion.identity) as GameObject;
    }
}
