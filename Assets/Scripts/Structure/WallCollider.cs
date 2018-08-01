using UnityEngine;
using System.Collections;

public class WallCollider : MonoBehaviour {

    public GameObject player;
    public GameObject Wall;

    public float spawnTime = 3f;
    public float z_offset = 55;
    public float zposition;

    public Interface interfc;
    // Use this for initialization
    void Start () {
        interfc = GameObject.Find("Preferencias").GetComponent<Interface>();
        player = GameObject.Find("Player");

        z_offset = interfc.distz;
        InvokeRepeating("SpawnRing", spawnTime, spawnTime);
        zposition = player.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
