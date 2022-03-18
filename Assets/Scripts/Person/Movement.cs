using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject person;
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Animator animatorPers;
    [SerializeField] private GameObject objRotation;
    private void Update()
    {
        if(joystick.Direction.x > 0.1f)
        {
            objRotation. transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(speed * Time.deltaTime, 0, 0);
            animatorPers.SetBool("Walk", true);
            
        }
        else if (joystick.Direction.x < -0.1f)
        {
           objRotation. transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            animatorPers.SetBool("Walk", true);
          
        }
        else
        {
            transform.Translate(0, 0, 0);
            animatorPers.SetBool("Walk", false);

        }
    }
   
}
