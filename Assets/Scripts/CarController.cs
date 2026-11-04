
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

    void Update()
    {
        if (GameManager.GameOver)
            return;
        Controls();
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            ResetToZero();
        }

        transform.eulerAngles = new Vector3(0, RawRotation * RotationScaleFactor, 0);
    }

    public void Controls()
    {
        float turnMultiplier = 1f;
        if (GameManager.instance != null)
        {
            turnMultiplier = GameManager.instance.turnSpeedMultiplier;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (RawRotation <= 0)
            {
                RawRotation -= Time.deltaTime * turnMultiplier / Mathf.Abs(RawRotation - 1f);
            }
            else
            {
                RawRotation -= Time.deltaTime * NaturalReturnFactor * 3f * turnMultiplier;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (RawRotation >= 0)
            {
                RawRotation += Time.deltaTime * turnMultiplier / Mathf.Abs(RawRotation + 1f);
            }
            else
            {
                RawRotation += Time.deltaTime * NaturalReturnFactor * 3f * turnMultiplier;
            }
        }

        // Limit maximum rotation
        RawRotation = Mathf.Clamp(RawRotation, -RotationLimits, RotationLimits);

        float currentTurnSpeed = VehicleTurnSpeed * turnMultiplier;
        float movement = RawRotation * currentTurnSpeed;

        // Keep car inside road boundaries
        float newX = Mathf.Clamp(transform.position.x + movement,-RoadWidth,RoadWidth);
        transform.position = new Vector3(newX,transform.position.y,transform.position.z);
    }
    public void ResetToZero()
    {
        if (RawRotation > 0)
        {
            RawRotation = Mathf.MoveTowards(RawRotation, 0, Time.deltaTime * NaturalReturnFactor);
        }
        else if (RawRotation < 0)
        {
            RawRotation = Mathf.MoveTowards(RawRotation,0,Time.deltaTime * NaturalReturnFactor);
        }
    }
}
