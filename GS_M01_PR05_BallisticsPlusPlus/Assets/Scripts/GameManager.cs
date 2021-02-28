using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PathFollower batter;
    RandomPosition ballPos;
    Projectile projectile;

    public Text text;
    private void Awake()
    {
        ballPos = FindObjectOfType<RandomPosition>();
        batter = FindObjectOfType<PathFollower>();
        projectile = FindObjectOfType<Projectile>();
        text.text = "";
        ballPos.FindNewPosition();
    }
    private void Start()
    {
        batter.didHit = true;
        projectile.Launch(projectile.launchForce);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
