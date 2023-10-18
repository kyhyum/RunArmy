using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float time;
    GameObject target;

    public bool live=false;
    //public float offTime;
    // Start is called before the first frame update
    private void Start()
    {
        live = false;
    }
    private void OnEnable()
    {
        live = true;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
       // if (collision.gameObject.tag == "Bomb") 
       // {
            live = false;
            ShootingGameManager.Instance.ScorePlusUpdate();
            this.gameObject.SetActive(false);
       // }

    }
}
