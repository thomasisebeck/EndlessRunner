using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levelLayers;

    private Camera mainCamera;
    private Vector2 screenBounds;

    private void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        //stores screen width and height in 2d vect
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        //load each gameobject
        foreach (GameObject layer in levelLayers)
            loadSprites(layer);
        
    }

    void loadSprites(GameObject sprite)
    {
        float currentWidth = sprite.GetComponent<SpriteRenderer>().bounds.size.x;
        int childrenToSpawn = (int)Mathf.Ceil(screenBounds.x * 2 / currentWidth);
        GameObject clone = Instantiate(sprite) as GameObject;
        for (int i = 0; i <= childrenToSpawn; i++)
        {
            GameObject newObj = Instantiate(clone) as GameObject;
            newObj.transform.SetParent(sprite.transform);
            newObj.transform.position = new Vector3(
                    currentWidth * i, 
                    sprite.transform.position.y, 
                    sprite.transform.position.z
                );
        }
        Destroy(clone);
        Destroy(sprite.GetComponent<SpriteRenderer>());
    }

    private void LateUpdate()
    {
        foreach(GameObject obj in levelLayers)
        {
            place(obj);
        }
    }

    void place(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(
                    lastChild.transform.position.x + halfWidth * 2, 
                    lastChild.transform.position.y, 
                    lastChild.transform.position.z
                    );
            } else if (transform.position.x + screenBounds.x < lastChild.transform.position.x - halfWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(
                    lastChild.transform.position.x - halfWidth * 2,
                    lastChild.transform.position.y,
                    lastChild.transform.position.z
                    );
            }
        }
    }
}
