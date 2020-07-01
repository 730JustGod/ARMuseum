using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;
/// <summary>
/// 截图保存安卓手机相册
/// </summary>
public class screenshot : MonoBehaviour
{ 
    //这个相机是用来截屏的，相机的Claer Flags 的属性选择为Depth Only 
    public Camera CameraTrans;
    private Texture2D mTexture1;
    private string mPath;
    public GameObject picture;
    private string mingming;
    /// <summary>
    /// 开启相机
    /// </summary>

    public void screenshots()
    {
        //用时间命名
        string mingming = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second;
        //平台判断
        if (Application.platform == RuntimePlatform.Android)
        {
            //安卓设备的相册路径
            mPath = "/sdcard/DCIM/Camera/ScreenShots/" + mingming + ".jpg";
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            mPath = Application.dataPath + "\\Resources\\" + mingming + ".jpg";
        }
        StartCoroutine(CaptureByCamera(CameraTrans, new Rect(0, 0, Screen.width, Screen.height), mPath));

    }
    private IEnumerator CaptureByCamera(Camera mCamera, Rect mRect, string mFileName)
    {
        //等待渲染线程结束  
        yield return new WaitForEndOfFrame();

        //初始化RenderTexture  
        RenderTexture mRender = new RenderTexture((int)mRect.width, (int)mRect.height, 24);
        //设置相机的渲染目标  
        mCamera.targetTexture = mRender;
        //开始渲染  
        mCamera.Render();

        //激活渲染贴图读取信息  
        RenderTexture.active = mRender;

        Texture2D mTexture = new Texture2D((int)mRect.width, (int)mRect.height, TextureFormat.RGB24, false);
        //读取屏幕像素信息并存储为纹理数据  
        mTexture.ReadPixels(mRect, 0, 0);
        //应用  
        mTexture.Apply();


        //释放相机，销毁渲染贴图  
        mCamera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(mRender);

        //将图片信息编码为字节信息  
        byte[] bytes = mTexture.EncodeToPNG();

        //保存  
        File.WriteAllBytes(mFileName, bytes);
        //将纹理图存在静态类里
        mTexture1 = mTexture;
        picture.GetComponent<Image>().sprite = Sprite.Create(mTexture1, new Rect(0, 0, Screen.width, Screen.height), new Vector2(Screen.height / 2, Screen.width / 2));
        //如果需要可以返回截图  
        //return mTexture;  

        string[] paths = new string[1];
        paths[0] = mPath;
        ScanFile(paths);
    }
    //刷新图片，显示到相册中
    void ScanFile(string[] path)
    {
        using (AndroidJavaClass PlayerActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject playerActivity = PlayerActivity.GetStatic<AndroidJavaObject>("currentActivity");
            using (AndroidJavaObject Conn = new AndroidJavaObject("android.media.MediaScannerConnection", playerActivity, null))
            {
                Conn.CallStatic("scanFile", playerActivity, path, null, null);
            }
        }
    }
}


