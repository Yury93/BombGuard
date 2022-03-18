using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBrick : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    [SerializeField] private int count;
    [SerializeField] private float startSpawn;
    [SerializeField] private float timeCycle;

    void Start()
    {
        CreateBricks();
    }

    public void CreateBricks()
    {
        StartCoroutine(CorStartSpawn());
        IEnumerator CorStartSpawn()
        {
            yield return new WaitForSeconds(startSpawn);
            for (int i = 0; i < count; i++)
            {
                StartCoroutine(CorSpawn());
                IEnumerator CorSpawn()
                {
                    yield return new WaitForSeconds(timeCycle);
                    Instantiate(brick, gameObject.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
