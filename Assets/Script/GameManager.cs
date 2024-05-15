using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField]private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;
    private int score;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        time = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        scoreText.text = "Score:" + score.ToString();
        timeText.text = "Time:" + time.ToString();
        if (time > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    moleMove moleMove = hitInfo.collider.GetComponent<moleMove>();
                    if (moleMove != null)
                    {
                        if (moleMove._hit)
                        {
                            score++;
                            moleMove.OnHit();
                        }
                    }
                }
            }
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
