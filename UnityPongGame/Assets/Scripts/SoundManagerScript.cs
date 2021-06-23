using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip wallHit, goalHit;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        wallHit = Resources.Load<AudioClip>("wallHit");
        goalHit = Resources.Load<AudioClip>("goalHit");
      
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void PlaySound(string a)
    {
        switch (a)
        {
            case "wallHit":
                audioSrc.PlayOneShot(wallHit);
                break;
            case "goalHit":
                audioSrc.PlayOneShot(goalHit);
                break;
              
        }
    }

}
