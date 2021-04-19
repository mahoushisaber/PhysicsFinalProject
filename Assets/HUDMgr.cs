using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDMgr : MonoBehaviour
{
    public Text BodyMassText;
    public Slider BodyMassSlider;

    public Text BodyRadiusText;
    public Slider BodyRadiusSlider;

    public Text ArmMassText;
    public Slider ArmMassSlider;

    public Text AngleMomentumText;
    public Slider AngularMomentumSlider;

    public Text AngleVelocityText;

    public Text ArmRadiusText;
    public Slider ArmRadiusSlider;

    public Text InertiaText;

    public PhysicsEngine physicsEngineScript;

    private float oldBMass;
    private float oldBRadius;
    private float oldArmMass;
    private float oldAglMomentum;
    private float oldArmRadius;

    // Start is called before the first frame update
    void Start()
    {
        BodyMassText.text = string.Format("Body Mass: {0}", physicsEngineScript.MMass);
        BodyRadiusText.text = string.Format("Body Radius: {0}", physicsEngineScript.BodyRadius);
        ArmMassText.text = string.Format("Arm Mass: {0}", physicsEngineScript.RodMass);
        AngleMomentumText.text = string.Format("Angular Momentum: {0}", physicsEngineScript.LAngularMomentum);
        AngleVelocityText.text = string.Format("Angular Velocity: {0}", physicsEngineScript.wOmega);
        ArmRadiusText.text = string.Format("Arm Radius: {0}", physicsEngineScript.RRadius);
        InertiaText.text = string.Format("Inertia: {0}", physicsEngineScript.IInertia);

        BodyMassSlider.value = physicsEngineScript.MMass;
        BodyRadiusSlider.value = physicsEngineScript.BodyRadius;
        ArmMassSlider.value = physicsEngineScript.RodMass;
        AngularMomentumSlider.value = physicsEngineScript.LAngularMomentum;
        ArmRadiusSlider.value = physicsEngineScript.RRadius;

        oldBMass = 0.0f;
        oldBRadius = 0.0f;
        oldArmMass = 0.0f;
        oldAglMomentum = 0.0f;
        oldArmRadius = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Need to update all the non adjustable text fields with physics values        
        AngleVelocityText.text = string.Format("Angular Velocity: {0}", physicsEngineScript.wOmega);
        InertiaText.text = string.Format("Inertia: {0}", physicsEngineScript.IInertia);

        // Need to see if a slider changed and if not then update with any changed value from physics
        //
        if (oldBMass != BodyMassSlider.value)
        {
            oldBMass = BodyMassSlider.value;
            physicsEngineScript.MMass = BodyMassSlider.value;
        }
        else if (oldArmMass != physicsEngineScript.MMass)
        {
            oldArmMass = physicsEngineScript.MMass;
            BodyMassSlider.value = physicsEngineScript.MMass;
        }
        BodyMassText.text = string.Format("Body Mass: {0}", physicsEngineScript.MMass);

        if (oldBRadius != BodyRadiusSlider.value)
        {
            oldBRadius = BodyRadiusSlider.value;
            physicsEngineScript.BodyRadius = BodyRadiusSlider.value;
        }
        else if (oldBRadius != physicsEngineScript.BodyRadius)
        {
            oldBRadius = physicsEngineScript.BodyRadius;
            BodyRadiusSlider.value = physicsEngineScript.BodyRadius;
        }
        BodyRadiusText.text = string.Format("Body Radius: {0}", physicsEngineScript.BodyRadius);

        if (oldArmMass != ArmMassSlider.value)
        {
            oldArmMass = ArmMassSlider.value;
            physicsEngineScript.RodMass = ArmMassSlider.value;
        }
        else if (oldArmMass != physicsEngineScript.RodMass)
        {
            oldArmMass = physicsEngineScript.RodMass;
            ArmMassSlider.value = physicsEngineScript.RodMass;
        }
        ArmMassText.text = string.Format("Arm Mass: {0}", physicsEngineScript.RodMass);

        if (oldAglMomentum != AngularMomentumSlider.value)
        {
            oldAglMomentum = AngularMomentumSlider.value;
            physicsEngineScript.LAngularMomentum = AngularMomentumSlider.value;
        }
        else if (oldAglMomentum != physicsEngineScript.LAngularMomentum)
        {
            oldAglMomentum = physicsEngineScript.LAngularMomentum;
            AngularMomentumSlider.value = physicsEngineScript.LAngularMomentum;
        }
        AngleMomentumText.text = string.Format("Angular Momentum: {0}", physicsEngineScript.LAngularMomentum);

        if (oldArmRadius != ArmRadiusSlider.value)
        {
            oldArmRadius = ArmRadiusSlider.value;
            physicsEngineScript.RRadius = ArmRadiusSlider.value;
        }
        else if (oldArmRadius != physicsEngineScript.RRadius)
        {
            oldArmRadius = physicsEngineScript.RodMass;
            ArmRadiusSlider.value = physicsEngineScript.RRadius;
        }
        ArmRadiusText.text = string.Format("Arm Radius: {0}", physicsEngineScript.RRadius);
    }
}
