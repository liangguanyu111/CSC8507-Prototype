using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UnityEvent OnPlayerDie = new UnityEvent();

    public GameObject Player;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        OnPlayerDie.AddListener(OnPlayerDied);
    }


    void OnPlayerDied()
    {
        Player.gameObject.GetComponent<CharacterController>().enabled = false;  //Creazy
        Player.transform.position = new Vector3(0, 3, -20);
        Player.gameObject.GetComponent<CharacterController>().enabled = true;
        Debug.Log(Player.transform.position);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}

