using UnityEngine;

public class OnTriggerDestroy : MonoBehaviour
{
    // Utiliser pour détruire un objet quand vous arriver à un endroit
    //mettre se script sur un objet qui a un collider avec Is Trigger coché

    public GameObject ObjetADetruire;
    public string TagDeObjetADetruire;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagDeObjetADetruire)
        {
            Destroy(ObjetADetruire);
        }
    }
}
