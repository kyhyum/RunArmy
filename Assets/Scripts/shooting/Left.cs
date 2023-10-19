using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public Cannon cannon;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cannon.MoveLeft();
        }
    }

}
