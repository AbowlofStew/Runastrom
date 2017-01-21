using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Tile_Spawner : MonoBehaviour {
    public GameObject Tile;
    private GameObject Tile2;
    // Use this for initialization
    void Start () {
        Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1.35f));
        Tile.transform.position = p;
        float xSize = Tile.GetComponent<SpriteRenderer>().bounds.size.x;

        Tile2 = Instantiate(Tile, new Vector3(xSize, 0, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
