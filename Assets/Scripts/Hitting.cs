using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public float restAngle = 0f;
    public float pressedAngle = 45f;
    public float flipperStrength = 10000f;
    public float flipperDamper = 150f;

    private HingeJoint2D hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        hinge.useMotor = true;

        JointAngleLimits2D limits = hinge.limits;
        limits.min = Mathf.Min(restAngle, pressedAngle);
        limits.max = Mathf.Max(restAngle, pressedAngle);
        hinge.limits = limits;
        hinge.useLimits = true;
    }

    void Update()
    {
        JointMotor2D motor = hinge.motor;

        if (Input.GetMouseButtonDown(0))
        {
            motor.motorSpeed = (restAngle < pressedAngle) ? flipperStrength : -flipperStrength;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            motor.motorSpeed = (restAngle < pressedAngle) ? -flipperStrength : flipperStrength;
        }

        motor.maxMotorTorque = flipperDamper;
        hinge.motor = motor;
    }
}
