using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGenerator : MonoBehaviour
{
    [SerializeField] private SelectCell selectCell;
    [SerializeField] private GameObject prefabCell;
    [SerializeField] private float time;
    [SerializeField] private float offsetY, offsetX;
    [SerializeField] private int countX,countY;
    [SerializeField] private int countBomb;
    private int iteratorBomb; 
    /// <summary>
    /// Предыдущая позиция ячейки
    /// </summary>
    private Vector2 perviosPos;
    /// <summary>
    /// Список дочерних объектов генератора
    /// </summary>
    [SerializeField] private List<Cell> cells;

    [SerializeField] private int countBonusCell;
    public int CountBonusCell => countBonusCell;
    
    
    private void Start()
    {
        selectCell = Camera.main.GetComponent<SelectCell>();
        perviosPos = gameObject.transform.position;

        StartCoroutine(CorSpawnCell());

        IEnumerator CorSpawnCell()
        {
            yield return new WaitForSeconds(time);
            for (int i = 0; i <= countX - 1; i++)
            {
                for (int j = 0; j <= countY - 1; j++)
                {
                    yield return new WaitForSeconds(0.05f);
                    var cell = Instantiate(prefabCell, perviosPos, Quaternion.identity, gameObject.transform);

                    cell.transform.position = new Vector3(perviosPos.x, perviosPos.y + offsetY);
                    perviosPos.y = cell.transform.position.y;

                    cell.gameObject.GetComponent<Collider2D>().isTrigger = false;

                    if (j == countY - 1)
                    {
                        perviosPos.x += offsetX;
                        perviosPos.y = gameObject.transform.position.y;
                    }
                    cells.Add(cell.GetComponent<Cell>());
                }
            }
            yield return new WaitForSeconds(0.2f);
            foreach (var cell in cells)
            {
                iteratorBomb++;
                if (iteratorBomb < countBomb + 1)
                {
                    cells[Random.Range(0, cells.Count)].GetComponent<Cell>().SetModeBomb(true);
                }
            }
            yield return new WaitForSeconds(0.1f);
            foreach (var cell in cells)
            {
                cell.gameObject.GetComponent<Collider2D>().isTrigger = true;
            }
            yield return new WaitForSeconds(0.1f);
            foreach (var cell in cells)
            {
                cell.gameObject.GetComponent<BoxCollider2D>().size /= 2;
            }
            yield return new WaitForSeconds(0.1f);
            selectCell.enabled = true;

            foreach (var cell in cells)
            {
                if (!cell.Bomb && cell.CountBomb == 0)
                {
                    countBonusCell += 1;
                    Score.Instance.LevelOre(countBonusCell);
                }
            }
        }
    }
}
