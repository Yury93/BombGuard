using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enivroment : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    void Update()
    {
        if (joystick.Direction.x > 0.1f)
        {
            transform.Translate(-speed*Time.deltaTime, 0, 0);
        }
        else if (joystick.Direction.x < -0.1f)
        {
                transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
                transform.Translate(0, 0, 0);
        }
    }
}
