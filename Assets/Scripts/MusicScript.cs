using UnityEngine;

public class MusicScript : MonoBehaviour
{
    AudioSource source;
    double pauseClipTime = 0;
    public AudioClip[] clips;
    int actualClip = 0;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clips[0];
        source.Play();
    }

    private void Update()
    {
        if (source.time >= clips[actualClip].length)
        {
            actualClip++;
            actualClip %= clips.Length;
            source.clip = clips[actualClip];
            source.Play();
        }
    }

    public void OnPauseGame()
    {
        pauseClipTime = source.time;
        source.Pause();
    }

    public void OnResumeGame()
    {
        source.PlayScheduled(pauseClipTime);
        pauseClipTime = 0;
    }

    public void PitchThis(float pitch)
    {
        source.pitch = pitch;
    }
}
