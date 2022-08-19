using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nodestroy : MonoBehaviour
{

    public GameObject obj; 
    public int left=30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameGo() // 다음씬
    {
        if(left==0){
            DontDestroyOnLoad(obj);
            SceneManager.LoadScene("test");
        }

    }

}
