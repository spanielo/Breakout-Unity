using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text highScoreField;

    private void Start()
    {
        var data = GameManager.Instance.data;
        highScoreField.text = data.name + " : " + data.score;
        inputField.text = GameManager.Instance.playerName;
    }

    public void StartNew()
    {
        GameManager.Instance.playerName = inputField.text;
        if (GameManager.Instance.playerName.Length == 0)
            GameManager.Instance.playerName = "---";
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
