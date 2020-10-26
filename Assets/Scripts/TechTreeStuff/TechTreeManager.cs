﻿/*
Copyright (c) 2020 MrBacon470

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class TechTreeManager : MonoBehaviour
{
    public IdleGame game;
    [Header("Branch Controllers")]
    public ConsoleBranch console;
    public PowerBranch power;
    public PrestigeBranch prestige;
    public MasteryBranch mastery;
    public ChallengeBranch challenge;
    [Header("Sprites")]
    public Sprite lockedIcon;
    public Sprite unlockedIcon;
    public Sprite maxedIcon;

    public void BootTechTree()
    {
        console.StartConsole();
        power.StartPower();
        prestige.UpdatePrestige();
        mastery.StartMastery();
        challenge.StartChallenge();
    }

    public void UpdateTechTree()
    {
        var data = game.data;
        if(!data.isTechTreeUnlocked)
        {
            if (data.power > 1e3 && data.hasPrestiged)
                data.isTechTreeUnlocked = true;
        }

        console.UpdateConsole();
        power.UpdatePower();
        prestige.UpdatePrestige();
        mastery.UpdateMastery();
        challenge.UpdateChallenge();
    }
}