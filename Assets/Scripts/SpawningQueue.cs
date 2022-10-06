using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enum for the different enemy types
public enum UnitType { unit1, unit2, unit3 }
// struct to store the spawning location and the enemy itself
public struct Unit { public Enemy enemy; public Vector3 spawnVector; }
public class SpawningQueue : MonoBehaviour
{
    // for the spawning mechanic
    public Enemy unit1Prefab;
    public Enemy unit2Prefab;
    public Enemy unit3Prefab;
    public Transform unitSpawnPoint;

    // to force wait each spawn, so wont be any spawning at the same time
    bool spawnActive;

    // create a queue with Enemy type
    public Queue<Unit> spawningQueue;
    // Start is called before the first frame update
    void Start()
    {
        spawnActive = false;
        spawningQueue = new Queue<Unit>();

        //check for missing public parameters
        if (!unit1Prefab)
        {
            Debug.Log(name + ": Missing unit1Prefab");
        }

        if (!unit2Prefab)
        {
            Debug.Log(name + ": Missing unit2Prefab");
        }

        if (!unit3Prefab)
        {
            Debug.Log(name + ": Missing unit3Prefab");
        }

        if (!unitSpawnPoint)
        {
            Debug.Log(name + ": Missing unitSpawnPoint");
        }

    }

    // Update is called once per frame
    void Update()
    {
        // use keypad 1-2-3 to spawn the three enemy types
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            spawnUnit(UnitType.unit1);
            Debug.Log("Spawn Unit1!");
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            spawnUnit(UnitType.unit2);
            Debug.Log("Spawn Unit2!");
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            spawnUnit(UnitType.unit3);
            Debug.Log("Spawn Unit3!");
        }

        // if there anything in the spawningqueue, it will be spawned to the scene
        if (!spawnActive && spawningQueue != null && spawningQueue.Count > 0)
        {
            spawnActive = true;
            StartCoroutine(spawnUnitWithDelay(spawningQueue.Dequeue()));
        }
    }
    void spawnUnit(UnitType unit)
    {
        // differentiate the enemy types so the correct prefab will be spawned
        switch (unit)
        {
            case UnitType.unit1:
                // get the current location vector of the spawnpoint object and store it with the prefab to spawn later
                // so the prefab will spawn to this location and not the actual location of the spawnpoint
                Vector3 unit1Vec = new Vector3(unitSpawnPoint.position.x, unit1Prefab.yOffset, unitSpawnPoint.position.z);
                Unit queuable1 = new Unit() { enemy = unit1Prefab, spawnVector = unit1Vec };
                spawningQueue.Enqueue(queuable1);
                break;
            case UnitType.unit2:
                Vector3 unit2Vec = new Vector3(unitSpawnPoint.position.x, unit2Prefab.yOffset, unitSpawnPoint.position.z);
                Unit queuable2 = new Unit() { enemy = unit2Prefab, spawnVector = unit2Vec };
                spawningQueue.Enqueue(queuable2);
                break;
            case UnitType.unit3:
                Vector3 unit3Vec = new Vector3(unitSpawnPoint.position.x, unit2Prefab.yOffset, unitSpawnPoint.position.z);
                Unit queuable3 = new Unit() { enemy = unit3Prefab, spawnVector = unit3Vec };
                spawningQueue.Enqueue(queuable3);
                break;
            default:
                Debug.Log("this is the default, so it is bad!");
                break;
        }
    }

    // coroutine to spawn with a delay coming from the prefab; vector is needed so the spawned enemy is on the ground
    // and not inside it(and shoot up into the sky)
    IEnumerator spawnUnitWithDelay(Unit prefab)
    {
        yield return new WaitForSeconds(prefab.enemy.spawnTime);
        
        Rigidbody tempUnit = Instantiate(prefab.enemy.rb, prefab.spawnVector, unitSpawnPoint.rotation);
        spawnActive = false;

        StopCoroutine("spawnUnitWithDelay");
    }

}
