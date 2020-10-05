#region copyright
/*
 * Copyright Mete Ozguz 2018
 *
 * http://www.meteozguz.com
 * ozguz.mete@gmail.com
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 */
# endregion
using UnityEngine;
using UnityEngine.UI;
#if UNITY_ADS
using UnityEngine.Advertisements; // only compile Ads code on supported platforms
#endif

/// <summary>
/// A modified version of the class found here: https://unityads.unity3d.com/help/monetization/integration-guide-unity
/// </summary>
[RequireComponent(typeof(Button))]
public class UnityAdsButton : MonoBehaviour
{
    private Button m_Button;

#if UNITY_ADS
    private string placementId = "NONE";
#endif

#if UNITY_ANDROID
    private string gameId = "666"; // ENTER YOUR GAME ID HERE
#endif

    void Start()
    {
        m_Button = GetComponent<Button>();

        if (m_Button)
        {
            m_Button.onClick.AddListener(ShowAd);
        }
#if UNITY_ADS
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, false);
        }
#endif
    }

    void Update()
    {
        if (m_Button)
        {
#if UNITY_ADS
            // We prioritize rewardedVideos over videos, when there is no rewardedVideo we will show videos
            if (Advertisement.IsReady("rewardedVideo"))
            {
                m_Button.interactable = true;
                placementId = "rewardedVideo";
                return;
            }
            if (Advertisement.IsReady("video"))
            {
                m_Button.interactable = true;
                placementId = "video";
                return;
            }
            m_Button.interactable = false;
#endif
        }
    }


    public void ShowAd()
    {
#if UNITY_ADS
        ShowOptions options = new ShowOptions();
        LastUnityAd.CheckAndUpdate(gameObject);
        options.resultCallback = HandleShowResult;
        Advertisement.Show(placementId, options);
#endif
    }

#if UNITY_ADS
    /// <summary>
    /// We trigger ad related event specific to atteched game object
    /// </summary>
    private void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            EventManager.TriggerEvent(gameObject.name + "_AdvertisementFinished");
        }
        else if (result == ShowResult.Skipped)
        {
            EventManager.TriggerEvent(gameObject.name + "_AdvertisementSkipped");
        }
        else if (result == ShowResult.Failed)
        {
            EventManager.TriggerEvent(gameObject.name + "_AdvertisementFailed");
        }
    }
#endif
}