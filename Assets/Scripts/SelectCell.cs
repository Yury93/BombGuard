using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт вешается на камеру и работает с CellGenerator
/// </summary>
[RequireComponent(typeof(ContainerSprites))]
public class SelectCell : MonoBehaviour
{
    [Header("Effect open cell")]
    [SerializeField] private GameObject effectBonus, effectTemperature,effectBomb;
    [Header("Mechanic")]
    [SerializeField] private ContainerSprites containerSprites;
    private int countClickDestroy;
    [SerializeField] private CellGenerator cellGenerator;
    public event Action OnGameEnd;
    private void Start()
    {
        cellGenerator = FindObjectOfType<CellGenerator>();
        containerSprites = GetComponent<ContainerSprites>();
        enabled = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider  &&  hit.collider.TryGetComponent<Cell>(out var cell))
            {
                if(cell.CountBomb > 0)
                {
                    StartCoroutine(CorTemperature());
                    CreateEffectOpenCell(effectTemperature, hit.collider.transform.position);
                    AudioManager.Instance.PlayAudio("Instrument");
                    IEnumerator CorTemperature()
                    {
                        yield return new WaitForSeconds(0f);
                        cell.SetSprite(containerSprites.TemperatureSprite());
                        yield return new WaitForSeconds(0.3f);
                        AudioManager.Instance.PlayAudio("Temperature");
                    }
                }
                if(cell.Bomb)
                {
                    cell.SetSprite(containerSprites.BombSprite());
                    print("Бомба");
                    StartCoroutine(CorBomb());
                    IEnumerator CorBomb()
                    {
                        yield return new WaitForSeconds(0f);
                        CreateEffectOpenCell(effectBomb, hit.collider.transform.position);
                        Destroy(cell.gameObject,1);
                        AudioManager.Instance.PlayAudio("Instrument");
                        yield return new WaitForSeconds(0.5f);
                        AudioManager.Instance.PlayAudio("Bomb");
                        yield return new WaitForSeconds(3.5f);
                        SceneController.Instance.FailScene();
                    }
                }
                if (!cell.Bomb && cell.CountBomb == 0)
                {
                    if (!cellGenerator)
                    {
                        cellGenerator = FindObjectOfType<CellGenerator>();
                    }
                    countClickDestroy += 1;
                    CreateEffectOpenCell(effectBonus, hit.collider.transform.position);
                    AudioManager.Instance.PlayAudio("Instrument");

                    Score.Instance.UpdateCurrentOre(1);
                    Destroy(hit.collider.gameObject);

                    StartCoroutine(CorBonus());
                    IEnumerator CorBonus()
                    {
                        yield return new WaitForSeconds(0.2f);
                        AudioManager.Instance.PlayAudio("Bonus");
                    }

                        if (countClickDestroy == cellGenerator.CountBonusCell)
                    {
                        countClickDestroy = 0;
                        Destroy(cellGenerator.gameObject);
                        enabled = false;
                        OnGameEnd?.Invoke();
                    }
                }
            }
        }
    }
    public void CreateEffectOpenCell(GameObject effect,Vector3 pos)
    {
        GameObject effectGo = Instantiate(effect, pos, Quaternion.identity);
        Destroy(effectGo, 5f);
    }
}
