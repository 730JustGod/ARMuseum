using System.Collections.Generic;
using System.Runtime.InteropServices;
using GoogleARCore;
using UnityEngine;
using UnityEngine.UI;


public class ARCoreImageController : MonoBehaviour
{

    public AugmentedImageVisualizer AugmentedImageVisualizerPrefab;


    public GameObject FitToScanOverlay;
    public GameObject change;
    public GameObject voice;
    public GameObject display;
    public GameObject opengallery;

    private Dictionary<int, AugmentedImageVisualizer> m_Visualizers
            = new Dictionary<int, AugmentedImageVisualizer>();//增强图像与已经放置的物体一一对应

    private List<AugmentedImage> m_TempAugmentedImages = new List<AugmentedImage>();


    public void Awake()
    {

        Application.targetFrameRate = 60;
    }


    public void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }


        if (Session.Status != SessionStatus.Tracking)
        {
            Screen.sleepTimeout = SleepTimeout.SystemSetting;
        }
        else
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        //获取当前帧中追踪到的图像
        Session.GetTrackables<AugmentedImage>(
            m_TempAugmentedImages, TrackableQueryFilter.Updated);

        foreach (var image in m_TempAugmentedImages)
        {
            AugmentedImageVisualizer visualizer = null;
            m_Visualizers.TryGetValue(image.DatabaseIndex, out visualizer);
            if (image.TrackingState == TrackingState.Tracking && visualizer == null)
            {
                //在图像所在位置创建锚点并放置物体
                Anchor anchor = image.CreateAnchor(image.CenterPose);
                visualizer = (AugmentedImageVisualizer)Instantiate(
                    AugmentedImageVisualizerPrefab, anchor.transform);
                visualizer.Image = image;
                m_Visualizers.Add(image.DatabaseIndex, visualizer);
            }
            else if (image.TrackingState == TrackingState.Stopped && visualizer != null)
            {
                //若图像追踪不到，则物体消除
                m_Visualizers.Remove(image.DatabaseIndex);
                GameObject.Destroy(visualizer.gameObject);
            }
        }

        //设置ui显示部分
        foreach (var visualizer in m_Visualizers.Values)
        {
            if (visualizer.Image.TrackingState == TrackingState.Tracking)
            {
                FitToScanOverlay.SetActive(false);
                change.SetActive(true);
                voice.SetActive(true);
                display.SetActive(true);
                opengallery.SetActive(true);
                return;
            }
        }

        FitToScanOverlay.SetActive(true);
        change.SetActive(false);
        voice.SetActive(false);
        display.SetActive(false);
        opengallery.SetActive(false);
    }
}




