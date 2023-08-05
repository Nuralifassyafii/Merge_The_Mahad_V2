using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    // Start is called before the first frame update
   public void LoadScene(string sceneName)
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(sceneName);
    }
}
