using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Timer
    [SerializeField]
    float timeLeftToStart = 10.0f;


    // Properties for Dissolve Mode
    [SerializeField]
    GameObject[] dissolveObjects;
    [SerializeField]
    Material dissolveMaterial;
    bool timeOut = false;
    float objectDissolve;

    // Use this for initialization
    void Start ()
    {
        // Reinit the Material to -1.0f
        dissolveMaterial.SetFloat("Vector1_E9202937", -1.0f);
        objectDissolve = -1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        timeLeftToStart -= Time.deltaTime;
        if (timeLeftToStart < 0 && timeOut == false)
        {
            DissolveObjects();
            timeOut = true;
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

    public void turnOnLight()
    {

    }

    public void turnOffLight()
    {

    }
    
}
