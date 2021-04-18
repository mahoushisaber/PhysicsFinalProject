using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    public float LAngularMomentum;
    public float MMass;
    [Range(0.4f, 0.9f)]
    public float RRadius = 0.85f;
    public float wOmega;

    [SerializeField]
    private float IInertia;

    private float oldMMass;
    private float oldLAngularMomentum;
    private float oldRadius;
    private float oldOmega;

    const float c_MinRadius = 0.4f;

    //Animations
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        RRadius = Mathf.Max(c_MinRadius, RRadius);

        oldLAngularMomentum = LAngularMomentum;
        oldMMass = MMass;
        oldRadius = RRadius;
        oldOmega = wOmega;

        CheckIf_L_NeedsUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        // if Mass is changing recalculate Omega
        if (oldMMass != MMass)
        {
            oldMMass = MMass;

            CheckIf_L_NeedsUpdate();

            //  Check for and prevent divide by zero
            if (MMass != 0.0f && RRadius != 0.0f)
            { 
                // L = mr^2w --> w = L/mr^2
                wOmega = LAngularMomentum / (MMass * Mathf.Pow(RRadius, 2.0f));
            }
            else // (MMass == 0.0f || RRadius == 0.0f)
            {
                wOmega = 0.0f;
            }
            oldOmega = wOmega;

            // Because radius change recalculate intertia
            // I = mr^2
            IInertia = MMass * Mathf.Pow(RRadius, 2.0f);
        }

        // If Radius is changing than calculate Omega
        if (oldRadius != RRadius)
        {
            //Check_AnimationUpdate();
            oldRadius = RRadius;

            CheckIf_L_NeedsUpdate();

            //  Check for and prevent divide by zero
            if (MMass != 0.0f && RRadius != 0.0f)
            {
                // L = mr^2w --> w = L/mr^2
                wOmega = LAngularMomentum / (MMass * Mathf.Pow(RRadius, 2.0f));
            }
            else // (MMass == 0.0f || RRadius == 0.0f)
            {
                wOmega = 0.0f;
            }
            oldOmega = wOmega;

            // Because radius change recalculate intertia
            // I = mr^2
            IInertia = MMass * Mathf.Pow(RRadius, 2.0f);
        }

        // If Omega is changing than calculate Radius
        if (oldOmega != wOmega)
        {
            oldOmega = wOmega;

            CheckIf_L_NeedsUpdate();

            //  Check for and prevent divide by zero
            if (MMass != 0.0f && wOmega != 0.0f)
            {
                //  L = mr^2w --> r = sqrt(L/mw)
                RRadius = Mathf.Sqrt(LAngularMomentum / (MMass * wOmega));
            }
            else // (MMass == 0.0f || wOmega == 0.0f)
            {
                RRadius = c_MinRadius;
            }
        }

        // If Angular Momentum is changing than calculate Omega
        if (oldLAngularMomentum != LAngularMomentum)
        {
            oldLAngularMomentum = LAngularMomentum;

            //  Check for and prevent divide by zero
            if (MMass != 0.0f && RRadius != 0.0f)
            {
                // L = mr^2w --> w = L/mr^2
                wOmega = LAngularMomentum / (MMass * Mathf.Pow(RRadius, 2.0f));
            }
            else // (MMass == 0.0f || RRadius == 0.0f)
            {
                wOmega = 0.0f;
            }

            oldOmega = wOmega;
        }
    }

    private void CheckIf_L_NeedsUpdate()
    {
        // If all the components Mass, Radius and Omega do not equal zero than we can
        //  calculate the Angular Momentum as both sides must have equality
        if (LAngularMomentum == 0.0f && MMass != 0.0f && RRadius != 0.0f && wOmega != 0.0f)
        {
            // L = mr^2w
            LAngularMomentum = MMass * Mathf.Pow(RRadius, 2.0f) * wOmega;
        }
    }


}
