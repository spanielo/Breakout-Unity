using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public HighScoreData data = new HighScoreData();

    public string playerName = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadHighScore();
    }

            
    [System.Serializable]
    public class HighScoreData
    {
        public int score = 0;
        public string name = "";
    }

    public void SaveHighScore()
    {
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void LoadHighScore()
    {
        var path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            data = JsonUtility.FromJson<HighScoreData>(json);
        }
    }

    public void UpdateHighScore(int points)
    {
        if (points >= data.score)
        {
            data.score = points;
            data.name = playerName;
            SaveHighScore();
        }
    }


}