﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BaseAI : AIPath
{

    public Animation anim;

    /** Minimum velocity for moving */
    public float sleepVelocity = 0.4F;

    /** Speed relative to velocity with which to play animations */
    public float animationSpeed = 0.2F;

    /** Effect which will be instantiated when end of path is reached.
     * \see OnTargetReached */
    public GameObject endOfPathEffect;

    public new void Start()
    {
        base.Start();
    }

    /** Point for the last spawn of #endOfPathEffect */
    protected Vector3 lastTarget;

    /**
     * Called when the end of path has been reached.
     * An effect (#endOfPathEffect) is spawned when this function is called
     * However, since paths are recalculated quite often, we only spawn the effect
     * when the current position is some distance away from the previous spawn-point
     */
    public override void OnTargetReached()
    {
        if (endOfPathEffect != null && Vector3.Distance(tr.position, lastTarget) > 1)
        {
            GameObject.Instantiate(endOfPathEffect, tr.position, tr.rotation);
            lastTarget = tr.position;
        }
    }

    protected override void Update()
    {
        base.Update();

        // Calculate the velocity relative to this transform's orientation
        Vector3 relVelocity = tr.InverseTransformDirection(velocity);
        relVelocity.y = 0;

        if (relVelocity.sqrMagnitude <= sleepVelocity * sleepVelocity)
        {
            // Fade out walking animation
         //   anim.Blend("forward", 0, 0.2F);
        }
        else
        {
            // Fade in walking animation
         //   anim.Blend("forward", 1, 0.2F);

            // Modify animation speed to match velocity
          //  AnimationState state = anim["forward"];

        //    float speed = relVelocity.z;
     //       state.speed = speed;
        }
    }
}
