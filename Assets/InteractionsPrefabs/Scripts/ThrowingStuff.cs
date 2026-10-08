using UnityEngine;

public class ThrowingStuff : MonoBehaviour


 {
    public GameObject throwablePrefab;
    
    public float throwForce = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            ThrowObject();
        }
    }

    void ThrowObject()
    {
        GameObject thrownObject = Instantiate(throwablePrefab, gameObject.transform.position, gameObject.transform.rotation);
        Rigidbody rb = thrownObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(gameObject.transform.forward * throwForce, ForceMode.Impulse);
        }
    }
}

