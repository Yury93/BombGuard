using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRend;
    [SerializeField] private bool bomb;
    public bool Bomb => bomb;
    /// <summary>
    /// Количество бомб рядом
    /// </summary>
    [SerializeField] private int countBomb;
    public int CountBomb => countBomb;
    [SerializeField] private TextMeshProUGUI textGradus;
    private void Start()
    {
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        textGradus = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        textGradus.gameObject.SetActive(false);
    }
    public void SetModeBomb(bool bomba)
    {
        bomb = true;
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var cell = collision.gameObject.GetComponent<Cell>();

        if (bomb && cell.bomb == false)
        {
           
            if (collision.gameObject != gameObject)
            {
                collision.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
                StartCoroutine(CorText());
                IEnumerator CorText()
                {
                    yield return new WaitForSeconds(0.1f);
                    OnText(cell);
                }
            }
        }
        if (cell.bomb && !bomb)
        {
            countBomb += 1;
            return;
        }
    }
    public void SetSprite(Sprite sprite)
    {
        spriteRend.sprite = sprite;
    }
    public void OnText(Cell c)
    {
       c.textGradus.gameObject.SetActive(true);
       c.textGradus.text = c.countBomb.ToString() + "°";
    }
}