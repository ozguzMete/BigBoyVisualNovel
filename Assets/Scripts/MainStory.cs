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

public abstract class MainStory : Story
{
    protected string storyPointerName;
    protected string maxStoryPointerName;

    public MainStory()
    {
        if (this.GetType() == typeof(EnglishMainStory))
        {
            storyPointerName = "en." + "MainStory" + ".StoryPointer";
            maxStoryPointerName = "en." + "MainStory" + ".MAX_StoryPointer";
        }
        else if (this.GetType() == typeof(TurkishMainStory))
        {
            storyPointerName = "tr." + "MainStory" + ".StoryPointer";
            maxStoryPointerName = "tr." + "MainStory" + ".MAX_StoryPointer";
        }
        else
        {
            storyPointerName = "en." + "MainStory" + ".StoryPointer";
            maxStoryPointerName = "en." + "MainStory" + ".MAX_StoryPointer";
        }

        StoryPointer = PlayerPrefs.GetInt(storyPointerName, 0);
    }

    public override void SaveStoryPointer()
    {
        PlayerPrefs.SetInt(storyPointerName, StoryPointer);
        int maxStoryPointer = PlayerPrefs.GetInt(maxStoryPointerName, 0);
        if (StoryPointer > maxStoryPointer)
        {
            PlayerPrefs.SetInt(maxStoryPointerName, StoryPointer);
        }
        PlayerPrefs.Save();
    }

    public override void CompleteStory()
    {
        PlayerPrefs.SetInt(storyPointerName, 0);
        PlayerPrefs.Save();
    }
}
