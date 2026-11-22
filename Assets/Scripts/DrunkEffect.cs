using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DrunkEffect : MonoBehaviour
{
    public Volume volume;
    private DepthOfField depthOfField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volume.profile.TryGet(out depthOfField);
    }

    // Update is called once per frame
    void Update()
    {
        float blur =
             Mathf.Clamp(GameManager.instance.score * 0.3f, 0f, 1f);

        depthOfField.gaussianMaxRadius.value = blur;
        
    }
}
