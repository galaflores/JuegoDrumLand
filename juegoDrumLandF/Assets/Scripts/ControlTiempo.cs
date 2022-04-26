using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTiempo : MonoBehaviour
{
    [SerializeField]
    private string tiempo;

    [SerializeField]
    private GameObject playerPrefab;

    private GameObject player;

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private GameObject selectedSpawnPoints;

    [SerializeField]
    private GameObject menuCamera;

    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private GameObject gameUI;

    private Timer Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = gameObject.GetComponent<Timer>();
        menuCamera.SetActive(true);
        menuUI.SetActive(true);
        gameUI.SetActive(false);
    }

    // Update is called once per frame
    public void startGame()
    {
        Timer.startTimer();
        menuCamera.SetActive(false);
        menuUI.SetActive(false);
        gameUI.SetActive(true);
    }

    public void endGame()
    {
        Timer.stopTimer();
        menuCamera.SetActive(true);
        menuUI.SetActive(true);
        gameUI.SetActive(false);

        Destroy(player);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
