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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements; // only compile Ads code on supported platforms
#endif

public class XClubController : MonoBehaviour
{

    public State currentState = State.Closed;
    private float time = 0.0f;

    private GameObject closedImage;
    private GameObject opened1Image;
    private GameObject opened2Image;
    private GameObject button;
    private bool buttonActive = false;
    public enum State
    {
        Closed,
        Opened
    }

    // Use this for initialization
    void Start()
    {
        closedImage = transform.Find("Closed").gameObject;
        closedImage.transform.SetAsLastSibling();
        opened1Image = transform.Find("Opened1").gameObject;
        opened2Image = transform.Find("Opened2").gameObject;
        button = transform.Find("XClubButton").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ADS
        if (Advertisement.IsReady())
        {
            currentState = State.Opened;
            buttonActive = true;
        }
        else
        {
            currentState = State.Closed;
            buttonActive = false;
        }
#endif
#if UNITY_STANDALONE // Mac OS X, Windows or Linux
         currentState = State.Opened;
        buttonActive = false;
#endif
        if (currentState == State.Opened)
        {
            time += Time.deltaTime;
            button.SetActive(buttonActive);
            if (time < 1)
            {
                opened1Image.transform.SetAsLastSibling();
                button.transform.SetAsLastSibling();
            }
            else if (time < 2)
            {
                opened2Image.transform.SetAsLastSibling();
                button.transform.SetAsLastSibling();
            }
            else
            {
                time = 0.0f;
            }
        }
        else
        {
            closedImage.transform.SetAsLastSibling();
            button.SetActive(false);
        }
    }

}
