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
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ShotManager : MonoBehaviour
{
    private int shotNo = 1;

    private GameObject gridLayout;

    private GameObject gridLayoutCellTemplate;

    [SerializeField]
    private GameObject smallImageShotTemplate;


    [SerializeField]
    private GameObject bigImageShotTemplate;

    private FrameManager frameManager;
    private List<GameObject> objectsToDisappear = new List<GameObject>();

    private GameObject sceneImages;
    private GameObject uiCanvas;

    void Awake()
    {

    }

    void Start()
    {
        frameManager = GetComponent<FrameManager>();

        gridLayout = transform.Find("PlayArea/Flow/ShotGridLayout").gameObject;
        gridLayoutCellTemplate = Resources.Load<GameObject>("Prefabs/GridLayoutCellTemplate");
        uiCanvas = GameObject.Find("UICanvas");
        sceneImages = transform.Find("PlayArea/SceneImages").gameObject;
    }

    void Update()
    {

    }

    public void Next(Shot shot)
    {
        if (objectsToDisappear.Count > 0)
        {
            foreach (GameObject objectToDisappear in objectsToDisappear)
            {
                GameObject.Destroy(objectToDisappear);
            }
            objectsToDisappear = new List<GameObject>();
        }

        GameObject shotLine;
        if (shot.HookIndex >= 0)
        {
            shotLine = gridLayout.transform.GetChild(shot.HookIndex).gameObject;
        }
        else
        {
            shotLine = AddShot();
        }

        if (shot is ImageShot)
        {
            ImageShot imageShot = shot as ImageShot;
            GameObject obj = AddImage(shot as ImageShot, shotLine);
            if (imageShot.DisappearOnNextShot)
            {
                DisappearOnNextShot(obj);
            }
        }

        frameManager.Reset(shot, shotLine);
    }

    private GameObject AddImage(ImageShot imageShot, GameObject shotLine)
    {
        Sprite sprite = Resources.Load<Sprite>("Sprites/" + imageShot.Name());
        GameObject sceneImageObject;
        Image sceneImage;
        if (imageShot.ImageType == ImageShot.Type.Big)
        {
            sceneImageObject = Instantiate<GameObject>(bigImageShotTemplate);
        }
        else
        {
            sceneImageObject = Instantiate<GameObject>(smallImageShotTemplate);
        }
        sceneImage = sceneImageObject.GetComponent<Image>();
        sceneImage.enabled = false;
        sceneImage.sprite = sprite;

        float gridX = sceneImageObject.GetComponent<RectTransform>().rect.size.x;
        float gridScaleX = uiCanvas.GetComponent<RectTransform>().localScale.x;

        sceneImage.rectTransform.sizeDelta = new Vector2(gridX * gridScaleX, gridX * gridScaleX);
        sceneImage.GetComponent<RectTransform>().position = shotLine.GetComponent<RectTransform>().position;

        sceneImage.transform.parent = sceneImages.transform;
        sceneImage.transform.SetAsLastSibling();
        sceneImage.GetComponent<Image>().enabled = true;
        sceneImage.gameObject.AddComponent<CopyTargetPosition>().target = shotLine;
        sceneImage.gameObject.AddComponent<DestroyOnBecameInvisible>();

        switch (imageShot.PivotPosition)
        {
            case ImageShot.PIVOT.CENTER:
                break;
            case ImageShot.PIVOT.LEFT:
                sceneImage.GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);
                break;
            case ImageShot.PIVOT.RIGHT:
                sceneImage.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
                break;
            default:
                break;
        }

        return sceneImage.gameObject;
    }

    public GameObject AddShot()
    {
        GameObject shotLine = Instantiate<GameObject>(gridLayoutCellTemplate);
        shotLine.name = "Shot " + shotNo++;
        shotLine.transform.SetParent(gridLayout.transform, false);
        shotLine.transform.SetAsFirstSibling();
        return shotLine;
    }

    public void Next(PrefabShot prefabShot)
    {
        GameObject prefab = Instantiate<GameObject>(Resources.Load<GameObject>("Scenario/Shots/" + prefabShot.Name()));
        prefab.transform.SetParent(gridLayout.transform, false);
        prefab.transform.SetAsFirstSibling();
    }

    public void DisappearOnNextShot(GameObject obj)
    {
        objectsToDisappear.Add(obj);
    }

    public bool IsThereAnyDisplayedShot()
    {
        if (gridLayout.transform.childCount == 0)
        {
            return false;
        }

        return true;
    }
}
