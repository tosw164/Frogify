using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// Credit: https://www.youtube.com/watch?v=6OT43pvUyfY&t=41s
/// </summary>
public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    [HideInInspector]
    public ArrayList currentlyPlaying = new ArrayList();

    public static AudioManager instance;

	// Use this for initialization
	void Awake () {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Can't find (play) name of sound: " + name);
        }
        s.source.Play();
        currentlyPlaying.Add(s);
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Can't find (stop) name of sound: " + name);
        }
        s.source.Stop();
        currentlyPlaying.Remove(s);
    }

    public void StopAll() {
        foreach(Sound s in currentlyPlaying)
        {
            s.source.Stop();
        }
        currentlyPlaying.Clear();
    }

    public bool isPlaying(string name)
    {
        foreach (Sound s in currentlyPlaying)
        {
            if (s.name.Equals(name)) {
                return true;
            }
        }
        return false;
    }
}
