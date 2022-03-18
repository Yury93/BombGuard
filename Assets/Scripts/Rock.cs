using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Person pers;
    [SerializeField] private SceneController sceneController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        pers = collision.gameObject.GetComponent<Person>();
        if (pers)
        {
            pers.GetComponent<Movement>().enabled = false;
            Replick.Instance.EventReplickShow(0);
            pers.GetComponentInChildren<Animator>().SetBool("Kick", true);
            AudioManager.Instance.StopAudio("Human");
            StartCoroutine(CorNextLevel());
            IEnumerator CorNextLevel()
            {
                yield return new WaitForSeconds(12f);
                sceneController.NextScene();
            }
        }
        //if(pers)
        //{
        //    pers.GetComponent<Movement>().enabled = false;
        //    pers.GetComponentInChildren <Animator>().SetBool("Walk", false);
        //    sceneController.NextScene();
        //}
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        pers.GetComponent<Movement>().enabled = true;
        pers.GetComponentInChildren<Animator>().SetBool("Kick", false);
    }

}
    
