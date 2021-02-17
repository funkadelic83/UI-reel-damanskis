using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewVideo", menuName = "VideoScriptableObject", order = 1)]
public class VideoData_SO : ScriptableObject
{
    public string videoName;
    public string videoClientID;
    public string videoRole;
    public string videoDescription;
    public Texture videoThumbnail;
}
