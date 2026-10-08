using UnityEngine;

public class Raycast_Spawn : MonoBehaviour
{
    //Mettre sur la caméra
   // public string TagDeLObjetASpawn;
    
    public GameObject GameObjectASpawn;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition) ;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
           // if(hit.collider.gameObject.tag == TagDeLObjetASpawn)
            //{
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(GameObjectASpawn,hit.point, GameObjectASpawn.transform.rotation);
                }
            //}
            
        }
        
    }
}
