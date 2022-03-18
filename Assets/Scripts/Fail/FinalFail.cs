using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFail : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    void Start()
    {
        StartCoroutine(CorEnd());
        IEnumerator CorEnd()
        {
            yield return new WaitForSeconds(9f);
            canvas.SetActive(true);
            yield return new WaitForSeconds(2f);
            SceneController.Instance.NextScene();
        }
    }
}
