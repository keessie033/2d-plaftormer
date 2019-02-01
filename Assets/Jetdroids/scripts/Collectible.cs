using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour {

    public Text text;
    public int score;
    public AudioSource pickUp;
   
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        score = int.Parse(text.text);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            pickUp.Play();
            Destroy(gameObject);
            score += 100;
            if (score == 0)
            {
                text.text = "0000";
            }
            else
            {
                text.text = score.ToString();
            }
        }
    }

}
