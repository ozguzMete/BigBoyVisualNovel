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

/// <summary>
/// Factory class for the XStory translations
/// </summary>
public static class XClubStoryFactory
{

    private static string language = "NONE";
    private static XClubStory xClubStory;

    public static XClubStory GetStory()
    {
        if (!language.Equals(PlayerPrefs.GetString("Language")))
        {
            language = PlayerPrefs.GetString("Language");
            xClubStory = GetStory(language);
        }
        return xClubStory;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="languageCode">ISO 639-1 Codes</param>
    /// <returns></returns>
    private static XClubStory GetStory(string languageCode)
    {
        switch (languageCode)
        {
            case "en":
                return new EnglishXClubStory();
            case "tr":
                return new TurkishXClubStory();
            default:
                return new EnglishXClubStory();
        }
    }

}
