using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{

    public GameObject asteroid;
    public GameObject klingon;
    public GameObject enterpise;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text gameOverText;
    public Text infoText;
    private bool gameOver = false;
    private bool restart = false;

    public Text scoreText;
    private int score;
    private int life = 10;
    public GameObject torpedo;
    public GameObject borg;
    private bool stop;

    void Start()
    {
        infoText.text = "";

        score = 0;
        updateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator SpawnWaves()
    {
        infoText.text = "Shoot with space!";
        yield return new WaitForSeconds(startWait);
        infoText.text = "";
       


        yield return Asteroids();
        if (stop)
        {
            yield break;
        }
        yield return Klingons();
        if (stop)
        {
            yield break;
        }
        yield return Torpedo();
        if (stop)
        {
            yield break;
        }
        yield return Borg();
    }

    private IEnumerator Borg()
    {
        yield return new WaitForSeconds(spawnWait);
        Create(borg);

    }

    private IEnumerator Asteroids()
    {
        

        for (int i = 0; i < hazardCount; i++)
        {
            Create(asteroid);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    private IEnumerator Klingons()
    {
        yield return new WaitForSeconds(waveWait);
        for (int i = 0; i < hazardCount; i++)
        {
            Create(klingon);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(waveWait);
    }

    private void Create(GameObject gameObject)
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(gameObject, spawnPosition, spawnRotation);
    }

    internal void Stop()
    {
        stop = true;
    }

    private IEnumerator Torpedo()
    {
        infoText.text = "Catch it and shoot with x!";
        yield return new WaitForSeconds(waveWait);
        Create(torpedo);
        yield return new WaitForSeconds(waveWait);
        infoText.text = "";

    }



    public void AddScore(int newScore)
    {
        score = newScore + score;
        updateScore();
    }


    void updateScore()
    {
        scoreText.text = "Score: " + score;
    }




}
