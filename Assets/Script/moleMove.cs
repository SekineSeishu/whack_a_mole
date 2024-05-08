using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moleMove : MonoBehaviour
{
    public bool _hit;
    private float nowTime;
    private float coolTime;
    private Vector3 topPosition;
    [SerializeField]private Vector3 bottomPosition;
    private int nowScore;
    [SerializeField] private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        _hit = false;
        bottomPosition = this.gameObject.transform.position;
        topPosition = bottomPosition + new Vector3(0,1,0);
    }

    // Update is called once per frame
    void Update()
    {
        nowTime -= Time.deltaTime;
        scoreText.text = "Score:" + nowScore.ToString();

        if (nowTime <= 0.0f)
        {
            if (this.gameObject.transform.position != topPosition)
            {
                this.gameObject.transform.Translate(0, 0.2f, 0);
            }
        }

        if (!_hit)
        {
            if (this.gameObject.transform.position != bottomPosition)
            {
                this.gameObject.transform.Translate(0, -0.2f, 0);
            }
                Debug.Log("Start!");
                coolTime = Random.Range(5f, 10f);
                nowTime = coolTime;
                _hit = true;

        }
    }
    public void OnHit()
    {
        nowScore++;
        _hit = false;
        nowTime = 0;
    }
}
