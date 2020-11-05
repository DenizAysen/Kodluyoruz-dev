using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI _scoretext;
    [SerializeField] private PlayerController playerController;
    private Coroutine coroutine;
    private int score;
    

    private void OnEnable()
    {
        coroutine = StartCoroutine(AddScore(1f));
        _scoretext.enabled = true;
        playerController.enabled = true;
    }

    private void OnDisable()
    {
        StopCoroutine(coroutine);
        _scoretext.enabled = false;
        score = 0;
        playerController.enabled = false;
    }
    // Update is called once per frame
   

    private IEnumerator AddScore(float time)
    {
        WaitForSeconds wait = new WaitForSeconds(time);
        while (true)
        {
            score += 1;
            _scoretext.text = "" + score;
            yield return wait;


        }
    }
    public void ChangeScore(int point )
    {
        score += point;
        _scoretext.text = "" + score;
    }

}
