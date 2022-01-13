using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music musicManagerInstance;

    void Awake()
    {
        

        DontDestroyOnLoad(this);

        if(musicManagerInstance == null)
        {
            musicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Toggle()
    {
        //AudioSource audioSource = GetComponent<AudioSource>();
        //audioSource.mute = !audioSource.mute;
        AudioListener.volume = 0;
        
    }

}
