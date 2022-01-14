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

    public void Toggle(bool toggleOn)
    {
        //AudioSource audioSource = GetComponent<AudioSource>();
        //audioSource.mute = !audioSource.mute;
        //AudioListener.volume = 0;
        if (toggleOn)
        {
            Destroy(gameObject);
        }
        else
        {
            musicManagerInstance = this;
        }
    }

}
