using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public bool SpawnedMoreRoad;
    public GameObject MoreRoad;
    public GameObject MoreRoadInstance;

    public float RoadLength;
    public float RoadSpeed;
    public int ObstacleLengthSpacing;
    public int ObstacleWidthSpacing;
    public List<GameObject> ObjectList;
    public GameObject ObjectStorage;
    public static float TotalDistance = 0;
    public float TotalDistanceDisplayValue = 0;
    public bool gameover;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < RoadLength / ObstacleLengthSpacing; i++)
        {
            Instantiate(ObjectList[Random.Range((int)0, (int)ObjectList.Count)],
                    new Vector3(Random.Range((int)-1, (int)2) * ObstacleWidthSpacing, 0, transform.position.z + ObstacleLengthSpacing * (i + 1)),
                    Quaternion.identity, ObjectStorage.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
            return;

        transform.position -= new Vector3(0, 0, RoadSpeed * Time.deltaTime * (TotalDistance/100 + 1));
        TotalDistance += RoadSpeed * Time.deltaTime;
        TotalDistanceDisplayValue = TotalDistance;

        if (transform.position.z < 30 && SpawnedMoreRoad == false)
        {
            MoreRoadInstance = Instantiate(MoreRoad, new Vector3(0, 0, transform.position.z + RoadLength), transform.rotation);
            MoreRoadInstance.GetComponent<RoadController>().MoreRoad = MoreRoad;
            SpawnedMoreRoad = true;
        }
        if (transform.position.z < -RoadLength)
        {
            Destroy(this.gameObject);
        }
    }

}
