using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapImage : MonoBehaviour
{
    [SerializeField] private Sprite[] image;

    public void ImageChange(int idx)
    {
        GetComponent<Image>().sprite= image[idx];
    }
}
