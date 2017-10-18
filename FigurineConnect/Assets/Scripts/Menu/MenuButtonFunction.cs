using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonFunction : MonoBehaviour {


    public GameObject[] menuItems;

    void Start() {
        for (int i = 0; i < menuItems.Length; i++) {
            menuItems[i].SetActive(i == 0);
        }
    }

    public void LoadScene(string s) {
        SceneManager.LoadSceneAsync(s);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Bleep() {
        //Play Beep sound
    }
}
