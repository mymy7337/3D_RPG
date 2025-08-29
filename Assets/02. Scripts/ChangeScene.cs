using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ToStg1()
    {
        SceneManager.LoadScene("Stage1Scene");
    }

    public void ToStg2()
    {
        SceneManager.LoadScene("Stage2Scene");
    }
}
