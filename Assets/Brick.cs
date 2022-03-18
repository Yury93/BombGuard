using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private float timeAudio;
    void Start()
    {
        StartCoroutine(CorBrickAudio());
        IEnumerator CorBrickAudio()
        {
            yield return new WaitForSeconds(timeAudio);
            AudioManager.Instance.PlayAudio("Brick");
            yield return new WaitForSeconds(1.5f);
            AudioManager.Instance.StopAudio("Brick");
           
        }
    }

    
}
