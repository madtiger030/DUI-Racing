using UnityEngine;

public class CarController : MonoBehaviour
{
    public float RawRotation;
    public float Rotation;
    public float RotationLimits;
    public float RotationScaleFactor;
    public float NaturalReturnFactor;
    public float RoadWidth;
    public float VehicleTurnSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Controls the car
        Controls();
        //Naturally return to 0
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            ResetToZero();
        }


        transform.eulerAngles = new Vector3(0, RawRotation * RotationScaleFactor, 0);
    }

    public void Controls()
    {
        //Player inputs and rotation
        if (Input.GetKey(KeyCode.A))
        {
            if (RawRotation - Time.deltaTime <= -RotationLimits)
            {
                RawRotation = -RotationLimits;
            }
            else if (RawRotation <= 0)
            {
                RawRotation -= Time.deltaTime / Mathf.Abs(RawRotation - 1f);
            }
            else if (RawRotation > 0)
            {
                RawRotation -= Time.deltaTime * NaturalReturnFactor * 3f;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (RawRotation + Time.deltaTime >= RotationLimits)
            {
                RawRotation = RotationLimits;
            }
            else if (RawRotation >= 0)
            {
                RawRotation += Time.deltaTime / Mathf.Abs(RawRotation + 1f);
            }
            else if (RawRotation < 0)
            {
                RawRotation += Time.deltaTime * NaturalReturnFactor * 3f;
            }
        }

        if (RawRotation > 0 && transform.position.x + RawRotation > RoadWidth)
        { transform.position = new Vector3(RoadWidth, 1, 0); }
        else if (RawRotation < 0 && transform.position.x + RawRotation < -RoadWidth)
        { transform.position = new Vector3(-RoadWidth, 1, 0);}
        else
        { transform.position += new Vector3(RawRotation * VehicleTurnSpeed, 0, 0); }
    }
    public void ResetToZero()
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
}
