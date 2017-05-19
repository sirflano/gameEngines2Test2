using UnityEngine;
using System.Collections;
using System;

public class findFlower : SteeringBehaviour {
    private bool active = true;

    public Vector3 target;
    //public float slowingDistance = 10;


    private boid Boid;
    // Use this for initialization
    void Start()
    {
        Boid = GetComponent<boid>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void setTarget(Vector3 _target)
    {
        target = _target;
    }

    public override void setActive(bool _active)
    {
        active = _active;
    }

    public override bool isActive()
    {
        return active;
    }

    public override Vector3 calculate()
    {
        return Boid.arrive(target, 10);
    }
}
