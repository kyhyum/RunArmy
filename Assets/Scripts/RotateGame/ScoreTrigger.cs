using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] private int pointsToAdd = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RotateGameScoreManager scoreManager = FindObjectOfType<RotateGameScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(pointsToAdd);
            }
        }
    }
}
