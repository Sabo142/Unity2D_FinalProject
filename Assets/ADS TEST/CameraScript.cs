using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Image photoDisplayArea;
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;
    public RawImage background;
    public AspectRatioFitter fit;
    public int width = 1080;
    public int height = 2400;

    private Texture2D screenCapture;

    void Start()
    {
        
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Debug.Log("No Camera Available");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, width, height);
            }

        }
        if (backCam == null)
        {
            Debug.Log("Unable to find the Back Camera");
            return;
        }

        backCam.Play();
        background.texture = backCam;
        camAvailable = true;
        screenCapture = new Texture2D(screenCapture.width, screenCapture.height, TextureFormat.RGB24, false);
    }

    void Update()
    {
        if (!camAvailable)
            return;
        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;
        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);
        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

    }
    
    public void Picture()
    {
        StartCoroutine(TakePicture());
    }

    public IEnumerator TakePicture()
    {
        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        Debug.Log("taken picture");
        ShowPhoto();
    }

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;
    }
}