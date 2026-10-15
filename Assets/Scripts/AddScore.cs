using TMPro;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField]
    GameObject score;

    [SerializeField]
    TextMeshProUGUI tmpg;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            tmpg.GetComponent<TMP_Text>().text = "Hello" ;
        }
    }
}
