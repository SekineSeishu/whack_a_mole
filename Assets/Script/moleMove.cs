using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moleMove : MonoBehaviour
{
    private bool _hit;
    private float time;
    private float cooltime;
    private Vector3 topPosition;
    private Vector3 bottomPosition;
    private int nowScore;
    [SerializeField] private TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _hit = false;
        bottomPosition = gameObject.transform.position;
        topPosition = bottomPosition + new Vector3(0,10,0);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        scoreText.text = nowScore.ToString();

        if (time >= 0.0f)
        {
            if (gameObject.transform.position != topPosition)
            {
                transform.Translate(0, 1.0f, 0);
            }
        }

        if (!_hit)
        {
            if (gameObject.transform.position != bottomPosition)
            {
                transform.Translate(0, -1.0f, 0);
            }
            else
            {
                cooltime = Random.Range(5f, 10f);
                time = cooltime;
                _hit = true;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_hit)
        {
            if (Input.GetMouseButtonDown(1))
            {
                _hit = false;
                time = 0;
            }
        }
    }
}
