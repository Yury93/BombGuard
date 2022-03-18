using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEffect : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject pos;
    public void InstatiateEffect()
    {
       var e = Instantiate(effect, pos.transform.position, Quaternion.identity);
        AudioManager.Instance.PlayAudio("Instrument");
        Destroy(e.gameObject, 4f);
    }
    public void PlayMusicWalk()
    {
        AudioManager.Instance.PlayAudio("Human");
    }
    public void StopMusicWalk()
    {
        AudioManager.Instance.StopAudio("Human");
    }
    public void PlayMusicInstrument()
    {
        //AudioManager.Instance.PlayAudio("Instrument");
    }
}
