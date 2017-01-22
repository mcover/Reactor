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
        Quaternion rotation = Quaternion.EulerAngles(0, 0, Random.Range(0, 360));
        GameObject newPiece = Instantiate(emitterPrefab, new Vector3(posWidth, posHeight,0), rotation) as GameObject;
    }
}
