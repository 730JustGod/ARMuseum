using GoogleARCore;
using UnityEngine;

public class AugmentedImageVisualizer : MonoBehaviour
{
    public AugmentedImage Image;
    public void Update()
    {
        if (Image == null || Image.TrackingState != TrackingState.Tracking)
        {
            return;
        }
    }
}


