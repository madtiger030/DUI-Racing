using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerDestroy : MonoBehaviour
{
    public int scoreValue = 1;
    // Utiliser pour détruire un objet quand vous arriver à un endroit
    //mettre se script sur un objet qui a un collider avec Is Trigger coché

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager_sc.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
