
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
    public bool gameover;
    void Start()
    {
        for (int i = 0; i < RoadLength / 10; i++)
        {
            Instantiate(
                ObjectList[Random.Range(0, ObjectList.Count)],
                new Vector3(Random.Range(-1, 2) * 5,1, transform.position.z + 10 * i),
                Quaternion.identity,
                ObjectStorage.transform
            );
        }
    }

    void Update()
    {
        if (gameover || GameManager.GameOver)
            return;
        // Get current game speed multiplier
        float speedMultiplier = 1f;
        if (GameManager.instance != null)
        {
            speedMultiplier = GameManager.instance.gameSpeed;
        }

        // Increase road speed as score increases
        float currentRoadSpeed = RoadSpeed * speedMultiplier;

        // Move road toward player
        transform.position -= new Vector3(0, 0, currentRoadSpeed * Time.deltaTime
        );

        // Spawn next road section
        if (transform.position.z < 30 && !SpawnedMoreRoad)
        {
            Instantiate(MoreRoad,new Vector3(0,0,transform.position.z + RoadLength),transform.rotation);

            SpawnedMoreRoad = true;
        }

        // Destroy old road section
        if (transform.position.z < -960)
        {
            Destroy(gameObject);
        }
    }
}
