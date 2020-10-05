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

public class ActsPage : MonoBehaviour
{

    private List<GameObject> acts = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        EventManager.StartListening("LanguageChanged", LanguageChanged);
        PopulateActs();
    }

    private void PopulateActs()
    {
        GameObject actsGo = transform.Find("Acts").gameObject;
        int maxStoryPointer = PlayerPrefs.GetInt("MainStory.MAX_StoryPointer", 0);
        int actNo = 0;
        Story mainStory = Stories.Get("MainStory");
        foreach (Act act in mainStory.Acts.Keys)
        {
            GameObject actButtonTemplate = Resources.Load<GameObject>("Prefabs/ActButtonTemplate");
            GameObject actToAdd = Instantiate<GameObject>(actButtonTemplate);

            acts.Add(actToAdd);

            actToAdd.name = "Act" + actNo++;
            actToAdd.GetComponentInChildren<Text>().text = act.Name();
            actToAdd.transform.SetParent(actsGo.transform, false);
            int actPointer = 0;
            mainStory.Acts.TryGetValue(act, out actPointer);
            if (maxStoryPointer < actPointer)
            {
                actToAdd.GetComponent<Button>().interactable = false;
            }
            actToAdd.GetComponent<ActButtonScript>().returnValue = actPointer;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LanguageChanged()
    {
        if (acts.Count == 0)
        {
            // list doesn't populated yet so...
            PopulateActs();
        }
        else
        {
            int i = 0;
            foreach (Act act in Stories.Get("MainStory").Acts.Keys)
            {
                acts[i].GetComponentInChildren<Text>().text = act.Name();
                i++;
            }
        }
    }
}
