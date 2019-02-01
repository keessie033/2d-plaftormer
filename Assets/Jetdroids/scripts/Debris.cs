using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

    private SpriteRenderer render2D;
    private Color start;
    private Color end;
    private float t = 0f;

	// Use this for initialization
	void Start () {
        render2D = GetComponent<SpriteRenderer>();
        start = render2D.color;
        end = new Color(start.r, start.g, start.b, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        render2D.material.color = Color.Lerp(start, end, t / 2);

        if(render2D.material.color.a <= 0f) {
            Destroy(gameObject);
        }
	}
}
