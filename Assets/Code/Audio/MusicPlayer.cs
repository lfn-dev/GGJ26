using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource musicA, musicB;

    private AudioSource activeMusic;

    private void Awake()
    {
        musicA.Play();
        musicB.Play();
        activeMusic = musicA;
        musicB.volume = 0f;
    }

    public void SwapMusic()
    {
        activeMusic.volume = 0f;

        activeMusic = activeMusic == musicA ? musicB : musicA;

        activeMusic.volume = 1f;
    }
}
