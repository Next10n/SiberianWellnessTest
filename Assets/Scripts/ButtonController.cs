using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    [SerializeField] GameController _gameController;

    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }


    private void Update()
    {
       // SetButtonText();
    }

    //проверяем цвет кнопки с цветом текущей выбранной фигуры
    public void SetButtonText()
    {
        if (GetCurrentColor() == gameObject.GetComponent<Button>().image.color)
        {
            gameObject.GetComponentInChildren<Text>().text = "Выбран этот цвет";
        }
        else
        {
            gameObject.GetComponentInChildren<Text>().text = "";
        }
    }

    public GameObject GetFollowObject()
    {
        print(_gameController.GetTargetObject());

        
        return _gameController.GetTargetObject();
    }

    public Color GetCurrentColor()
    {
        return GetFollowObject().GetComponent<FigureController>().GetCurrentColor();
    }

    public void SetColor()
    {
        GetFollowObject().GetComponent<FigureController>().SetColor(gameObject.GetComponent<Button>().image.color);
    }
}
