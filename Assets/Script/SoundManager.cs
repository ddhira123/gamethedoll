using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip jump, slash;
    static AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
         jump = GetComponent<AudioClip> ();
         slash = GetComponent<AudioClip>();
         src = GetComponent<AudioSource>();
    }

    /*audio
    1 = jump
    2 = slash
    0 = otherwise
    */

    // Update is called once per frame
    public void PlaySound(int girlBehave)
    {
        switch(girlBehave)
        {
            case 1:
                src.PlayOneShot (jump);
                break;
            case 2:
                src.PlayOneShot (slash);
                break;
        }
    }
}
