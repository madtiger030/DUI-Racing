using UnityEngine;

public class CarHorn : MonoBehaviour
{
    public AudioClip hornSound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioSource.PlayOneShot(hornSound);
        }
    }
}