using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerDestroy : MonoBehaviour
{
    public int scoreValue = 1;
    public bool pot;
    // Utiliser pour détruire un objet quand vous arriver à un endroit
    //mettre se script sur un objet qui a un collider avec Is Trigger coché
    private void OnTriggerEnter(Collider other)
    {
        pot = true;
        if (other.CompareTag("Player"))
        {
            ScoreManager_sc.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
