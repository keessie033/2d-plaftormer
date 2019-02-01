using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Explode : MonoBehaviour {

    public Debris debris;
    public int totalDebris = 10;
    public Vector3 spawnLocation;
    public Vector3 respawnLocation;
    public Text text;
    public int score;
    public float currentY;
    public GameObject prefab;
    public CamerFollow camerFollow;
    public AudioSource oof;
    public Player player;
    public GameObject[] heartsArray;

    // Use this for initialization
    void Start () {
    }   
	
	// Update is called once per frame
	void Update () {
        score = int.Parse(text.text);
        currentY = gameObject.transform.position.y-0.1f;
        player = GetComponent<Player>();
        heartsArray = player.hearts.ToArray();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "Deathly")
        {
            score -= 100;
            if (score == 0)
            {
                text.text = "0000";
            }
            else
            {
                text.text = score.ToString();
            }
            player.hp -= 10;
            Debug.Log(player.hp);
            Destroy(heartsArray[heartsArray.Length - 1]);
            player.hearts.RemoveAt(heartsArray.Length - 1);
            oof.Play();
            if (player.hp == 0)
            {
                StartCoroutine(respawn());
                player.hp = 50;
                player.hearts.Clear();
                player.setHearts();
            }
        }
    }

    void onExplode()
    {
        var t = transform;

        for(int i=0; i < totalDebris; i++)
        {
            t.TransformPoint(0, -100, 0);
            var clone = Instantiate(debris, t.position, Quaternion.identity) as Debris;
            var body2D = clone.GetComponent<Rigidbody2D>();
            body2D.AddForce(Vector3.right * Random.Range(-1000, 1000));
            body2D.AddForce(Vector3.up * Random.Range(500, 2000));
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float differnce = currentY - collision.transform.position.y;

        if (collision.gameObject.tag == "Deathly" && differnce > 0.5)
        {
            score += 100;
            if (score == 0)
            {
                text.text = "0000";
            }
            else
            {
                text.text = score.ToString();
            }
            Destroy(collision.gameObject); 
        }
        else if(collision.gameObject.tag == "Deathly")
        {
            score -= 100;
            if (score == 0)
            {
                text.text = "0000";
            }
            else
            {
                text.text = score.ToString();
            }
            player.hp -= 10;
            Debug.Log(player.hp);
            Destroy(heartsArray[heartsArray.Length - 1]);
            player.hearts.RemoveAt(heartsArray.Length - 1);
            oof.Play();
            if (player.hp == 0)
            {
                StartCoroutine(respawn());
                player.hp = 50;
                player.hearts.Clear();
                player.setHearts();
            }
        }
    }

    public IEnumerator respawn()
    {
        
        onExplode();
        yield return new WaitForSeconds(0.3f);
        var newPlayer = Instantiate(prefab, transform.position = spawnLocation, transform.rotation);
        newPlayer.name = "Player";
        camerFollow.target = newPlayer;
        Destroy(gameObject);
    }

}
