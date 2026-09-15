using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneLoader : MonoBehaviour
{
    // Function untuk pindah ke scene lain 
    public void LoadScene(string scene)
    {
        // Membuka scene dengan nama yang 
        // ditentukan melalui parameter
        SceneManager.LoadScene(scene);
    }
 
    // Function untuk keluar dari game 
    public void Exit()
    {
        // Keluar dari game 
        // Quit hanya bisa dilakukan ketika menjalankan aplikasi game
        // Jika menjalankan game di unity maka tidak akan terjadi apa-apa 
        Application.Quit();
    }
}