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
/// BUILD FORMULA: major * 10000 + minor * 100 + build
/// Build version: 2.10.3 -> Bundle version code: 2100
/// 
/// PS D:\AndroidSDK\platform-tools> .\adb logcat > ahmet
/// 
/// </summary>
public class GameManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        AnalyticsEvent.Custom("SystemInfo", new Dictionary<string, object> {
            { "deviceModel", SystemInfo.deviceModel },
            { "deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier},
            { "operatingSystem", SystemInfo.operatingSystem }
        });
    }


    public void OnApplicationPause(bool pause)
    {
        PlayerPrefs.Save();
    }

    public void OnApplicationQuit()
    {
        AnalyticsEvent.Custom("PlayTime", new Dictionary<string, object> { { "duration", Time.timeSinceLevelLoad } });
        PlayerPrefs.Save();
    }
}
