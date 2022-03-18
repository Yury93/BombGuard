using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : SingletonBase<Score>
{
    [SerializeField] private int levelCountOre;
    [SerializeField] private int currentOre;
    [SerializeField] private SpawnGeneratorCell spawnGeneratorCell;
    [SerializeField] private Text textScore;

    private void Start()
    {
        textScore.gameObject.SetActive(false);
    }
    public void LevelOre(int count)
    {
        if(count == 0)
        {
            levelCountOre = 0;
        }
        textScore.gameObject.SetActive(true);
        levelCountOre = count;
        textScore.text = levelCountOre + "/" + currentOre;
    }
    public void UpdateCurrentOre(int item)
    {
        if(item == 0)
        {
            currentOre = 0;
        }
        textScore.gameObject.SetActive(true);
        currentOre += item;
        textScore.text = levelCountOre + "/" + currentOre;
    }

}
