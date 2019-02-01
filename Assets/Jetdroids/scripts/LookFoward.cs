using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFoward : MonoBehaviour {

    public Transform sightStart;
    public Transform sightEnd;
    public string layer = "Solid";
    public bool needsColision = true;

    private bool colision;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        colision = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer(layer));
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        if (colision == needsColision)
        {
            transform.localScale = new Vector3(transform.localScale.x == 1 ? -1 : 1,1,1);
        }
	}
}
