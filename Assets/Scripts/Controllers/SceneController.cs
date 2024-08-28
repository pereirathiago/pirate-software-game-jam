using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void TrocarScene(string nomeScene)
    {
        SceneManager.LoadScene(nomeScene);
    }
}
