using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Help : MonoBehaviour
{
    [SerializeField]
    private Text _dispText;
    public int _count;

    // Start is called before the first frame update
    void Start()
    {
        OnClickNext();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNext()
    {
        _count++;

        if(_count==1)
        {
            _dispText.text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        }
        if(_count==2)
        {
            _dispText.text = "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB";
        }
        if (_count == 3)
        {
            _dispText.text = "CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC";
        }
        Debug.Log(_count);
            
    }

    public void OnClickPrevious()
    {
        _count--;

        if (_count == 1)
        {
            _dispText.text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        }
        if (_count == 2)
        {
            _dispText.text = "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB";
        }
        if (_count == 3)
        {
            _dispText.text = "CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC";
        }
        Debug.Log(_count);

    }

    public void OnCloseButtonClick(string Menu)
    {
        SceneManager.LoadScene("Menu");
    }
}