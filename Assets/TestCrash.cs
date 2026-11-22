using UnityEngine;

public class TestCrash : MonoBehaviour
{
    public GameObject environment;
    public AudioClip crashSound;
    private AudioSource audioSource;
    public AudioClip screamSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Obstacle"))
            return;

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("CRASH");
            audioSource.PlayOneShot(crashSound);
            audioSource.PlayOneShot(screamSound);

            CarController car = GetComponent<CarController>();

            car.RawRotation = 0f;
            car.enabled = false;

            GameManager.EndGame();
        }
    }
    
}
