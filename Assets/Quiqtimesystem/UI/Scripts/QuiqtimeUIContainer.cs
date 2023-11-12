using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuiqtimeUIContainer : MonoBehaviour
{
    private List<Image> containerImages;

    private void Start()
    {
        InitializeContainerImages();
    }

    private void InitializeContainerImages()
    {
        List<Image> images = new List<Image>();
        
        for (int i = 0; i < transform.childCount; i++) 
        {
            Transform child = transform.GetChild(i);
            Image childImage = child.GetComponent<Image>();

            if (childImage != null)
                images.Add(childImage);
        }

        containerImages = images;
    }
    
    public void SetImages()
    {

    }
}
