using System.Collections;
using System.IO;
using UnityEngine;

public class ScreenCaptureManager
{
    private string _folderName = "Screenshots";
    private int _superSize = 1;

    private string _screenShotPath;

    public void CreateDirectory()
    {
        _screenShotPath = Path.Combine(Application.persistentDataPath, _folderName);

        if (!Directory.Exists(_screenShotPath))
        {
            Directory.CreateDirectory(_screenShotPath);
        }
        
        Debug.Log($"ScreenShotPath: {_screenShotPath}");
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public IEnumerator CaptureScreenShot(string customName = null)
    {
        yield return new WaitForEndOfFrame();
        
        string fileName = customName ?? GenerateFileName();
        string fullPath = Path.Combine(_screenShotPath, fileName);
        
        ScreenCapture.CaptureScreenshot(fullPath, _superSize);
        
        Debug.Log($"Screenshot salvo: {fullPath}");
        
        ShowScreenShotFeedback(fileName);
    }

    private string GenerateFileName()
    {
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        return $"Screenshot_{timestamp}.png";
    }

    private void ShowScreenShotFeedback(string fileName)
    {
        Debug.Log($"Screenshot capturado: {fileName}");
    }
}
