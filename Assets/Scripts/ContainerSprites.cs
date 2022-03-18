using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerSprites : MonoBehaviour
{
    [SerializeField] private Sprite temperature, bomb;

    public Sprite TemperatureSprite()
    {
        return temperature;
    }
    public Sprite BombSprite()
    {
        return bomb;
    }
}
