using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Replick : SingletonBase<Replick>
{
    [SerializeField] private TextMeshProUGUI replickText;

    [TextArea(4, 8),Header("Random replick")]
    [SerializeField] private  List <string> randomReplick;

    [TextArea(4, 8), Header("Event replick")]
    [SerializeField] private List<string> eventReplick;
    private bool dialogEvent;

    private void Start()
    {
        RandomReplickShow();
    }
    public void RandomReplickShow()
    {
        if (dialogEvent == false)
        {
            StartCoroutine(CorReplickRandom());
            IEnumerator CorReplickRandom()
            {
                yield return new WaitForSeconds(1f);
                replickText.text = randomReplick[Random.Range(0, randomReplick.Count)];
                yield return new WaitForSeconds(7f);
                replickText.text = "";
                yield return new WaitForSeconds(10f);
                RandomReplickShow();
            }
        }
    }

    public void EventReplickShow(int numberReplick)
    {
        dialogEvent = true;
        StartCoroutine(CorReplickRandom());
        IEnumerator CorReplickRandom()
        {
            yield return new WaitForSeconds(0f);
            replickText.text = eventReplick[numberReplick];
            yield return new WaitForSeconds(14f);
            replickText.text = "";
        }
    }
}
