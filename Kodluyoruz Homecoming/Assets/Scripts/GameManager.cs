using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

   [SerializeField] private TextMeshProUGUI _waitText;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameState gameState;
    private Coroutine _coroutine;
    bool _isWaitingToStart;
    void Start()
    {
        _isWaitingToStart = true;
      //  playerController.enabled = false;
        gameState.enabled = false;
        _coroutine = StartCoroutine(WaitForStart());
    }

   

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);

            if(parmak.phase == TouchPhase.Began)
            {

                _isWaitingToStart = false;
                StopCoroutine(_coroutine);
                _waitText.enabled = false;
                gameState.enabled = true;
             //   playerController.enabled = true;
                
            }
        }
    }
    private IEnumerator WaitForStart()
    {
        float t = 0;

        while (_isWaitingToStart)
        {
            var val = Mathf.PingPong(t, 0.5f) + 0.5f;
            _waitText.color = new Color(1, 1, 1, val);
            yield return null;
            t += Time.deltaTime;
        }
    }
}
