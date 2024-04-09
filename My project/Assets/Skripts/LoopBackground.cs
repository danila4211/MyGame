using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
public class LoopBackground : MonoBehaviour
{
    public float backgroundspeed;
    [SerializeField] private int _currentBackgroundIndex; 
    public List<Sprite> ImageList;
    private SpriteRenderer _background;
    [SerializeField] private ScoreScript score;

    private void Awake()
    {
        _background = GetComponent<SpriteRenderer>();
        ChangeBackground();
        score.ScoreHittedThousand += OnHittedThousad;
    }

    //private void LoopBackround()
    //{
    //    ImageList[_currentBackgroundIndex].textureRectOffset. += new Vector2(backgroundspeed * Time.deltaTime, 0f);
    //}

    private void ChangeBackground()
    {
        _background.sprite = ImageList[_currentBackgroundIndex];
    }

    private void OnHittedThousad()
    {
        _currentBackgroundIndex++;
        if (_currentBackgroundIndex == ImageList.Count)
        {
            _currentBackgroundIndex = 0;
        }
        ChangeBackground();
    }

}
