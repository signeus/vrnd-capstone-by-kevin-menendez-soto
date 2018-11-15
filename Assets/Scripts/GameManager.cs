using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Timer
    [SerializeField]
    float timeLeftToStart = 10.0f;
    float timeEnemy;

    bool enemyAppears = false;


    // Properties for Dissolve Mode
    [SerializeField]
    GameObject[] dissolveObjects;
    [SerializeField]
    Material dissolveMaterial;
    bool timeOut = false;
    float objectDissolve;

    // Properties for the Light and Enemy
    [SerializeField]
    GameObject light;
    [SerializeField]
    GameObject enemy;

    // Use this for initialization
    void Start ()
    {
        // Reinit the Material to -1.0f
        dissolveMaterial.SetFloat("Vector1_E9202937", -1.0f);
        objectDissolve = -1.0f;

        // Enemy has delay of 10 seconds
        timeEnemy += 10.0f + timeLeftToStart;
    }
	
	// Update is called once per frame
	void Update () {
        timeLeftToStart -= Time.deltaTime;
        timeEnemy -= Time.deltaTime;
        if (timeLeftToStart < 0 && timeOut == false)
        {
            DissolveObjects();
            timeOut = true;
        }
        if(timeEnemy < 0)
        {
            enemyAppears = true;
            TurnOnLight();
            AppearEnemy();
        }

        if (timeOut)
        {
            DissolveAction();
        }
    }

    void DissolveObjects()
    {
        if (dissolveObjects.Length <= 0)
        {
            return;
        }
        foreach(GameObject go in dissolveObjects)
        {
            go.GetComponent<Renderer>().material = dissolveMaterial;
            Destroy(go, 5f);
        }
    }

    void DissolveAction()
    {
        //objectDissolve += Time.deltaTime;
        if (objectDissolve < 1)
        {
            objectDissolve += 0.5f * Time.deltaTime;
            dissolveMaterial.SetFloat("Vector1_E9202937", objectDissolve);
        }
    }

    public void TurnOnLight()
    {
        light.SetActive(true);
    }

    public void TurnOffLight()
    {
        light.SetActive(false);
    }

    public void AppearEnemy()
    {
        enemy.SetActive(true);
    }

    public void DissapearEnemy()
    {
        enemy.SetActive(false);
    }

}
