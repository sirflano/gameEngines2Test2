using UnityEngine;
using System.Collections;

public abstract class SteeringBehaviour : MonoBehaviour {

    public abstract Vector3 calculate();

    public abstract bool isActive();

    public abstract void setActive(bool _active);
}
