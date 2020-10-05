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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


/// <summary>
/// First TOP Class
/// It controls UI Navigation with a stack mechanism
/// First time system language check
/// Hooks for various system wide events, mostly for ad controls
/// It fires various events too! Pages and popups use events extensively
/// </summary>
public class UIController : MonoBehaviour
{
    private Stack<GameObject> pageStack = new Stack<GameObject>(); // stack to keep pages
    private int recordedStackSize = 0;

    private GameObject mainPage;
    private GameObject actsPage;
    private GameObject mainStoryPage;
    private GameObject xClubStoryPage;
    private GameObject xClubPopup;

    private GameObject xClubWatchAdButton;
    private GameObject watchAdButton;

    private Boolean SIMULATE_ESCAPE = false; // for "virtual" ECP key presses

#if UNITY_ANDROID
    private bool STORY_COMPLETED_DISPLAY_RATEUS_POPUP = false; // its first purpose is obvious, its second purpose is to delay and micromanage its display time!
#endif

    // Use this for initialization
    void Start()
    {
        mainPage = transform.Find("Main_Page").gameObject;
        actsPage = transform.Find("Acts_Page").gameObject;
        mainStoryPage = transform.Find("MainStory_Page").gameObject;
        xClubStoryPage = transform.Find("XClubStory_Page").gameObject;
        xClubPopup = transform.Find("XClub_Popup").gameObject;

        xClubWatchAdButton = GameObject.Find("XClubWatchAd_Popup/XClubWatchAdButton");
        watchAdButton = GameObject.Find("Main_Page/VerticalLayoutGroup/WatchAdButton");

        CheckLanguage();

        PushPage(mainPage);
    }

    private void CheckLanguage()
    {
        if (PlayerPrefs.GetString("Language", "X").Equals("X"))
        {
            if (Application.systemLanguage == SystemLanguage.Turkish)
            {
                PlayerPrefs.SetString("Language", "tr");
            }
            else
            {
                PlayerPrefs.SetString("Language", "en");
            }
            EventManager.TriggerEvent("LanguageChanged");
        }
    }

    void OnEnable()
    {
        EventManager.StartListening("WatchAdButton_AdvertisementFinished", WatchAdButton_AdvertisementFinished);
        EventManager.StartListening("XClubWatchAdButton_AdvertisementFinished", XClubWatchAdButton_AdvertisementFinished);
        EventManager.StartListening("Exit_Popup_OkButton_Clicked", Exit_Popup_OkButton_Clicked);
        EventManager.StartListening("StoryCompleted", StoryCompleted);
    }

    private void Exit_Popup_OkButton_Clicked()
    {
        AnalyticsEvent.Custom("Exit", null);
        Application.Quit();
    }

    private void StoryCompleted(string storyName)
    {
        AnalyticsEvent.Custom("StoryCompleted", null);
        pageStack.Clear(); // it is a good time to clear page stack, just to be precocious
        PushPage(mainPage);

#if UNITY_ANDROID
        STORY_COMPLETED_DISPLAY_RATEUS_POPUP = true;
#endif
    }

    /// <summary>
    /// Player finished an ad in order to be able to enter XClub
    /// We must open xclub story page
    /// </summary>
    private void XClubWatchAdButton_AdvertisementFinished()
    {
        if (LastUnityAd.CheckAndUpdate(xClubWatchAdButton))
        {
            AnalyticsEvent.Custom("XClubWatchAdFinished", null);
            Logger.Debug(this.GetType().FullName + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            PushPage(xClubStoryPage);
            xClubStoryPage.GetComponent<StoryManager>().NewActSelectedForReading(0);
        }
    }

    /// <summary>
    /// Player finished an ad just because he/she is kind
    /// Give them a thank you!
    /// </summary>
    private void WatchAdButton_AdvertisementFinished()
    {
        if (LastUnityAd.CheckAndUpdate(watchAdButton))
        {
            AnalyticsEvent.Custom("WatchAdFinished", null);
            Logger.Debug(this.GetType().FullName + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            EventManager.TriggerEvent("ThankYou_Popup_Display");
        }
    }

    /// <summary>
    /// Shows the Page assigned to page parameter
    /// </summary>
    /// <param name="page">A game object with a name ending with _Page</param>
    private void PushPage(GameObject page)
    {
        page.SetActive(true);
        page.transform.SetAsLastSibling();
        pageStack.Push(page);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || SIMULATE_ESCAPE)
        {
            SIMULATE_ESCAPE = false;
            if (pageStack.Peek().Equals(mainStoryPage))
            {
                // We wanted to ESC while playing...
                // dirty simple solution: push new main page
                // stack might/will grow over time but it is negligible
                PushPage(mainPage);
            }
            else
            {
                HideOldDisplayNewPage();
            }
        }
        OperationsIfStackChanged();
    }

    private void OperationsIfStackChanged()
    {
        if (recordedStackSize != pageStack.Count)
        {
            recordedStackSize = pageStack.Count;
            DecideToShowXClubPopup();
            DecideToShowRateUsPopup();
        }
    }

    /// <summary>
    /// We want to display interactable XClub only in main and acts pages
    /// </summary>
    private void DecideToShowXClubPopup()
    {
        if (pageStack.Peek().Equals(mainPage) || pageStack.Peek().Equals(actsPage))
        {
            EventManager.TriggerEvent(xClubPopup.name + "_Display");
        }
        else
        {
            EventManager.TriggerEvent(xClubPopup.name + "_Hide");
        }
    }

    private void DecideToShowRateUsPopup()
    {
#if UNITY_ANDROID
        if (STORY_COMPLETED_DISPLAY_RATEUS_POPUP)
        {
            STORY_COMPLETED_DISPLAY_RATEUS_POPUP = false;
            EventManager.TriggerEvent("RateUs_Popup_Display");
        }
#endif
    }

    private GameObject HideOldDisplayNewPage()
    {
        GameObject closingPage = null;
        if (pageStack.Count > 1)
        {
            closingPage = pageStack.Pop();
            EventManager.TriggerEvent(closingPage.name + "_Hide");
            PeekAndDisplayPage();
        }
        return closingPage;
    }

    private void PeekAndDisplayPage()
    {
        GameObject showingPage = pageStack.Peek();
        EventManager.TriggerEvent(showingPage.name + "_Display");
    }

    public void PlayButtonClicked()
    {
        PushPage(mainStoryPage);
        EventManager.TriggerEvent("PlayButton_Clicked");
        mainStoryPage.GetComponent<StoryManager>().Resume();
    }

    public void ActsButtonClicked()
    {
        PushPage(actsPage);
        EventManager.TriggerEvent("ActsButton_Clicked");
    }

    public void XClubButtonClicked()
    {
        EventManager.TriggerEvent("XClubWatchAd_Popup_Display");
    }

    public void ActButtonClicked(int actPointer)
    {
        PushPage(mainStoryPage);
        mainStoryPage.GetComponent<StoryManager>().NewActSelectedForReading(actPointer);
    }

    public void GoToLandingPage()
    {
        AnalyticsEvent.Custom("GoToLandingPage", null);
        Application.OpenURL("http://meteozguz.com/portfolio/curum");
    }

    public void GoToRateUsPage()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.METEOZGUZ.curly");
    }

    public void EscapeButtonClicked()
    {
        SIMULATE_ESCAPE = true;
    }

    public void ExitButtonClicked()
    {
        EventManager.TriggerEvent("Exit_Popup_Display");
    }

    public void LanguageButtonClicked()
    {
        EventManager.TriggerEvent("Language_Popup_Display");
    }
}
