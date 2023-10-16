using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100f) * Time.deltaTime);//회전
    }
    private void OnTriggerEnter(Collider other) // 충돌 감지
    {
        if (other.gameObject.name == "Player")
        {
            GameObject.Find("PacmanGameManager").SendMessage("GetCoin");
            Destroy(gameObject);
        }
    }

}
