using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameData : MonoBehaviour
{
    public static GameData instance;
    
    public bool isSinglePlayer;
    public float gameTimer;
    public GameObject selectBall;
    private void Awake() 
    {
        if(instance != null)
          Destroy(gameObject);
        else
          instance = this;

          DontDestroyOnLoad(gameObject); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // // Update is called once per frame
    void Update()
    {
        
    }
}
