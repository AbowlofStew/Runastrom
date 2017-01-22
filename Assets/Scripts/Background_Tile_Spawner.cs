using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Tile_Spawner : MonoBehaviour {
    public GameObject Tile;
    private float xSize;
    private float ySize;
    private Vector3 screenUpperRight;
    public List<Background_Script> ocean;
    // Use this for initialization
    void Start () {
        screenUpperRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
        Vector3 bottomRight = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));
        Vector3 screenSize = new Vector3(screenUpperRight.x - bottomRight.x, screenUpperRight.y - bottomRight.y, 0);
        Vector3 p = screenUpperRight;
        xSize = Tile.GetComponent<SpriteRenderer>().bounds.size.x;
        ySize = Tile.GetComponent<SpriteRenderer>().bounds.size.y;
        p.Set(p.x + xSize, p.y + ySize, p.z);

        for (int j = 0; j < 7; j++)
        {
            for (int i = 0; i < 16; i++)
            {
                Instantiate(Tile, p, Quaternion.identity);
                ocean.Add(Tile.GetComponent<Background_Script>());
                p.Set(p.x - screenSize.x / 14, p.y, p.z);
            }
            p.Set(screenUpperRight.x + xSize, p.y - screenSize.y / 6, p.z);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeOceanScrollSpeed(float speed)
    {
        foreach(Background_Script b in ocean)
        {
            b.baseScrollSpeed = speed;
        }
    }
}
