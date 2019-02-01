using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour {

    public Sprite[] Sprites;
    public int currentSprite = -1;
    // Use this for initialization
    void Start()
    {
        if (currentSprite == -1)
        {
            currentSprite = Random.Range(0, Sprites.Length);
        }
        else if (currentSprite > Sprites.Length)
        {
            currentSprite = Sprites.Length - 1;
        }
        GetComponent<SpriteRenderer>().sprite = Sprites[currentSprite];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
