using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Over : MonoBehaviour {
    int frame = 0;
    float timer;
    public float timeBtwFrames;
    public List<Sprite> frames = new List<Sprite>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		if(timer >= timeBtwFrames && frame < 10)
        {
            animate(frame);
            frame += 1;
            timer = 0;
        }
	}
    public void animate(int a)
    {
        this.gameObject.GetComponent<Image>().sprite = frames[a];
    }
}
