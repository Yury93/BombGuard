using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    [SerializeField] private GameObject go;
    private void Start()
    {
        StartCoroutine(CorDestroy());
        IEnumerator CorDestroy()
        {
            yield return new WaitForSeconds(1f);
            go.SetActive(true);
            yield return new WaitForSeconds(1f);
            go.SetActive(false);
            yield return new WaitForSeconds(1f);
            go.SetActive(true);
            yield return new WaitForSeconds(1f);
            go.SetActive(false);
            yield return new WaitForSeconds(1f);
            go.SetActive(true);
            yield return new WaitForSeconds(1f);
            go.SetActive(false);
            yield return new WaitForSeconds(1f);
            go.SetActive(true);
            yield return new WaitForSeconds(1f);
            go.SetActive(false);
            yield return new WaitForSeconds(1f);
            go.SetActive(true);
            yield return new WaitForSeconds(1f);
            go.SetActive(false);
            yield return new WaitForSeconds(1f);
            go.SetActive(true);
            yield return new WaitForSeconds(1f);
            go.SetActive(false);
            yield return new WaitForSeconds(1f);
            go.SetActive(true);
            yield return new WaitForSeconds(5f);
            Destroy(go);
        }
    }
}
