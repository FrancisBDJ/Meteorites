using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button btnPlay;
    
    
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(LoadLevel1);
    }

    // Update is called once per frame
   
}
