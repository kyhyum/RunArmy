using UnityEngine;

public class RotateObjectB : MonoBehaviour
{

    public float rotationSpeed = 30.0f;

    private void Update()
    {
        // È¸Àü
        Vector3 rotation = Vector3.zero;
        rotation[1] = rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
        }
    }

}
