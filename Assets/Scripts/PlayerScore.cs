using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour  //Active text "You WIN" if score == 3
{
    [SerializeField] GameObject _textWin;
    private int _score = 0;
    private int _maxScore = 3;

    private void Start()
    {
        _textWin.SetActive(false);
    }

    public void AddScore()
    {
        _score += 1;
        if (_score == _maxScore)
        {
            _textWin.SetActive(true);
        }
    }

    
}
