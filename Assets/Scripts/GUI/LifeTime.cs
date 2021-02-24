using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float lifeTimeOfPlayer = 300.0f;

    [SerializeField] private int sceneNumber = 0;

    void Update()
    {
        lifeTimeOfPlayer -= Time.deltaTime;
        if (lifeTimeOfPlayer < 0)
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), lifeTimeOfPlayer.ToString());
    }
}
