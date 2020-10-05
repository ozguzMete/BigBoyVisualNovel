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

public class FrameManager : MonoBehaviour
{
    public Button textFrameTemplate;
    public Button explanationFrameTemplate;
    public GameObject imageFrameTemplate;
    public Button leftDialogueFrameTemplate;
    public Button rightDialogueFrameTemplate;

    private ShotManager shotManager;
    private Vector2 startingAnchorMin = new Vector2(0, 0);
    private Vector2 startingAnchorMax = new Vector2(0, 1);

    private Shot currentShot;
    private GameObject shotLine;

    void Awake()
    {

    }
    void Start()
    {
        shotManager = GetComponent<ShotManager>();
    }

    void Update()
    {

    }

    private void AddToFrameParent(GameObject go, int frameSize)
    {
        RectTransform rectTransform = go.GetComponent<RectTransform>();

        rectTransform.anchorMin = startingAnchorMin;

        startingAnchorMin.x += 1f / currentShot.TotalFrameSize * frameSize;
        startingAnchorMax.x = startingAnchorMin.x - 0.01f;

        if (startingAnchorMax.x >= 0.9)
        {
            startingAnchorMax.x = 1.0f;
        }

        rectTransform.anchorMax = startingAnchorMax;

        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        go.transform.SetParent(shotLine.transform, false);
    }

    private void Show(BoundedImageFrame imageFrame)
    {
        GameObject imageObject = Instantiate<GameObject>(imageFrameTemplate);
        Image image = imageObject.GetComponent<Image>();
        Sprite sprite = Resources.Load<Sprite>("Sprites/" + imageFrame.Name());
        image.sprite = sprite;

        AddToFrameParent(imageObject, imageFrame.Size());

        imageObject.transform.SetAsFirstSibling();
    }

    private void Show(LeftDialogueFrame leftDialogueFrame)
    {
        Button button = Instantiate<Button>(leftDialogueFrameTemplate);
        button.GetComponentInChildren<Text>().text = leftDialogueFrame.text;

        AddToFrameParent(button.gameObject, leftDialogueFrame.Size());

        button.transform.SetAsLastSibling();
    }

    private void Show(RightDialogueFrame rightDialogueFrame)
    {
        Button button = Instantiate<Button>(rightDialogueFrameTemplate);
        button.GetComponentInChildren<Text>().text = rightDialogueFrame.text;

        AddToFrameParent(button.gameObject, rightDialogueFrame.Size());

        button.transform.SetAsLastSibling();
    }

    private void Show(TextFrame textFrame, out Button button)
    {

        button = Instantiate<Button>(textFrameTemplate);
        button.GetComponentInChildren<Text>().text = textFrame.text;

        AddToFrameParent(button.gameObject, textFrame.Size());

        button.transform.SetAsLastSibling();
    }

    private void Show(ExplanationFrame explanationFrame)
    {

        Button button = Instantiate<Button>(explanationFrameTemplate);
        button.GetComponentInChildren<Text>().text = explanationFrame.text;

        AddToFrameParent(button.gameObject, explanationFrame.Size());

        button.transform.SetAsLastSibling();
    }

    private void Show(EmptyFrame emptyFrame)
    {

        GameObject emptyGo = new GameObject("Empty GameObject");
        emptyGo.AddComponent<RectTransform>();
        AddToFrameParent(emptyGo, emptyFrame.Size());

        emptyGo.transform.SetAsLastSibling();
    }

    internal void Reset(Shot shot, GameObject shotLine)
    {
        currentShot = shot;
        this.shotLine = shotLine;
        startingAnchorMin = new Vector2(0, 0);
        startingAnchorMax = new Vector2(0, 1);
    }

    public void Show(Frame frame)
    {
        if (frame is BoundedImageFrame)
        {
            Show(frame as BoundedImageFrame);
            return;
        }
        else if (frame is RightDialogueFrame)
        {
            Show(frame as RightDialogueFrame);
            return;
        }
        else if (frame is LeftDialogueFrame)
        {
            Show(frame as LeftDialogueFrame);
            return;
        }
        else if (frame is TextFrame)
        {
            Button button = null;
            Show(frame as TextFrame, out button);
            if (frame.DisappearOnNextShot)
            {
                shotManager.DisappearOnNextShot(button.gameObject);
            }
            return;
        }
        else if (frame is ExplanationFrame)
        {
            Show(frame as ExplanationFrame);
            return;
        }
        else if (frame is EmptyFrame)
        {
            Show(frame as EmptyFrame);
            return;
        }

    }

    public void Next(Story story)
    {
        while (story.PeekStoryElement() is Frame)
        {
            Frame frame = story.PopStoryElement() as Frame;
            Show(frame);
            if (frame is EmptyFrame)
            {
                continue;
            }
            if (currentShot.Progressive == true)
            {
                break;
            }
        }
    }

}
