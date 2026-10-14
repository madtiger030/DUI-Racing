using UnityEngine;

public class CarController : MonoBehaviour
{
    public float RawRotation;
    public float Rotation;
    public float RotationLimits;
    public float RotationScaleFactor;
    public float NaturalReturnFactor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player inputs
        if (Input.GetKey(KeyCode.A))
        {
            if (RawRotation - Time.deltaTime <= -RotationLimits)
            {
                RawRotation = -RotationLimits;
            }
            else
            {
                RawRotation -= Time.deltaTime / Mathf.Abs(RawRotation - 0.1f);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (RawRotation + Time.deltaTime >= RotationLimits)
            {
                RawRotation = RotationLimits;
            }
            else
            {
                RawRotation += Time.deltaTime / Mathf.Abs(RawRotation + 0.1f);
            }
        }
        //Naturally return to 0
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (RawRotation > 0)
            {
                if (RawRotation < Time.deltaTime)
                {
                    RawRotation = 0;
                }
                else
                {
                    RawRotation -= Time.deltaTime * NaturalReturnFactor;
                }
            }
            else if (RawRotation < 0)
            {
                if (Mathf.Abs(RawRotation) < Time.deltaTime)
                {
                    RawRotation = 0;
                }
                else
                {
                    RawRotation += Time.deltaTime * NaturalReturnFactor;
                }
            }
        }

        /*if (RawRotation > 0)
        { Rotation = Mathf.Pow(RawRotation, 0.5f); }
        else if (RawRotation < 0)
        { Rotation = -Mathf.Pow(-RawRotation, 0.5f); }
        else if (RawRotation == 0)
        { Rotation = 0; }*/
        Rotation = RawRotation;

        transform.eulerAngles = new Vector3(0, Rotation * RotationScaleFactor, 0);
    }
}
