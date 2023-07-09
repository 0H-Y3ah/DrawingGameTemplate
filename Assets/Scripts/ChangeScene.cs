using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void moveScene(int sceneId){
        
        SceneManager.LoadScene(sceneId);
    }

    public void Exit(){
        Application.Quit();
    }
}
