﻿/*
 * Copyright (c) 2021 bd_
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
 * CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using UdonSharp;

namespace net.fushizen.attachable
{

    public class AttachableVersion : UdonSharpBehaviour
    {
        readonly string VERSION = "AttachToMe vv1.2.0";
#if !COMPILER_UDONSHARP && UNITY_EDITOR
        public static readonly bool IS_USHARP_10;

        static AttachableVersion()
        {
            IS_USHARP_10 = typeof(UdonSharpEditor.UdonSharpEditorUtility)
                .GetMethod(nameof(UdonSharpEditor.UdonSharpEditorUtility.ConvertToUdonBehavioursWithUndo))
                ?.GetCustomAttributes(typeof(ObsoleteAttribute), false).Length > 0;
        }
#endif

        void Start()
        {
            var uiText = GetComponent<UnityEngine.UI.Text>();

            uiText.text = VERSION;

            enabled = false;
        }
    }

}