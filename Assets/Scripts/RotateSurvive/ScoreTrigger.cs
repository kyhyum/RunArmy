using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] private int pointsToAdd = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ROScoreManager.Instance.IncreaseScore(pointsToAdd);
        }
    }
}
