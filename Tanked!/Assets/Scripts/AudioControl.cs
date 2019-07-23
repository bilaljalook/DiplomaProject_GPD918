using UnityEngine;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    public AudioMixer Mixer;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Volume(float vol)
    {
        Mixer.SetFloat("vol", vol);
    }
}