using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Ballon> ballons = new List<Ballon>();
    private Ballon Ballon;

    [SerializeField] TMP_Text ballonText;
    [SerializeField] Button stopBtn;
    [SerializeField] TMP_Text stopText;

    [SerializeField] bool isStopped = false;

    public void AddBallon(Ballon newBallon)
    {
        ballons.Add(newBallon);
        UpdateBallonNum();

    }

    public void RemoveBallon(Ballon ballonToRemove)
    {
        ballons.Remove(ballonToRemove);
        UpdateBallonNum();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Ballon ballon = other.GetComponent<Ballon>();
        if (ballon != null)
        {
            RemoveBallon(ballon);

            Destroy(other.gameObject);
        }
    }

    private void UpdateBallonNum()
    {
        ballonText.text = ballons.Count.ToString();
    }

    public void StopAndResume()
    {
        if (!isStopped)
        {
            stopText.text = "Resume";
            isStopped = true;
            StopBallons();
        }
        else
        {
            stopText.text = "Stop";
            isStopped = false;
            ResumeBallons();
        }
    }

    private void StopBallons()
    {
        foreach (Ballon ballon in ballons)
        {
            ballon.speed = 0;
        }
    }

    private void ResumeBallons()
    {
        foreach (Ballon ballon in ballons)
        {
            ballon.speed = 1;
        }
    }
}
