using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectListToggler : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _toggleObjects = new List<GameObject>();

    private int _listCount;
    private int _objIdx = 0;

    void Start()
    {
        _listCount = _toggleObjects.Count;

        if (_listCount < 1)
        {
            return;
        }
        _toggleObjects.First().SetActive(true);
        foreach (var obj in _toggleObjects.Skip(1))
        {
           obj.SetActive(false);
        }
    }

    public void Toggle()
    {
        _toggleObjects[_objIdx % _listCount].SetActive(false);
        _toggleObjects[++_objIdx % _listCount].SetActive(true);
    }
}
