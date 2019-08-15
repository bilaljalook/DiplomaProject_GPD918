using UnityEngine;

[System.Serializable]
public class Sounds //this Class holder for sounds array in Audio Control
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource sources;
}