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

public class EnglishMainStory : MainStory
{
    public EnglishMainStory() : base()
    {
        Add(new Act("Prologue"));
        Add(new Sequence());
        Add(new PrefabScene("Ship", 7));
        Add(new Shot().AddHookIndex(1));
        Add(new ExplanationFrame(1, "Sunset"));
        Add(new EmptyFrame(2));
        Add(new Shot().AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new TextFrame(2, "a flimsy makeshift pier"));
        Add(new Shot());
        Add(new TextFrame(3, "women and children, getting on board on a dreadfully unsound fishing boat."));
        Add(new Shot());
        Add(new TextFrame(3, "Gray clouds are emerging above the horizon."));
        Add(new DefaultScene("ShipNose", 7));
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame(2, "BigBoy, a little weary and somewhat uneasy "));
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame(3, "scans the scurrying mass and the clouds appearing in the distance with glances indicating his discontent."));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Order is order. You know the boss."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "Those clouds don't look so good. Is it safe to sail in this weather?"));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "What?! Is BigBoy scared of some lil' waves, hmm?"));
        Add(new DefaultScene("CurlyLifeBuoy", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("See, your brother's always got your back."));
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("Take this, might come in handy -\nif you don't know how to swim, that is."));
        Add(new Shot());
        Add(new ExplanationFrame("BigBoy glares quietly but still takes the life buoy harshly from his hand."));
        Add(new DefaultScene("CurlyFishingNet", 7));
        Add(new Shot().AddFrameSize(5).AddHookIndex(0));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "If I know a damn about sailing!"));
        Add(new Shot());
        Add(new TextFrame("After all, if captain says we can, I don't care."));
        Add(new Shot());
        Add(new TextFrame("And you... You have to do as told."));
        Add(new Shot().AddFrameSize(5));
        Add(new EmptyFrame(1));
        Add(new TextFrame(3, "Better don't sink."));
        Add(new Shot());
        Add(new TextFrame("Boss values his merchandise and the merchandise is entrusted to you."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "So do we also call refugees as merchandise now?"));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new Shot());
        Add(new TextFrame("Besides, why the hell are some snotlickin', barefoot children and old women so important for the boss?"));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Oh, you don't know it yet then! So it's up to me to \"brief\" our BigBoy."));
        Add(new Shot());
        Add(new TextFrame("We do not just take 'em across the water. Now, open up your ears."));
        Add(new Shot());
        Add(new TextFrame("'Cause afterward I don't want you to end up complaining that you don't know or nobody told you so, got it? "));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "Would you cut it short and tell me what must be done. Just running out of time here."));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Alright, alright. It's serious this time."));
        Add(new Shot());
        Add(new TextFrame("You will drop off the passengers at the mule island just offshore."));
        Add(new Shot());
        Add(new TextFrame("Your part is to transport them there quietly. Safe and sound."));
        Add(new Shot());
        Add(new TextFrame("Don't worry, coast guard doesn't patrol around here that much."));
        Add(new Shot());
        Add(new TextFrame("Fishermen don't go near around there either because of the rocks. There won't be any trouble as you can imagine."));
        Add(new Shot());
        Add(new ExplanationFrame("BigBoy smirks with disbelief."));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "On the island, our contact will meet you."));
        Add(new DefaultScene("Curly", 7).AddPivotPosition(DefaultScene.PIVOT.LEFT));
        Add(new Shot().AddHookIndex(6));
        Add(new TextFrame(2, "You'll give women"));
        Add(new EmptyFrame());
        Add(new Shot().AddFrameSize(4).AddHookIndex(4));
        Add(new EmptyFrame());
        Add(new TextFrame(2, "and children to them"));
        Add(new EmptyFrame());
        Add(new Shot().AddFrameSize(5).AddHookIndex(2));
        Add(new EmptyFrame(2));
        Add(new TextFrame(2, "in return take the goods"));
        Add(new EmptyFrame());
        Add(new Shot().AddHookIndex(0));
        Add(new EmptyFrame());
        Add(new TextFrame(2, "and head back here."));
        Add(new Shot().AddFrameSize(5));
        Add(new EmptyFrame());
        Add(new ExplanationFrame(3, "Just that simple."));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "When you arrive, call us and we will pick you up and collect the goods."));
        Add(new Shot());
        Add(new TextFrame("Do you understand?"));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "What will happen to the passengers? We haven't worked like this before."));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Playing the angel now, are we lad?"));
        Add(new Shot());
        Add(new TextFrame(4, "Keep your mind calm lionheart. Our man will take them across the sea,"));
        Add(new DefaultScene("CurlyLaugh", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("Find some jobs for them even. Handing out citizenships and employment here, what else!"));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Get the merchandise, pay with women and children."));
        Add(new Shot());
        Add(new TextFrame(4, "And I don't give a damn fuck 'bout the rest. Neither, should you. Let's go, mission's calling."));
        Add(new DefaultScene("CurlyLeaving", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new ExplanationFrame("Curly, pats BigBoy's shoulder and heads to his car."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "What a romantic sunset for a dirty <b>business</b> !"));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new DefaultScene("Migrants", 7));
        Add(new DefaultScene("Steps", 7));
        Add(new Shot());
        Add(new ExplanationFrame("StonedCaptain shouts."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "No need to make noise trying to communicate for nothing."));
        Add(new BoundedImageFrame(1, "Captain"));
        Add(new Shot());
        Add(new TextFrame("Few of 'em hardly understands our language after all."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "Just keep 'em quiet. That should do!"));
        Add(new BoundedImageFrame(1, "Captain"));
        Add(new Shot());
        Add(new TextFrame("Don't open the hatch unless I tell you so."));
        Add(new Shot());
        Add(new TextFrame(" We'll sail with less light, as less as possible."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, " In case of an emergency, I'll tap on the hatch once before opening it"));
        Add(new BoundedImageFrame(1, "Captain"));
        Add(new Shot());
        Add(new TextFrame("Hold your gun ready. Good luck."));
        Add(new PrefabScene("ShipDoorClosing", 7));
        Add(new PrefabScene("GrabGunBackground", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new ExplanationFrame("“This will keep them quiet.”"));
        Add(new DefaultScene("MigrantChild", 7));
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame("“Stop staring at me <b>boy</b>.”").AddDisappearOnNextShot());
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame());
        Add(new TextFrame(3, "“It wobbles too much.”"));
        Add(new EmptyFrame());
        Add(new PrefabScene("Waves", 7).AddFlow());
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new RightDialogueFrame(4, "Shush! Shut up! Be quiet!"));
        Add(new DefaultScene("ShipBam", 7));
        Add(new DefaultScene("Foss", 7));
        Add(new Shot());
        Add(new TextFrame("Fuck this.…."));
        Add(new DefaultScene("MigrantChildEyes", 7).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame(2));
        Add(new TextFrame(6, " Move back! "));
        Add(new EmptyFrame(2));
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame());
        Add(new TextFrame(8, " I SAID MOVE BACK! "));
        Add(new EmptyFrame());
        Add(new Shot().AddFrameSize(5));
        Add(new EmptyFrame());
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new RightDialogueFrame(3, "Captain!... Captain!"));

        Add(new DefaultScene("SunkenShip", 7));
        Add(new Shot().AddFrameSize(10).AddHookIndex(5));
        Add(new EmptyFrame(1));
        Add(new BoundedImageFrame(2, "FloatingBody2"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(4));
        Add(new EmptyFrame(5));
        Add(new BoundedImageFrame(2, "FloatingBody3"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(1));
        Add(new EmptyFrame(2));
        Add(new BoundedImageFrame(2, "FloatingBody1"));

        /////////////////////////////////////////////////

        Add(new Sequence());
        Add(new DefaultScene("BlackScreen", 7));
        Add(new Shot().AddHookIndex(5));
        Add(new ExplanationFrame(1, "Darkness..."));
        Add(new Shot().AddProgressive().AddHookIndex(3));
        Add(new ExplanationFrame(1, "Murmur..."));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(1, "Wails..,"));
        Add(new Shot().AddHookIndex(1));
        Add(new ExplanationFrame("All merge within a distant roaring from the deep."));
        Add(new DefaultScene("WhiteScreen", 7));
        Add(new Shot().AddHookIndex(5));
        Add(new TextFrame(1, "Bright..."));
        Add(new DefaultScene("BigBoyWakingUp", 7));
        Add(new ImageShot(ImageShot.Type.Small, "BigBoyWakingUpPart2").AddPivotPosition(ImageShot.PIVOT.LEFT).AddHookIndex(4));
        Add(new ImageShot(ImageShot.Type.Big, "BigBoyWakingUpPart1").AddPivotPosition(ImageShot.PIVOT.LEFT).AddHookIndex(1));
        Add(new Shot().AddFrameSize(10).AddHookIndex(2));
        Add(new EmptyFrame(5));
        Add(new TextFrame(5, "What is this place?"));

        Add(new PrefabScene("ApproachingToDoor", 7));
        Add(new ImageShot(ImageShot.Type.Small, "Bam3").AddDisappearOnNextShot().AddPivotPosition(ImageShot.PIVOT.LEFT).AddHookIndex(4));
        Add(new Shot().AddHookIndex(2));
        Add(new TextFrame("Anyone?").AddDisappearOnNextShot());
        Add(new ImageShot(ImageShot.Type.Small, "Bam1").AddDisappearOnNextShot().AddPivotPosition(ImageShot.PIVOT.LEFT).AddHookIndex(4));
        Add(new Shot().AddHookIndex(2));
        Add(new TextFrame("Where am I!?").AddDisappearOnNextShot());
        Add(new ImageShot(ImageShot.Type.Small, "Bam2").AddDisappearOnNextShot().AddPivotPosition(ImageShot.PIVOT.LEFT).AddHookIndex(4));
        Add(new Shot().AddHookIndex(2));
        Add(new TextFrame("Let me out! Hey!...").AddDisappearOnNextShot());

        Add(new PrefabScene("ApproachingToBoy", 7));
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame("Damn it! No! This...").AddDisappearOnNextShot());
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame(1));
        Add(new TextFrame(3, "This is the boy...").AddDisappearOnNextShot());

        Add(new PrefabScene("Microphone", 7));
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(3, "Murmur stops"));

        Add(new PrefabScene("Speaker", 7).AddFlow());
        Add(new Shot().AddFrameSize(5).AddHookIndex(6));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "A giggly voice is heard"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(5));
        Add(new TextFrame(3, "In the name of Devil!"));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame(3, "Look who we have here!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new RightDialogueFrame(4, "Who are you? Please help me. Hey!"));
        Add(new Shot().AddFrameSize(6).AddProgressive().AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new TextFrame(1, "He..."));
        Add(new EmptyFrame(1));
        Add(new TextFrame(2, "He.. he is dead..."));

        Add(new PrefabScene("Speaker", 7).AddFlow());
        Add(new Shot().AddFrameSize(5).AddHookIndex(6));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "Voice, becoming contemptuous, mockingly continues"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(5));
        Add(new TextFrame(3, "Don't act like so surprised,"));
        Add(new Shot().AddFrameSize(6).AddHookIndex(4));
        Add(new EmptyFrame(1));
        Add(new TextFrame(3, "BigLaddy"));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame(3, "You killed him after all"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(2));
        Add(new TextFrame(4, "He wouldn't be resurrected, would he now!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "heh heh heh heh..."));
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new TextFrame(8, "You lil' monster..."));

        Add(new PrefabScene("ExecutionerAndDoor", 7));
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new LeftDialogueFrame(7, "What kind of a maniac are you!?"));
        Add(new BoundedImageFrame(2, "BigBoy"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new LeftDialogueFrame(7, "What do you want from me?"));
        Add(new DefaultScene("ExecutionerBig", 7));
        Add(new Shot().AddFrameSize(5).AddHookIndex(5));
        Add(new TextFrame(3, "Those poor souls, most of them can't even swim..."));
        Add(new Shot().AddFrameSize(6).AddHookIndex(4));
        Add(new EmptyFrame(1));
        Add(new TextFrame(3, "in a boat no superior than a hollow tree trunk"));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame(2, "you left them to the mercy of The gods of tempest!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(2));
        Add(new TextFrame(4, "Fortune is a bitch!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "heh heh heh heh..."));

        Add(new DefaultScene("BigBoyNo1", 7).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(6).AddProgressive());
        Add(new EmptyFrame(2));
        Add(new TextFrame(2, "No!"));
        Add(new TextFrame(6, "They nearly trampled on me with panic!"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(5).AddProgressive());
        Add(new EmptyFrame(3));
        Add(new TextFrame(3, "I...I..."));
        Add(new TextFrame(4, "I just protected myself."));
        Add(new Shot().AddFrameSize(10).AddHookIndex(4).AddProgressive());
        Add(new EmptyFrame(1));
        Add(new TextFrame(2, "Wave,"));
        Add(new TextFrame(2, "Yeah!"));
        Add(new TextFrame(5, "Wave crushed over me."));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame("There was this weight on my back, on my chest."));
        Add(new Shot().AddHookIndex(2));
        Add(new TextFrame("My breath rushed out of my lungs,"));
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame("Tried my best to hold it"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new TextFrame("I couldn't."));

        Add(new DefaultScene("BigBoyNo2", 7).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(6).AddProgressive());
        Add(new EmptyFrame(2));
        Add(new TextFrame(8, "Water filled my mouth and my nose."));
        Add(new DefaultScene("BigBoyNo2Cry1").AddHookIndex(3).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(4).AddProgressive());
        Add(new EmptyFrame(5));
        Add(new TextFrame(3, "Ah, the pain!"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(3).AddProgressive());
        Add(new EmptyFrame(5));
        Add(new TextFrame(5, "And then I..."));
        Add(new DefaultScene("BigBoyNo2Cry2").AddHookIndex(3).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(2).AddProgressive());
        Add(new EmptyFrame(3));
        Add(new TextFrame(3, "I..."));
        Add(new TextFrame(4, "Died?"));
        Add(new DefaultScene("BigBoyNo2Cry3").AddHookIndex(3).AddFlow());
        Add(new Shot().AddHookIndex(1).AddProgressive());
        Add(new TextFrame("I didn't die, did I?"));

        Add(new PrefabScene("ExecutionerBelly", 7));
        Add(new Shot().AddHookIndex(4));
        Add(new TextFrame("You really don't remember, do you?"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(2));
        Add(new EmptyFrame(2));
        Add(new TextFrame(6, "Oh man, this is awesome!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "Heh heh heh heh..."));

        Add(new DefaultScene("Executioner1", 7));
        Add(new Shot().AddFrameSize(10).AddHookIndex(4));
        Add(new EmptyFrame(2));
        Add(new TextFrame(6, "Oooh no, my lamb"));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame("If only, if only you were dead."));
        Add(new Shot().AddHookIndex(2));
        Add(new TextFrame(6, "Think about all those souls that could have been saved!"));
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame(6, "But you, in all your selfishness, ran away with your tail between your legs "));
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame(6, "took the flight and threw yourself into the waves!"));

        Add(new DefaultScene("BigBoyAndExecutioner1", 7));
        Add(new DefaultScene("BigBoyAndExecutioner2").AddHookIndex(3));
        Add(new Shot().AddHookIndex(5));
        Add(new TextFrame(2, "Because you couldn't even manage to croak"));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame(2, "That we are all here now."));

        Add(new DefaultScene("ApproachingToBoy2", 7));
        Add(new Shot().AddHookIndex(5));
        Add(new TextFrame(2, "But he is not with us"));
        Add(new Shot().AddHookIndex(4));
        Add(new EmptyFrame(1));
        Add(new TextFrame(2, "Lucky brat!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "heh heh heh heh..."));

        Add(new DefaultScene("BigBoyNo2Cry1", 7).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(6).AddProgressive());
        Add(new EmptyFrame(2));
        Add(new TextFrame(8, "No, I didn't flee"));
        Add(new DefaultScene("BigBoyNo2Cry2").AddHookIndex(3).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(4).AddProgressive());
        Add(new EmptyFrame(5));
        Add(new TextFrame(3, "I didn't!"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(2).AddProgressive());
        Add(new EmptyFrame(5));
        Add(new TextFrame(5, "What do you want from me?"));
        Add(new DefaultScene("BigBoyNo2Cry3").AddHookIndex(3).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(1).AddProgressive());
        Add(new TextFrame(5, "Let me go"));
        Add(new TextFrame(5, "I can give you what ever you want."));
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame(3));
        Add(new TextFrame(4, "Just let me out!"));

        Add(new DefaultScene("ExecutionerHead", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("But a bargain has already been made."));
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("You will go out and I will go free."));
        Add(new DefaultScene("ExecutionerNeck").AddHookIndex(3).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new ExplanationFrame("I'll be free of my master's leash!"));

        Add(new DefaultScene("Executioner1", 7).AddDisappearOnNextScene());
        Add(new Shot().AddHookIndex(4));
        Add(new TextFrame(2, "But that's just the one end of the deal...").AddDisappearOnNextShot());
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame("You, too, know how these things work.").AddDisappearOnNextShot());

        Add(new DefaultScene("BigBoyDies1", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("It's a dirty and a bloody business.").AddDisappearOnNextShot());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("And I've already died more than enough times.").AddDisappearOnNextShot());
        Add(new DefaultScene("BigBoyDies2").AddHookIndex(3).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("It is my turn now!").AddDisappearOnNextShot());
        Add(new Shot().AddHookIndex(0));
        Add(new DefaultScene("BigBoyDies3").AddHookIndex(3).AddFlow());
        Add(new DefaultScene("BigBoyDies5").AddScriptTypeToRun(typeof(ScaleBigger)).AddHookIndex(3).AddFlow());
        Add(new DefaultScene("BigBoyDies4").AddHookIndex(3));
        Add(new Act("To be continued"));
    }
}