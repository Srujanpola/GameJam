using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBack : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}