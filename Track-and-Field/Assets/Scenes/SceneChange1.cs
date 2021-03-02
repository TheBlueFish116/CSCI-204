using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange1 : MonoBehaviour
{
    private float timeSinceStart;

    // Start is called before the first frame update
    public void ChangeScene(string sceneName){
        SceneManager.LoadScene("Game");
    }
    void Update(){
        timeSinceStart += Time.deltaTime;
        if( timeSinceStart > 30){
            ChangeScene("sauce");
        }
    }

}
