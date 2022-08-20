using UnityEngine.SceneManagement;
using UnityEngine;
using Core;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string name)
    {
        DataManager.Instance.SaveFile();
        SceneManager.LoadScene(name);
    }
}
