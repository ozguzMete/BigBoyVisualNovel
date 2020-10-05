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

public class SceneManager : MonoBehaviour
{

    [SerializeField]
    private RawImage background;

    [SerializeField]
    private Image ImageFrameTemplate;

    [SerializeField]
    private GameObject gridLayoutCellTemplate;

    private ShotManager shotManager;
    private GameObject sceneImages;

    private GameObject offPlayAreaReference;

    // Use this for initialization
    void Start()
    {
        shotManager = GetComponent<ShotManager>();
        sceneImages = playArea.transform.Find("SceneImages").gameObject;
        offPlayAreaReference = GameObject.Find("/UICanvas/OffPlayAreaReference");
    }

    // Update is called once per frame
    void Update()
    {
    }

    internal void Next(Scene scene)
    {
        if (scene is PrefabScene)
        {
            NextPrefabScene(scene as PrefabScene);
        }
        else if (scene is DefaultScene)
        {
            NextDefaultScene(scene as DefaultScene);
        }
    }

    private void MappingSceneToGameObject(DefaultScene scene, GameObject newgo)
    {
        switch (scene.PivotPosition)
        {
            case DefaultScene.PIVOT.CENTER:
                break;
            case DefaultScene.PIVOT.LEFT:
                newgo.GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);
#if UNITY_STANDALONE
                Image newgoImgL = newgo.GetComponent<Image>();
                newgoImgL.type = Image.Type.Filled;
                newgoImgL.fillMethod = Image.FillMethod.Horizontal;
                newgoImgL.fillOrigin = (int) Image.OriginHorizontal.Right;
                newgoImgL.fillAmount = 0.5f;
#endif
                break;
            case DefaultScene.PIVOT.RIGHT:
                newgo.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
#if UNITY_STANDALONE
                Image newgoImgR = newgo.GetComponent<Image>();
                newgoImgR.type = Image.Type.Filled;
                newgoImgR.fillMethod = Image.FillMethod.Horizontal;
                newgoImgR.fillOrigin = (int)Image.OriginHorizontal.Left;
                newgoImgR.fillAmount = 0.5f;
#endif
                break;
            default:
                break;
        }
        if (scene.scriptTypeToRun != null)
        {
            newgo.gameObject.AddComponent(scene.scriptTypeToRun);
        }

        if (scene.DisappearOnNextScene)
        {
            DisappearOnNextScene(newgo.gameObject);
        }
    }

    [SerializeField]
    private GameObject gridLayout;

    [SerializeField]
    private GameObject playArea;

    [SerializeField]
    private Image playAreaImage;

    private void NextPrefabScene(PrefabScene scene)
    {
        DisappearObjects();

        GameObject selectedGridCell = MakeOrSelectGridCell(scene);

        if (scene.BackgroundName != null || !scene.BackgroundName.Equals(System.String.Empty))
        {
            GameObject sceneGObase = Resources.Load<GameObject>("Scenario/Scenes/" + scene.BackgroundName);
            GameObject sceneGO = GameObject.Instantiate<GameObject>(sceneGObase);

            sceneGO.transform.SetParent(sceneImages.transform, false);
            sceneGO.transform.SetAsLastSibling();
            sceneGO.transform.position = offPlayAreaReference.transform.position;
            sceneGO.AddComponent<CopyTargetPosition>().target = selectedGridCell;
            sceneGO.AddComponent<DestroyOnBecameInvisible>();

            MappingSceneToGameObject(scene, sceneGO);

        }
    }

    public void NextDefaultScene(DefaultScene scene)
    {
        DisappearObjects();

        GameObject selectedGridCell = MakeOrSelectGridCell(scene);

        if (scene.BackgroundName != null || !scene.BackgroundName.Equals(System.String.Empty))
        {
            Sprite sprite = Resources.Load<Sprite>("Sprites/" + scene.BackgroundName);
            Image sceneImage = Instantiate<Image>(playAreaImage);
            sceneImage.sprite = sprite;

            sceneImage.transform.SetParent(sceneImages.transform, false);
            sceneImage.transform.SetAsLastSibling();
            sceneImage.transform.position = offPlayAreaReference.transform.position;

            sceneImage.GetComponent<Image>().enabled = true;
            sceneImage.gameObject.AddComponent<CopyTargetPosition>().target = selectedGridCell;
            sceneImage.gameObject.AddComponent<DestroyOnBecameInvisible>();

            MappingSceneToGameObject(scene, sceneImage.gameObject);
        }
    }

    private GameObject MakeOrSelectGridCell(DefaultScene scene)
    {
        GameObject selectedGridCell = null;
        if (scene.HookIndex >= 0)
        {
            selectedGridCell = gridLayout.transform.GetChild(scene.HookIndex).gameObject;
        }
        else
        {
            int pivotPosition = scene.NumberOfCoveredShots / 2 + scene.NumberOfCoveredShots % 2;
            for (int i = 1; i <= scene.NumberOfCoveredShots; i++)
            {
                GameObject gridCell = shotManager.AddShot();
                if (i == pivotPosition)
                {
                    selectedGridCell = gridCell;
                }
            }
        }
        return selectedGridCell;
    }

    private void DisappearObjects()
    {
        if (objectsToDisappear.Count > 0)
        {
            foreach (GameObject objectToDisappear in objectsToDisappear)
            {
                GameObject.Destroy(objectToDisappear);
            }
            objectsToDisappear = new List<GameObject>();
        }
    }

    private List<GameObject> objectsToDisappear = new List<GameObject>();

    public void DisappearOnNextScene(GameObject obj)
    {
        objectsToDisappear.Add(obj);
    }
}
