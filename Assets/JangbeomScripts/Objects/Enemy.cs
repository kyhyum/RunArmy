
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody otherRb = other.GetComponent<Rigidbody>();
            if (otherRb != null)
            {
               
                otherRb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
            }
            if(PacmanGameManager.Instance.score >= 400)
            {
                PacmanGameManager.Instance.Success();
            }
            else
            {
                PacmanGameManager.Instance.GameOver();
            }
            
        }
    }
}
