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

public abstract class Scene : StoryElement
{

    protected string background = System.String.Empty;
    private int hookIndex = -1;
    private bool disappearOnNextScene = false;
    private bool flowing = false;

    public Scene()
    {

    }

    public Scene(string background)
    {
        this.background = background;
    }

    public string BackgroundName
    {
        get
        {
            return background;
        }
    }

    public int HookIndex
    {
        get
        {
            return hookIndex;
        }
    }

    public bool DisappearOnNextScene
    {
        get
        {
            return disappearOnNextScene;
        }
    }


    public bool IsFlowing
    {
        get
        {
            return flowing;
        }
    }

    public Scene AddFlow(bool flowing = true)
    {
        this.flowing = flowing;
        return this;
    }


    public Scene AddHookIndex(int hookIndex)
    {
        this.hookIndex = hookIndex;
        return this;
    }

    public string Name()
    {
        return background;
    }

    public Scene AddDisappearOnNextScene()
    {
        disappearOnNextScene = true;
        return this;
    }
}
