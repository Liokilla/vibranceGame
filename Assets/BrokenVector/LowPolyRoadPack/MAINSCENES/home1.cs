using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class home1 : MonoBehaviour
{ 
    public void newtrigger(string s)
    {
        SceneManager.LoadScene(s);
    }
    public static class AppHelper
    {
     #if UNITY_WEBPLAYER
     public static string webplayerQuitURL = "http://google.com";
     #endif
        public static void Quit()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
            #else
            Application.Quit();
            #endif
        }
    }
}
