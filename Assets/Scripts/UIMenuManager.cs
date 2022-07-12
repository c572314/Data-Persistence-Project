using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIMenuManager : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public GameObject playerName;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()
    {
        PlayerImformation.Instance.playerName = playerName.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene("main");
    }
}
