using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Script : MonoBehaviour {
    public float baseScrollSpeed = 0.01f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate((Vector3.left + Vector3.down) * baseScrollSpeed);
	}
}
