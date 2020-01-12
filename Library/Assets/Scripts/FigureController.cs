using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour
{
    private Vector3 _randomV3;

    private void Start()
    {
        _randomV3 = new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
    }

    private void Update()
    {
        //вращаем фигуры на сцене, чтоб не так скучно было
        transform.Rotate(_randomV3);
    }

    //происходит тоже самое что при нажатии на кнопку фигуры и кнопку назад на второй панели, при втором нажатии на фигуру
    private void OnMouseDown()
    {        
        GameController _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        UIController uiController = GameObject.Find("UIController").GetComponent<UIController>();
        ButtonUpdater bUpdater = GameObject.Find("ButtonUpdater").GetComponent<ButtonUpdater>();
        if (_gameController != null && uiController != null && bUpdater != null)
        {            

            if (uiController.IsMainPanelActive())
            {
                uiController.EnableObjectPanel();
            }
            else
            {
                uiController.EnableMainPanel();
            }
            if (_gameController.CheckFollowObject())
            {
                print("ggg");
                bUpdater.UpdateButtons();
                _gameController.SetTargetObject(null);
            }
            else
            {
                _gameController.SetTargetObject(gameObject);
                bUpdater.UpdateButtons();
            }

            

        }
        else
        {
            print("На сцене не хватает одного из контроллеров");
        }

        if(bUpdater == null)
        {
            print("bupdater null");
        }
        
    }

    public Color GetCurrentColor()
    {
        return gameObject.GetComponent<Renderer>().material.color;
    }

    public void SetColor(Color c)
    {
        gameObject.GetComponent<Renderer>().material.color = c;
    }

   

}
