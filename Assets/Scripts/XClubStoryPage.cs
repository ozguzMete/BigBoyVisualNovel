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

/// <summary>
/// X Club area is a promotional place
/// where we show a little bit more info for the curious ones in exchange of an ad watch
/// every time it is disabled it cleans every object it created.
/// </summary>
public class XClubStoryPage : MonoBehaviour
{

    private GameObject sceneImages;
    private GameObject shotGridLayout;


    // Use this for initialization
    void Start()
    {
        sceneImages = transform.Find("PlayArea/SceneImages").gameObject;
        shotGridLayout = transform.Find("PlayArea/Flow/ShotGridLayout").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        foreach (Transform child in sceneImages.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in shotGridLayout.transform)
        {
            GameObject.Destroy(child.gameObject);

        }
    }
}