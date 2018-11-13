using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    float timeLeftToStart = 10.0f;

    bool timeOut = false;

    float objectDissolve;

    [SerializeField]
    GameObject[] dissolveObjects;
    [SerializeField]
    Material dissolveMaterial;

    // Use this for initialization
    void Start ()
    {
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
}
