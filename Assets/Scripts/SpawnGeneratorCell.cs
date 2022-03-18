using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGeneratorCell : MonoBehaviour
{
    [SerializeField] private SelectCell selectCell;
    [SerializeField] private GameObject prefabGeneratorCell;
    [SerializeField] private Vector3 posCreateGeneratorCell;
    [SerializeField] private int countGame;
    private int countSpawnGame;
    public int CountGame => countGame;
    
    void Start()
    {
        selectCell.OnGameEnd += OnSpawnGeneratorCell;
    }

    private void OnSpawnGeneratorCell()
    {
        if (countSpawnGame != countGame - 1)
        {
            countSpawnGame += 1;
            Instantiate(prefabGeneratorCell, posCreateGeneratorCell, Quaternion.identity);
            Score.Instance.UpdateCurrentOre(0);
        }
        else if(countSpawnGame == countGame - 1)
        {
            SceneController.Instance.NextScene();
        }
    }
    public void CreateGeneratorCell()
    {
        Instantiate(prefabGeneratorCell, posCreateGeneratorCell, Quaternion.identity);
    }
}
