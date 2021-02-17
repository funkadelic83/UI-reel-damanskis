using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoMenu : MonoBehaviour
{

    [SerializeField] private RawImage _thumbnailDropZone;
    [SerializeField] private Text _roleDropZone;
    [SerializeField] private Text _clientIDDropZone;
    [SerializeField] private Text _videoDescriptionFieldDropZone;

    public void ShowVideoData(VideoData_SO videoDataToDisplay)
    {
        _thumbnailDropZone.texture = videoDataToDisplay.videoThumbnail;
        _roleDropZone.text = videoDataToDisplay.videoRole;
        _clientIDDropZone.text = videoDataToDisplay.videoClientID;
        _videoDescriptionFieldDropZone.text = videoDataToDisplay.videoDescription;
    }

}
