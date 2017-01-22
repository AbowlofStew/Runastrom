using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScore_Retrieval : MonoBehaviour {
    private int score;

    // Use this for initialization
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("HiScore").GetComponent<Communication>().GetHiScore();
        GetComponent<Text>().text = string.Concat("High score: ", score);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
