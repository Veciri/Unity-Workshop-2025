using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseFollower : MonoBehaviour
{
    public static MouseFollower instance;
    public Sprite defaultCursor;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            return;
        }
        Destroy(this);
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void ChangeCursor(Sprite icon)
    {
        if(icon==null)
        {
            GetComponent<Image>().sprite = defaultCursor;

        }
        else
        {
            GetComponent<Image>().sprite = icon;
        }
    }
}
