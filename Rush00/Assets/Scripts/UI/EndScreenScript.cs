using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour {

    [SerializeField] GameObject GameManager;
    [SerializeField] GameObject win;
    [SerializeField] GameObject loose;


	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
        win.SetActive(GameManager.GetComponent<GameManager>().winState);
        loose.SetActive(!GameManager.GetComponent<GameManager>().winState);
	}


}
