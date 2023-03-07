using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string sceneName)  //metodo llamado por los botones para cargar la escena que se quiera
    {
        SceneManager.LoadScene(sceneName);
    }
}
