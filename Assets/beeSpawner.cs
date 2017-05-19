using UnityEngine;
using System.Collections;

public class beeSpawner : MonoBehaviour {
    public int maxBees = 10;
    public float beeCost = 5;
    public float beeSpawnCooldown = 2;
    public GameObject bee;

    private float pollen = 10;
    private float beeCooldown = 0;
    private int curBees = 0;

	// Use this for initialization
	IEnumerator Start () {
        yield return StartCoroutine("spawnBees");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator spawnBees()
    {
        while (true)
        {
            if(beeCooldown <= 0 && pollen >= beeCost && curBees < maxBees)
            {
                Quaternion startRot = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
                GameObject curBee = Instantiate(bee, transform.position, startRot) as GameObject;
                curBee.GetComponent<beeController>().hive = this.gameObject;
                curBee.transform.parent = transform;
                curBees += 1;
                pollen -= beeCost;
                beeCooldown = beeSpawnCooldown;
                yield return 0;
            }
            else
            {
                beeCooldown -= Time.deltaTime;
                yield return 0;
            }

        }
    }

    public void storePollen(float _pollen)
    {
        pollen += _pollen;
    }
}
