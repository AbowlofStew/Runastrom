using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    float timer = 0;
    public float animationTime = 0.01f;
    public string state = "main";
    public int frame = 0;

    public Sprite main1;
    public Sprite main2;
    public Sprite main3;
    public Sprite left;
    public Sprite right;
    public List<Sprite> main = new List<Sprite>();
    // Use this for initialization
    void Start()
    {
        main.Add(main1);
        main.Add(main2);
        main.Add(main3);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= animationTime && state == "main")
        {
            timer = 0;
            switchframe(main);
           
        }
        if(state == "left")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = left;
        }
        if (state == "right")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
        }
    }
    public void switchframe(List<Sprite> list)
    {
        if (frame >= list.Count)
        {
            frame = 0;
        }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = list[frame];
        frame += 1;
    }
}