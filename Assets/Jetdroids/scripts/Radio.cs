using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{

    public AudioSource background;
    public Text interact;
    public bool isEnabled = true;


    

    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

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
                background.Play();
            }
            else
            {
                isEnabled = false;
                background.Pause();
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
