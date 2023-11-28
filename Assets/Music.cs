using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource currentMusic;
    bool waitingForLoopToFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject music1 = GameObject.Find("music1");
        GameObject music2 = GameObject.Find("music2");
        audio1 = music1.GetComponent<AudioSource>();
        audio2 = music2.GetComponent<AudioSource>();
        audio1.loop = true;
        audio2.loop = true;
        currentMusic = audio1;
        //currentMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
         {
            StartCoroutine(updateMusic(audio1, audio2));
         }
         if (Input.GetKeyDown(KeyCode.KeypadEnter)) 
         {
             StartCoroutine(updateMusic(audio2, audio1));
         }
        if (Input.GetKeyDown(KeyCode.Alpha9)) {
            playSound("musicauxguitar");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) {
            playSound("musicauxperc");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) {
            playSound("musicbreathing");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            playSound("musicweirdguitar");
        }
    }

    public void playSound(string soundName) {
        GameObject gameObject = GameObject.Find(soundName);
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.Play();
    }

    public void playMusic2Coroutine() {
        StartCoroutine(updateMusic(audio1, audio2));
    }

    public void playMusic2() {
        audio1.loop = true;
        currentMusic.Stop();
        audio2.Play();
    }

    private IEnumerator updateMusic(AudioSource toStop, AudioSource toPlay) {
        if (!waitingForLoopToFinish && currentMusic == toStop) {
            waitingForLoopToFinish = true;
            toPlay.loop = true;
            toStop.loop = false;
            while (toStop.isPlaying) {
                // Wait for current music loop to finish
                // Wait for a frame to give Unity and other scripts chance to run
                yield return new WaitForEndOfFrame();
            }
            toPlay.Play();
            currentMusic = toPlay;
            waitingForLoopToFinish = false;
        }
    }

    public static class Sounds {
        public const string MUSIC_AUX_GUITAR = "musicauxguitar";
        public const string MUSIC_AUX_PERC = "musicauxperc";
    }
}




