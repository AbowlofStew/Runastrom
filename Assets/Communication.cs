using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communication : MonoBehaviour {
    private int score;
    private int hiScore = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScore(int newScore)
    {
        score = newScore;
        if (score > hiScore)
        {
            hiScore = score;
        }
    }

    public int GetScore()
    {
        return score;
    }
    public int GetHiScore()
    {
        return hiScore;
    }
}
