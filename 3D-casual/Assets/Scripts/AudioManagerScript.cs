using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;



    public enum Sound
    {
        mainTheme,
        swipe,
        ballHit,
        click,
        wooden,
        wooden2,
    }

    public static void PlaySound(Sound sound, Vector3 position, float volume)
    {
        GameObject soundGameObject = new GameObject("Sound");
        soundGameObject.transform.position = position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(sound);
       
        audioSource.maxDistance = 55f;
        audioSource.spatialBlend = 1f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.dopplerLevel = 2f;
        audioSource.volume = volume;
        audioSource.Play();
        Object.Destroy(soundGameObject, audioSource.clip.length);

    }

   

    public static void PlaySound(Sound sound)
    {
        if (oneShotGameObject == null)
        {
            oneShotGameObject = new GameObject("One Shot Sound");
            oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            

        }
        oneShotAudioSource.PlayOneShot(GetAudioClip(sound), 1f);
    }


    //music
    public static AudioSource PlaySoundInLoop(Sound sound)
    {
        GameObject loopGameObject = new GameObject("LoopedSound");
        AudioSource loopAudioSource = loopGameObject.AddComponent<AudioSource>();
        loopGameObject = new GameObject("One Shot Sound");
        loopAudioSource = loopGameObject.AddComponent<AudioSource>();
        loopAudioSource.loop = true;
        loopAudioSource.clip = GetAudioClip(sound);

        
        loopAudioSource.Play();

        return loopAudioSource;
    }

    public static AudioSource PlaySoundInBackground(Sound sound)
    {
        GameObject loopGameObject = new GameObject("LoopedSound"); ;
        AudioSource loopAudioSource = loopGameObject.AddComponent<AudioSource>();
        loopGameObject = new GameObject("One Shot Sound");
        loopAudioSource = loopGameObject.AddComponent<AudioSource>();
        loopAudioSource.loop = true;
        loopAudioSource.volume = 0.05f;
        loopAudioSource.clip = GetAudioClip(sound);
        loopAudioSource.Play();

        return loopAudioSource;
    }

    public static void PlayWalkSound(Sound sound, Vector3 position)
    {
        GameObject soundGameObject = new GameObject("Sound");
        soundGameObject.transform.position = position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(sound);
        audioSource.maxDistance = 10f;
        audioSource.spatialBlend = 1f;
        audioSource.volume = 0.3f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.dopplerLevel = 0f;

       

        audioSource.Play();
        Object.Destroy(soundGameObject, audioSource.clip.length);

    }

    public static void PlayEnemyWalkSound(Sound sound, Vector3 position)
    {
        GameObject soundGameObject = new GameObject("Sound");
        soundGameObject.transform.position = position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(sound);
        audioSource.maxDistance = 30f;
        audioSource.spatialBlend = 1f;
        audioSource.volume = 0.15f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.dopplerLevel = 0f;

       
        audioSource.Play();
        Object.Destroy(soundGameObject, audioSource.clip.length);

    }

    public static AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }

        return null;
    }


}

