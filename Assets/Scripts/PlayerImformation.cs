using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class PlayerImformation : MonoBehaviour
{
    public string playerName;
    public static PlayerImformation Instance;
    public int bestScore;
    public GameObject bestScoreDisplay;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
        LoadScore();
        bestScoreDisplay.GetComponent<TextMeshProUGUI>().text+= bestScore;
    }
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    class PlayerPro
    {
        public int score;
    }

    public void SaveScore()
    {
        PlayerPro playerPro = new PlayerPro();
        playerPro.score = bestScore;
        string json = JsonUtility.ToJson(playerPro);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(!File.Exists(path))
        {
            bestScore = 0;
            return;
        }
        string json = File.ReadAllText(path);
        bestScore = JsonUtility.FromJson<PlayerPro>(json).score;       
    }
}
