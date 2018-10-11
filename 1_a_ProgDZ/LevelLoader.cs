using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //funkcija za lodanje levela koja prima parametar u obliku stringa sa nazivom levela (scene)
    public void LoadLevel(string name)
    {
        // loada scenu pod nazivom koji se nalazi u stringu "name"
        SceneManager.LoadScene(name);
    }
}
