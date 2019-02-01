using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour {

    public GameObject target;
    public float scale = 4f;
    private Transform t;

    void Awake()
    {
        var cam = GetComponent<Camera>();
        cam.orthographicSize = (Screen.height / 2f) / scale;
       
    }

    // Use this for initialization
    void Start () {
        t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
        t = target.transform;
        if (target != null)
        {
            transform.position = new Vector3 (t.position.x, t.position.y, transform.position.z);
        }
	}
}
