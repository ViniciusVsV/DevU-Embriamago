using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour{
    [SerializeField] AudioSource musicEffect;
    [SerializeField] AudioSource soundEffect1;
    [SerializeField] AudioSource soundEffect2;
    
    public AudioClip musicMenu;
    public AudioClip musicNormal;
    public AudioClip musicFast;
    public AudioClip musicInsane;
    public AudioClip musicImpossible;
    public AudioClip attackSound;
    public AudioClip hitSound;
    public AudioClip enemyDeathSound;

    void Start(){
        musicEffect.clip = musicNormal;
        musicEffect.loop = true;
        musicEffect.Play();
    }

    public void setMusicFast(){
        musicEffect.clip = musicFast;
        musicEffect.loop = true;
        musicEffect.Play();
    }

    public void setMusicInsane(){
        musicEffect.clip = musicInsane;
        musicEffect.loop = true;
        musicEffect.Play();
    }

    public void setMusicImpossible(){
        musicEffect.clip = musicImpossible;
        musicEffect.loop = true;
        musicEffect.Play();
    }

    public IEnumerator stopMusic(){
        float startVolume = musicEffect.volume;

        while (musicEffect.volume > 0){
            musicEffect.volume -= startVolume * Time.deltaTime / 0.8f;
            yield return null;
        }

        musicEffect.Stop();
        musicEffect.volume = startVolume;
    }

    public void playAttackSound(){
        soundEffect1.clip = attackSound;
        soundEffect1.Play();
    }

    public void playHitSound(){
        soundEffect2.clip = hitSound;
        soundEffect2.Play();
    }

    public void playEnemyDeathSound(){
        soundEffect2.clip = enemyDeathSound;
        soundEffect2.Play();
    }
}
