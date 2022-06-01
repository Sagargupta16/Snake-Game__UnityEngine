using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerEatSound ,GameOverSound;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        playerEatSound = Resources.Load<AudioClip> ("ding");
        GameOverSound = Resources.Load<AudioClip>("gameover");
        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "ding": 
                audiosrc.PlayOneShot(playerEatSound);
                break;
            case "gameover":
                audiosrc.PlayOneShot(GameOverSound);
                break;
        }
    }
}
