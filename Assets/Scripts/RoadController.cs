using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public bool SpawnedMoreRoad;
    public GameObject MoreRoad;
    public float RoadLength;
    public float RoadSpeed;
    public List<GameObject> ObjectList;
    public GameObject ObjectStorage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < RoadLength/10; i++)
        {
            Instantiate(ObjectList[Random.Range((int)0, (int)ObjectList.Count)], new Vector3(Random.Range((int)-1,(int)2) * 5, 1, transform.position.z + 10 * i), Quaternion.identity, ObjectStorage.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, RoadSpeed * Time.deltaTime);
        if (transform.position.z < 30 && SpawnedMoreRoad == false)
        {
            Instantiate(MoreRoad, new Vector3(0, 0, transform.position.z + RoadLength), transform.rotation);
            SpawnedMoreRoad = true;
        }
        if (transform.position.z < -960)
        {
            Destroy(this.gameObject);
        }
    }

}
