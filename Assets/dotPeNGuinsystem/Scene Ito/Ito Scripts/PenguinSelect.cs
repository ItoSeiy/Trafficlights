using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PenguinSelect : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private GameObject _penguin1;
    [SerializeField] private GameObject _penguin2;
    [SerializeField] private GameObject _penguin3;
    [SerializeField] private GameObject _penguin4;
    [SerializeField] Transform _penguinPosison;
    private GameObject[] _penguins;
    private int _penguinCount;
    private int _penguinLimit = 4;

    public void ShowValue()
    {
        Debug.Log(_dropdown.value);
    }
    public void ChangeValue()   
    {
        switch(_dropdown.value)
        {
            case 0:
                _penguins = GameObject.FindGameObjectsWithTag("Penguin");
                _penguinCount = 0;
                foreach(var p in _penguins)
                {
                    Destroy(p);
                }
                break;
            case 1:
                Instantiate(_penguin1, _penguinPosison);
                PenguinCount();
                break;
            case 2:
                Instantiate(_penguin2, _penguinPosison);
                PenguinCount();
                break;
            case 3:
                Instantiate(_penguin3, _penguinPosison);
                PenguinCount();
                break;
            case 4:
                Instantiate(_penguin4, _penguinPosison);
                PenguinCount();
                break;
        }
    }
    private void PenguinCount()
    {
        _penguins = GameObject.FindGameObjectsWithTag("Penguin");
        _penguinCount++;

        if(_penguinCount > _penguinLimit)
        {
            foreach(var p in _penguins)
            {
                Destroy(p);
            }
            _penguinCount = 0;
        }
    }
}
