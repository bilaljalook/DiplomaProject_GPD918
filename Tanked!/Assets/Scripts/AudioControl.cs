using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public AudioMixer Mixer;

    [SerializeField] public Sounds[] sounds;

    public static AudioControl instance;

    [SerializeField] private Slider Vol;

    public static float saveVol;

    // Use this for initialization
    private void Awake()
    {
        transform.Find("Volume slider");
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sounds s in sounds)
        {
            s.sources = gameObject.AddComponent<AudioSource>();
            s.sources.clip = s.clip;

            s.sources.volume = s.volume;
           
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Volume(float vol)
    {
        Mixer.SetFloat("vol", vol);
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.sources.Play();
    }

    public void sVol()
    {
        saveVol = Vol.value;
    }

    public void lVol()
    {
        Vol.value = saveVol;
    }
}