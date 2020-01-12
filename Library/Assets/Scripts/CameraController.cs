using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _cameraSpeed;
    [SerializeField] float _cameraZoom;
    [SerializeField] float _idleX;
    [SerializeField] float _idleY;
    [SerializeField] float _idleZ;
    Vector3 _idle; //дефлтное положение камеры
    private GameObject _figure;
    GameController _gameController;

    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _idle = new Vector3(_idleX, _idleY, _idleZ);

    }

    void FixedUpdate()
    {
        FollowObject();
    }

    private void FollowObject()
    {
        if (_figure != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(
                    _figure.transform.position.x,
                    _figure.transform.position.y,
                    _idleZ / _cameraZoom
                    ),
                _cameraSpeed * Time.deltaTime);

        }
        else
        {
            transform.position = Vector3.MoveTowards(
                 transform.position,
                 new Vector3(
                     _idleX,
                     _idleY,
                     _idleZ
                     ),
                 _cameraSpeed * Time.deltaTime);
        }
    }

    //объект на который зумится камера
    public void SetObjectToFollow(GameObject figure)
    {
        _figure = figure;
    }

  


}
