using UnityEngine;

public class TestCrash : MonoBehaviour
{
    public GameObject environment;

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.GameOver)
            return;

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("CRASH avec " + other.gameObject.name);

            GameManager.EndGame();

            GetComponent<CarController>().enabled = false;
        }
    }
}
