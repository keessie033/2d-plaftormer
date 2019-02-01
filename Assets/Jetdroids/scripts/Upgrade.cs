using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {
    public GameObject canvas;
    public Transform interact;
    public bool isEnabled = false;

	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("Canvas");
        interact=canvas.transform.Find("interact");
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            interact.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("e"))
        {
            if (!isEnabled)
            {
                isEnabled = true;
                Debug.Log("Hello World!");
            }
            else
            {
                isEnabled = false;
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            interact.gameObject.SetActive(false);
        }
    }
}
