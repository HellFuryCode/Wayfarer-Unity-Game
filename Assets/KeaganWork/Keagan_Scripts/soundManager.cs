using UnityEngine;
using System;

// reference to code used: Small Hedge Games.(2024, April 14). PLEASE use a Unity SOUND MANAGER! - Full Tutorial[Video].YouTube.https://youtu.be/g5WT91Sn3hg?si=ti6wzqngO7P4FM6M
public enum soundType
{
    Sounds1,
    Sounds2,
    Sounds3,
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class soundManager : MonoBehaviour
{
    public static soundManager instance;
    private AudioSource audioSource;
    [SerializeField] private soundList[] audioClips;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public static void playAudio(soundType soundType, int arrayIndex, float volume)
    {
        AudioClip[] clips = instance.audioClips[(int) soundType].audio;
        AudioClip chosenClip = clips[arrayIndex];
        instance.audioSource.PlayOneShot(chosenClip, volume);
    }
#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(soundType));
        Array.Resize(ref audioClips, names.Length);

        for(int i = 0;i<audioClips.Length;i++)
        {
            audioClips[i].name = names[i];
        }
    }
#endif
}
[Serializable]
public struct soundList
{
    public AudioClip[] audio { get => sounds; }
    [HideInInspector] public string name;
    [SerializeField] public AudioClip[] sounds;
}
