using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Delete : MonoBehaviour
{
    //Mettre sur la caméra
    public string TagDeLObjetADetruire;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition) ;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.tag == TagDeLObjetADetruire)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
            
        }
        
    }
}
