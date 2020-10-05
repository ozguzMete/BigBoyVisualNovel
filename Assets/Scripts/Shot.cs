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

public class Shot : StoryElement
{
    private bool progressive = false;
    public static readonly int DEFAULT_TOTAL_FRAME_SIZE = 3;
    private int totalFrameSize = 3;
    protected string name = "Default Shot";
    private int hookIndex = -1;

    public Shot()
    {

    }

    public Shot AddProgressive(bool progressive = true)
    {
        this.progressive = progressive;
        return this;
    }

    public Shot AddName(string name)
    {
        this.name = name;
        return this;
    }

    public Shot AddHookIndex(int hookIndex)
    {
        this.hookIndex = hookIndex;
        return this;
    }

    public Shot AddFrameSize(int frameSize)
    {
        this.totalFrameSize = frameSize;
        return this;
    }

    public bool Progressive
    {
        get
        {
            return progressive;
        }
    }

    public int TotalFrameSize
    {
        get
        {
            return totalFrameSize;
        }
    }

    public int HookIndex
    {
        get
        {
            return hookIndex;
        }
    }

    public string Name()
    {
        return name;
    }
}
