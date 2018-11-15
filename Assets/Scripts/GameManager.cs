using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // GameOver properties
    [SerializeField]
    Image gameOverImage; // Game Over Sprite
    float timeChangeScreen = 3.0f;
    bool gameOver = false;


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

        if (gameOver)
        {
            timeChangeScreen -= Time.deltaTime;
            Color tempColor = gameOverImage.color;
            tempColor.a += 0.5f * Time.deltaTime; 
            gameOverImage.color = tempColor;
            if (timeChangeScreen <= 0)
            {
                // SceneManager.LoadScene("GameOver"); For Next future
                Application.Quit();
            }
        }
        if (Input.GetKey("escape") || OVRInput.GetDown(OVRInput.Button.Start))
        {
            Application.Quit();
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


    public void GameOver()
    {
        gameOver = true;
    }
}
