using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour  // This is a Singleton Audio Manager
{
    //References
    public static AudioControl instance;

    public static float saveVol;

    public AudioMixer Mixer;
    public Sounds[] sounds;

    [SerializeField] private Slider Vol;

    // Use this for initialization
    private void Awake()
    {
        transform.Find("Volume slider");
        if (instance == null) //Singleton
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds) //Array of Sounds to get call from all scripts
        {
            s.sources = gameObject.AddComponent<AudioSource>();
            s.sources.clip = s.clip;
            s.sources.playOnAwake = false;
            s.sources.volume = s.volume;
            s.sources.pitch = s.pitch;
        }
    }

    public void Volume(float vol) //Audio slider for Game Volume
    {
        Mixer.SetFloat("vol", vol);
    }

    public void Play(string name) //For calling from any script to Play Sounds
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.sources.Play();
        if (!s.sources.isPlaying)
            s.sources.PlayOneShot(s.sources.clip);
    }

    public void sVol() //Saving the value of the volume between Scens
    {
        saveVol = Vol.value;
    }

    public void lVol() //Loading the value of the volume to other Scenes
    {
        Vol.value = saveVol;
    }
}