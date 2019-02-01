 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed = 150f;
    public Vector2 maxVelocity = new Vector2(60,100);
    public float jetSpeed = 200f;
    public bool standing;
    public float airSpeedMulitplier = .3f;
    public float standingThreshold = 4;
    public Text text;
    public bool checkpointReached = false;
    public int hp = 30;
    public Explode explode;
    public GameObject heart;
    public List<GameObject> hearts;
    public Transform canvas;
    private Rigidbody2D body2D;
    private SpriteRenderer render2D;
    private PlayerController controller;
    private Animator animator;
    
   

	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();
        render2D = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        hearts = new List<GameObject>();
        setHearts();

    }
    
    // Update is called once per frame
    void Update() {
        Debug.Log(hearts);
        var absVelX = Mathf.Abs(body2D.velocity.x);
        var absVelY = Mathf.Abs(body2D.velocity.y);

        if (absVelY <= standingThreshold)
        {
            standing = true;
        }
        else
        {
            standing = false;
        }

        var forceX = 0f;
        var forceY = 0f;

        if (controller.moving.x != 0)
        {
            if (absVelX < maxVelocity.x)
            {
                var newSpeed = speed * controller.moving.x;
                forceX = standing ? newSpeed : (newSpeed * airSpeedMulitplier);
                render2D.flipX = forceX < 0;
            }
            animator.SetInteger("AnimState", 1);
        }
        else {
            animator.SetInteger("AnimState", 0);
        }

        if (controller.moving.y > 0)
        {
            if (absVelY < maxVelocity.y)
            {
                forceY = jetSpeed * controller.moving.y;
            }
            animator.SetInteger("AnimState", 2);
        }
        else if (absVelX > 0 && !standing)
        {
            animator.SetInteger("AnimState", 3);
        }
           
        body2D.AddForce(new Vector2(forceX, forceY));
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            explode.spawnLocation = explode.respawnLocation;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn" && checkpointReached == false)
        {
            text.gameObject.SetActive(true);
            checkpointReached = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            text.gameObject.SetActive(false);
        }
    }

    public void setHearts()
    {
        hearts =  new List<GameObject>();
        for (int i = 0; i < hp; i += 10)
        {
            var newHeart = Instantiate(heart, new Vector3(280 - 2 * i, 55, 1), transform.rotation);
            hearts.Add(newHeart);
            newHeart.gameObject.transform.SetParent(canvas);
            newHeart.gameObject.name = "heart";
            newHeart.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

}

