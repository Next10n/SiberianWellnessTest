using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    SaveLoadScript Saveload;
    GameObject _targetObject;
    CameraController _camera;

    void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
        Saveload = GameObject.Find("SaveLoadObject").GetComponent<SaveLoadScript>();
        Saveload.LoadGame();        
    }

    public void SetTargetObject(GameObject target)
    {
        _camera.SetObjectToFollow(target);
        _targetObject = target;
    }

    public GameObject GetTargetObject()
    {
        return _targetObject;
    }

    public bool CheckFollowObject()
    {
        if (_targetObject == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void ClearObjectToFollow()
    {
        _camera.SetObjectToFollow(null);
        _targetObject = null;
    }

}
