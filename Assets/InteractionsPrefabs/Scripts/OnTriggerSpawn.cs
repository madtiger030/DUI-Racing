using UnityEngine;

public class OnTriggerSpawn : MonoBehaviour
{
    public GameObject EndroitOuSpawner;
    public GameObject ObjetACreer;
    public string TagDeObjetACreer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagDeObjetACreer)
        {
           Instantiate(ObjetACreer, EndroitOuSpawner.transform.position, EndroitOuSpawner.transform.rotation);
        }
    }
}
