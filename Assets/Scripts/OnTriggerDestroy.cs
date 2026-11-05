using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerDestroy : MonoBehaviour
{
    public int scoreValue = 1;
    public AudioClip pickupSound;
    public bool pot;
    private bool collected = false;
    // Utiliser pour détruire un objet quand vous arriver à un endroit
    //mettre se script sur un objet qui a un collider avec Is Trigger coché
    private void OnTriggerEnter(Collider other)
    {
        if (collected || GameManager.GameOver)
            return;

        if (other.CompareTag("Player"))
        {

            collected = true;
            GameManager.instance.AddScore(scoreValue);
            //drinking sound when picked up
            AudioSource.PlayClipAtPoint(
                pickupSound,
                Camera.main.transform.position
            );
            Destroy(gameObject);
        }
    }
}
