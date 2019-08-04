using UnityEngine;

[System.Serializable]
public class Sounds
{
    [SerializeField] public string name;

    [SerializeField] public AudioClip clip;

    [Range(0f, 1f)]
    [SerializeField] public float volume;

    [HideInInspector]
    public AudioSource sources;
}