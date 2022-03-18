using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    [SerializeField] private AudioSource music, human, instrument, fail, brickSpawn
        , bonus,temperature,bomb,brick;

    public void PlayAudio(string audioName)
    {
        if (audioName == "Brick")
        {
            brick.Play();
        }
        if (audioName == "Bomb")
        {
            bomb.Play();
        }
        if (audioName == "Temperature")
        {
            temperature.Play();
        }
        if (audioName == "Bonus")
        {
            bonus.Play();
        }
        if (audioName == "music")
        {
            music.Play();
        }
        if (audioName == "Human")
        {
            human.Play();
        }
        if (audioName == "Instrument")
        {
            instrument.Play();
        }
        if (audioName == "Fail")
        {
            fail.Play();
        }
        if (audioName == "brickSpawn")
        {
            brickSpawn.Play();
        }
    }
    public void StopAudio(string audioName)
    {

        if (audioName == "Brick")
        {
            brick.Stop();
        }
        if (audioName == "Bomb")
        {
            bomb.Stop();
        }
        if (audioName == "Temperature")
        {
            temperature.Stop();
        }
        if (audioName == "Bonus")
        {
            bonus.Stop();
        }
        if (audioName == "music")
        {
            music.Stop();
        }
        if (audioName == "Human")
        {
            human.Stop();
        }
        if (audioName == "instrument")
        {
            instrument.Stop();
        }
        if (audioName == "fail")
        {
            fail.Stop();
        }
        if (audioName == "brickSpawn")
        {
            brickSpawn.Stop();
        }
    }

}
