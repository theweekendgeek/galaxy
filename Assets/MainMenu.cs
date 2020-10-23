using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
    
{
    public Button yourButton;
    
    void Start ()
    {
        Debug.Log("MIMIMIMI");
        Button btn = GetComponent<Button>();
        Debug.Log(btn);
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        Debug.Log ("You have clicked the button!");
        SceneManager.LoadScene("SampleScene");
    }
}
