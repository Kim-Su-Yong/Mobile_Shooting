using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public bool isSoundMute = false;
    private void Awake()
    {
        if (soundManager == null)
            soundManager = this;
        else if (soundManager != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    public void PlayScene()
    {
        SceneManager.LoadScene("Play");
    }
    public void PlaySoundMethod(Vector3 pos, AudioClip audioClip)
    {
        if (isSoundMute) return;
        GameObject soundObj = new GameObject("Sfx");
        soundObj.transform.position = pos;
        AudioSource source = soundObj.AddComponent<AudioSource>();
        source.clip = audioClip;
        source.minDistance = 19f;
        source.maxDistance = 20f;
        source.volume = 1.0f;
        source.Play();
        Destroy(soundObj, audioClip.length);
    }
    public void PlaySoundMethod(Vector3 pos, AudioClip audioClip, bool isLoop)
    {
        if (isSoundMute) return;
        GameObject soundObj = new GameObject("Sfx");
        soundObj.transform.position = pos;
        AudioSource source = soundObj.AddComponent<AudioSource>();
        source.clip = audioClip;
        source.minDistance = 19f;
        source.maxDistance = 20f;
        source.volume = 1.0f;
        source.loop = isLoop;
        source.Play();
    }
}
