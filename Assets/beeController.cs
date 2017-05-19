using UnityEngine;
using System.Collections;

public class beeController : MonoBehaviour {
    public GameObject hive;
    public float curPolen = 0;
    public Vector3 target;

    private bool hasPolen = false;
    private bool polenating = false;
    private GameObject flower;

    private wander wanderBehaviour;
    private findFlower arriveBehaviour;

	// Use this for initialization
	IEnumerator Start () {
        wanderBehaviour = GetComponent<wander>();
        arriveBehaviour = GetComponent<findFlower>();

        yield return StartCoroutine("think");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator think()
    {
        float curDown = 0;
        while (true)
        {
            if(curDown <= 0)
            {
                if(!polenating && !hasPolen)
                {
                    float distance = 20;
                    GameObject[] flowers = GameObject.FindGameObjectsWithTag("flower");
                    GameObject target = new GameObject();
                    foreach(GameObject _flower in flowers)
                    {
                        if (Vector3.Distance(transform.position, _flower.transform.position) < distance)
                        {
                            distance = Vector3.Distance(transform.position, _flower.transform.position);
                            flower = _flower;
                        }
                    }

                    if(distance >= 20)
                    {
                        arriveBehaviour.setActive(false);
                        wanderBehaviour.setActive(true);
                    }
                    else if(distance < 1)
                    {
                        polenating = true;
                        StartCoroutine("polenate");
                    }
                    else
                    {
                        wanderBehaviour.setActive(false);
                        Debug.Log(flower.transform.position);
                        arriveBehaviour.setTarget(flower.transform.position);
                        arriveBehaviour.setActive(true);
                    }
                }
                else if (hasPolen)
                {
                    wanderBehaviour.setActive(false);
                    Debug.Log(hive.transform.position);
                    arriveBehaviour.setTarget(hive.transform.position);
                    arriveBehaviour.setActive(true);

                    if (Vector3.Distance(transform.position, hive.transform.position) < 1)
                    {
                        hive.GetComponent<beeSpawner>().storePollen(curPolen);
                        curPolen = 0;
                        hasPolen = false;
                    }
                }
                curDown = 0.2f;
                yield return 0;
            }
            else
            {
                curDown -= Time.deltaTime;
                yield return 0;
            }
        }
    }

    IEnumerator polenate()
    {
        float curDown = 0;
        while(flower.GetComponent<Flower>().polen > 0)
        {
            if(curDown <= 0)
            {
                curPolen += flower.GetComponent<Flower>().collectPollen();
                curDown = 1;
            }
            else
            {
                curDown -= Time.deltaTime;
            }
        }
        hasPolen = true;
        polenating = false;
        flower.GetComponent<Flower>().destroyFlower();
        yield return 0;
    }
}
