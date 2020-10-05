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

public abstract class Story
{

    protected List<StoryElement> story = new List<StoryElement>();
    protected Dictionary<Act, int> acts = new Dictionary<Act, int>();


    private int index = 0;

    public int StoryPointer
    {
        get
        {
            return index;
        }
        set
        {
            index = value;
        }
    }

    public Dictionary<Act, int> Acts
    {
        get
        {
            return acts;
        }
    }

    public Story()
    {

    }

    public StoryElement PeekStoryElement()
    {
        if (index >= story.Count)
        {
            return null;
        }
        else
        {
            return story[index];
        }
    }

    public StoryElement PopStoryElement()
    {
        if (index >= story.Count)
        {
            return null;
        }
        else
        {
            return story[index++];
        }
    }

    public void MoveStoryTo(int index)
    {
        if (index >= story.Count || index < 0)
        {
            this.index = 0;
        }
        else
        {
            this.index = index;
        }
    }

    protected void Add(StoryElement storyElement)
    {
        if (storyElement is Act)
        {
            acts.Add(storyElement as Act, story.Count);
        }
        story.Add(storyElement);
    }

    public abstract void SaveStoryPointer();
    public abstract void CompleteStory();
}
