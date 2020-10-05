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
using UnityEngine.UI;


// PS D:\AndroidSDK\platform-tools> .\adb logcat > ahmet
public class StoryManager : MonoBehaviour
{
    private Story story;
    public string StoryName;

    private ActManager actManager;
    private SceneManager sceneManager;
    private ShotManager shotManager;
    private FrameManager frameManager;
    private int CountdownForUnloadUnusedAssets = 5;

    private GameObject sceneImages;
    private GameObject shotGridLayout;

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        actManager = GetComponent<ActManager>();
        sceneManager = GetComponent<SceneManager>();
        shotManager = GetComponent<ShotManager>();
        frameManager = GetComponent<FrameManager>();

        story = Stories.Get(StoryName);
        sceneImages = transform.Find("PlayArea/SceneImages").gameObject;
        shotGridLayout = transform.Find("PlayArea/Flow/ShotGridLayout").gameObject;

        EventManager.StartListening("LanguageChanged", LanguageChanged);
    }

    private void LanguageChanged()
    {
        story = Stories.Get(StoryName);
        FlushPlayArea();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Next()
    {
        CountdownForUnloadUnusedAssets--;
        if (CountdownForUnloadUnusedAssets < 0)
        {
            CountdownForUnloadUnusedAssets = 5;
            Resources.UnloadUnusedAssets();
        }

        StoryElement storyElement = story.PeekStoryElement();

        HouseKeeping(storyElement);

        if (storyElement == null)
        {
            return;
        }
        else if (storyElement is Frame)
        {
            frameManager.Next(story);
            return;
        }
        else if (storyElement is Shot)
        {
            shotManager.Next(story.PopStoryElement() as Shot);
            if (!(storyElement is ImageShot))
            {
                Next();
            }
            return;
        }
        else if (storyElement is Scene)
        {
            Scene scene = storyElement as Scene;

            AutoSave(scene);

            sceneManager.Next(story.PopStoryElement() as Scene);

            if (scene.IsFlowing)
            {
                Next();
            }
            return;
        }
        else if (storyElement is Sequence)
        {
            story.PopStoryElement();
            Next();
            return;
        }
        else if (storyElement is Act)
        {
            actManager.Next(story.PopStoryElement() as Act);
            return;
        }
        else if (storyElement is PrefabShot)
        {
            shotManager.Next(story.PopStoryElement() as PrefabShot);
            return;
        }
    }

    /// <summary>
    /// We are saving only at scenes!
    /// But there are scenes that depend on another scene. ( so we check its HookIndex! )
    /// If HookIndex is positive that means it is dependent to another scene.
    /// </summary>
    private void AutoSave(Scene scene)
    {
        if (scene.HookIndex < 0)
        {
            story.SaveStoryPointer();
        }
    }

    private void FlushPlayArea()
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

    public void NewActSelectedForReading(int actPointer)
    {
        story.MoveStoryTo(actPointer);
        FlushPlayArea();
        Resume();
    }

    public void Resume()
    {
        StoryElement storyElement = story.PeekStoryElement();

        if (storyElement is Act || shotManager.IsThereAnyDisplayedShot() == false)
        {
            Next();
        }
    }

    private void HouseKeeping(StoryElement storyElement)
    {
        if (storyElement == null)
        {
            story.MoveStoryTo(0);
            FlushPlayArea();
            CompleteStory();
        }
        if (storyElement != null && !(storyElement is Act))
        {
            actManager.Reset();
        }
    }

    /// <summary>
    /// Logically, this operation will yield this gameobject to be disabled
    /// Best practice: invoke it after you do everything with this gameobject!
    /// </summary>
    private void CompleteStory()
    {
        story.CompleteStory();
        EventManager.TriggerStringEvent("StoryCompleted", StoryName);
    }
}
