using UnityEngine;
using System.Collections;
using System;

public class wander : SteeringBehaviour {
    public bool active = true;
    private boid Boid;
	// Use this for initialization
	void Start () {
        Boid = GetComponent<boid>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override Vector3 calculate()
    {
        Vector3 randomDirection = new Vector3(UnityEngine.Random.Range(0, 5), 0, UnityEngine.Random.Range(0, 5));
        randomDirection.Normalize();
        randomDirection *= 50;

        return Boid.seek(randomDirection + transform.position);
    }

    public override bool isActive()
    {
        return active;
    }

    public override void setActive(bool _active)
    {
        active = _active;
    }
}
