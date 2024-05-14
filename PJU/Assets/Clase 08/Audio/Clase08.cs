using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Clase08 : MonoBehaviour // AudioManager => singleton
{
	//public FMOD_SOund_REFERENCE sonido;
	//public FMOD_Engine fmodEngine;

	public AudioSource musicSource;

	public AudioClip defaultMusic;

	public AudioSource sound2DPrefab;
	public AudioSource sound3DPrefab;

	public float sfxVolume;

	public AudioMixer mixer;

	void Start()
    {
		//musicSource.volume
        PlayMusic();
        mixer.SetFloat("Volumen", sfxVolume);

		//fmodEngine.SetMixerVolumen("SFX", sfxVolume)

	}

	public void Update()
	{
		Debug.Log("UPDATE LOCO");
	}

	public void PlaySound3D(Vector3 worldPos, AudioClip ac = null)
    {
		//Instantiate(sou)
		AudioSource aSource = Instantiate(sound3DPrefab, worldPos, Quaternion.identity, transform);
		aSource.clip = ac;
		aSource.volume = sfxVolume;
		aSource.Play();
		Destroy(aSource.gameObject, 5);

		//AudioSource.PlayClipAtPoint(ac, new Vector3(5, 1, 2));
	}

    public void PlaySound2D(AudioClip ac = null)
    {
	    AudioSource aSource = Instantiate(sound2DPrefab);
	    aSource.volume = sfxVolume;
	    aSource.Play();
	}

	public void PlayMusic(AudioClip ac = null)
    {
	    if (!ac)
		    ac = defaultMusic;

		musicSource.clip = ac;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

}
