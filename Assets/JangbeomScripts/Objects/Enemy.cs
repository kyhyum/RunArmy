using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody otherRb = collision.collider.GetComponent<Rigidbody>();
            if (otherRb != null)
            {
                otherRb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
            }
            if (PacmanGameManager.Instance != null) // Check if the instance is not null
            {
                PacmanGameManager.Instance.GameOver();
            }
        }
    }
}
