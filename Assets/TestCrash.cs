using UnityEngine;

public class TestCrash : MonoBehaviour
{
    public GameObject environment;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CRASH avec " + collision.gameObject.name);

        environment.GetComponent<RoadController>().gameover = true;

        GetComponent<CarController>().enabled = false;
    }

}
