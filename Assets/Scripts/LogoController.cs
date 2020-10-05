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

public class LogoController : MonoBehaviour
{

    private float onOffDuration = 1.0f;
    private float time = 0.0f;
    private GameObject currentImage;
    private GameObject closedImage;
    List<GameObject> images = new List<GameObject>(4);

    private State currenState = State.RED;
    private int colorSwitch = 0;

    private enum State
    {
        OFF,
        RED,
        RED1,
        PINK,
        PINK1
    }

    void Start()
    {
        closedImage = transform.Find("Closed").gameObject;
        currentImage = closedImage;
        currentImage.transform.SetAsLastSibling();

        images.Add(transform.Find("OpenRed1").gameObject);
        images.Add(transform.Find("OpenRed2").gameObject);
        images.Add(transform.Find("OpenPink1").gameObject);
        images.Add(transform.Find("OpenPink2").gameObject);

        onOffDuration = Random.Range(1.0f, 2.0f);

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > onOffDuration)
        {
            switch (currenState)
            {
                case State.OFF:
                    colorSwitch %= 2;
                    if (colorSwitch == 1)
                    {
                        currenState = State.RED;
                    }
                    else
                    {
                        currenState = State.PINK;
                    }
                    colorSwitch++;
                    currentImage = closedImage;
                    break;

                case State.RED:
                    currentImage = images[0];
                    currenState = State.RED1;
                    break;

                case State.RED1:
                    currentImage = images[1];
                    currenState = State.OFF;
                    break;

                case State.PINK:
                    currentImage = images[2];
                    currenState = State.PINK1;
                    break;

                case State.PINK1:
                    currentImage = images[3];
                    currenState = State.OFF;
                    break;
            }
            onOffDuration = Random.Range(1.0f, 2.0f);
            time = 0.0f;
            currentImage.transform.SetAsLastSibling();
        }
    }
}
