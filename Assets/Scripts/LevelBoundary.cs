using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    [SerializeField] private float timeFail;
    private void OnCollisionStay2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Movement>();
        if (player)
        {
            player.GetComponent<Movement>().enabled = false;
            player.GetComponentInChildren<Animator>().SetBool("Fail", true);
            AudioManager.Instance.PlayAudio("Fail");
            AudioManager.Instance.StopAudio("Human");
            StartCoroutine(CorFail());
            IEnumerator CorFail()
            {
                yield return new WaitForSeconds(0.7f);
                player.gameObject.transform.DOMoveX(-23F, 0F);
                Replick.Instance.EventReplickShow(1);
                yield return new WaitForSeconds(timeFail);
                player.GetComponentInChildren<Animator>().SetBool("Walk", false);
                player.GetComponentInChildren<Animator>().SetBool("Fail", false);
                player.GetComponentInChildren<Animator>().SetBool("Idle", true);
                yield return new WaitForSeconds(3f);
                player.GetComponent<Movement>().enabled = true;
            }
            print("Player");
            return;
        }
    }
}
