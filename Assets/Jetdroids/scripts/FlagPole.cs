using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class FlagPole : MonoBehaviour {
    public string levelName;
    private Animator animator;
    public AudioSource backgroundAudio;
    public AudioSource poleAudio;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
       
        if (target.gameObject.tag == "Player")
        {
            StartCoroutine(playAnimation());  
        }
    }

    public IEnumerator playAnimation()
    {
        backgroundAudio.Pause();
        poleAudio.Play();   
        animator.SetInteger("state", 1);
        yield return new WaitForSeconds(2);
        loadNextLevel();
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
