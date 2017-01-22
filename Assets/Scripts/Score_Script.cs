using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Script : MonoBehaviour {
    private int score = 0;
    private float time = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 1)
        {
            score += 1;
            time -= 1;
            GetComponent<Text>().text = string.Concat("Leagues: ", score.ToString());
            GameObject.FindGameObjectWithTag("HiScore").GetComponent<Communication>().SetScore(score);
        }
	}

    public int GetScore()
    {
        return score;
    }
}
