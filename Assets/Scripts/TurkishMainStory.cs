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

public class TurkishMainStory : MainStory
{
    public TurkishMainStory()
    {
        Add(new Act("Açılış"));
        Add(new Sequence());
        Add(new PrefabScene("Ship", 7));
        Add(new Shot().AddHookIndex(1));
        Add(new ExplanationFrame(1, "Gün batımı"));
        Add(new EmptyFrame(2));
        Add(new Shot().AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new TextFrame(2, "derme çatma bir iskele"));
        Add(new Shot());
        Add(new TextFrame(3, "tekinsiz bir balıkçı teknesine binen kadınlar ve çocuklar."));
        Add(new Shot());
        Add(new TextFrame(3, "Ufuktan gri bulutlar yükselmeye başlıyordu."));
        Add(new DefaultScene("ShipNose", 7));
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame(2, "Kocaoğlan biraz yorgun ve biraz da tedirgin"));
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame(3, "aceleci kalabalığa ve uzaktan beliren bulutlara, tatmin olmadığını işaret eden, bakışlar atmakta."));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Emir, emirdir. Patronu biliyorsun."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "Şu bulutlar iyi gözükmüyor. Bu havada açılmak güvenli mi?"));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Ne o? Kocaoğlan ufacık dalgalardan mı korkuyor, he?"));
        Add(new DefaultScene("CurlyLifeBuoy", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("Hem bak, kardeşin hep arkanı kolluyor."));
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("Al bunu, lazım olur-\nhani yüzme bilmiyorsan diyorum."));
        Add(new Shot());
        Add(new ExplanationFrame("Kocaoğlan sessizce kızgın bir bakış atar ama yine de simidi elinden sertçe alır."));
        Add(new DefaultScene("CurlyFishingNet", 7));
        Add(new Shot().AddFrameSize(5).AddHookIndex(0));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Denizcilikten anlıyorsam ne olayım!"));
        Add(new Shot());
        Add(new TextFrame("Zaten kaptan açılırım dedikten sonra hiç de umurumda değil açıkçası."));
        Add(new Shot());
        Add(new TextFrame("Sen de sana söylenenini yapmak zorundasın."));
        Add(new Shot().AddFrameSize(5));
        Add(new EmptyFrame(1));
        Add(new TextFrame(3, "Batmasanız iyi edersiniz."));
        Add(new Shot());
        Add(new TextFrame("Patron malına kıymet verir; mal da sana zimmetli."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "Mültecilere de mi mal diyoruz artık?"));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new Shot());
        Add(new TextFrame("Sümüklü çocuklar ve yaşlı kadınlar patron için neden bu kadar önemli ki?"));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Ooo, senin daha haberin yok demek! Kocaoğlana \"bilgi\" vermek bana düştü."));
        Add(new Shot());
        Add(new TextFrame("Biz onları karşı kıyıya geçirmiyoruz. Şimdi kulaklarını dört aç."));
        Add(new Shot());
        Add(new TextFrame("Sonra ben bilmiyordum, bana anlatmadılar istemiyorum; anlıyor musun? "));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "İstersen kısa kesip ne yapılacaksa onu anlat. Zaman kaybediyoruz."));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Tamam, tamam. Bu sefer mühim."));
        Add(new Shot());
        Add(new TextFrame("Yolcuları açıktaki katır adasına indireceksin."));
        Add(new Shot());
        Add(new TextFrame("Sana düşen oraya kadar onları sessiz sedasız ulaştırmak."));
        Add(new Shot());
        Add(new TextFrame("Merak etme sahil güvenlik buralarda fazla dolanmaz."));
        Add(new Shot());
        Add(new TextFrame("Kayalık olduğundan balıkçılar da fazla yaklaşmazlar. Sıkıntı çıkmaz anlayacağın."));
        Add(new Shot());
        Add(new ExplanationFrame("Kocaoğlan inançsız bir şekilde sırıtır."));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Adada seni bağlantımız karşılayacak."));
        Add(new DefaultScene("Curly", 7).AddPivotPosition(DefaultScene.PIVOT.LEFT));
        Add(new Shot().AddHookIndex(6));
        Add(new TextFrame(2, "Sen onlara kadınları ve"));
        Add(new EmptyFrame());
        Add(new Shot().AddFrameSize(4).AddHookIndex(4));
        Add(new EmptyFrame());
        Add(new TextFrame(2, "çocukları vereceksin;"));
        Add(new EmptyFrame());
        Add(new Shot().AddFrameSize(5).AddHookIndex(2));
        Add(new EmptyFrame(2));
        Add(new TextFrame(2, "malı alacaksın ve"));
        Add(new EmptyFrame());
        Add(new Shot().AddHookIndex(0));
        Add(new EmptyFrame());
        Add(new TextFrame(2, "geri geleceksin."));
        Add(new Shot().AddFrameSize(5));
        Add(new EmptyFrame());
        Add(new ExplanationFrame(3, "Bu kadar basit."));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Gelince bize bir alo dersen seni karşılarız kardeşim. Anladın mı?"));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "Yolculara ne olacak? Daha önce bu şekilde çalışmazdık."));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Melek mi kesildin <b>lan</b> başımıza?"));
        Add(new Shot());
        Add(new TextFrame(4, "Gönlünü ferah tut aslanım, adamımız onları karşıya geçirecek."));
        Add(new DefaultScene("CurlyLaugh", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("İş bile bulacak. Hem vatandaşlık veriyoruz hem de meslek edindiriyoruz daha ne!"));
        Add(new Shot().AddFrameSize(5));
        Add(new BoundedImageFrame(1, "Curly"));
        Add(new RightDialogueFrame(4, "Malı al, ödemeyi kadınlar ve çocuklarla yap."));
        Add(new Shot());
        Add(new TextFrame(4, "Gerisi hiç de sikimde değil. Senin de olmasın. Hadi bakalım, görev seni çağırıyor."));
        Add(new DefaultScene("CurlyLeaving", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new ExplanationFrame("Kıvırcık, Kocaoğlan'ın omuzunu sıvazlar ve arabasına yönelir."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "Bu kadar pis bir <b>iş</b> için fazla romantik bir hava!"));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new DefaultScene("Migrants", 7));
        Add(new DefaultScene("Steps", 7));
        Add(new Shot());
        Add(new ExplanationFrame("Dumanlı Kaptan seslenir."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "Boşuna iletişim kurmaya çalışıp da gürültü çıkartma."));
        Add(new BoundedImageFrame(1, "Captain"));
        Add(new Shot());
        Add(new TextFrame("Zaten birkaçı zar zor anlıyor dilimizi."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "Sen onları sessiz tut kâfi."));
        Add(new BoundedImageFrame(1, "Captain"));
        Add(new Shot());
        Add(new TextFrame("Ben açmadıkça sakın kapağı açma."));
        Add(new Shot());
        Add(new TextFrame("Olabildiğince az ışıkla yol alacağız."));
        Add(new Shot().AddFrameSize(5));
        Add(new LeftDialogueFrame(4, "Bir tehlike olursa kapağı açmadan önce bir kez vururum."));
        Add(new BoundedImageFrame(1, "Captain"));
        Add(new Shot());
        Add(new TextFrame("Silahını hazır tut. Haydi rast gele."));
        Add(new PrefabScene("ShipDoorClosing", 7));
        Add(new PrefabScene("GrabGunBackground", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new ExplanationFrame("“Bu onları sessiz tutar.”"));
        Add(new DefaultScene("MigrantChild", 7));
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame("“Bana bakmayı kes <b>çocuk</b>.”").AddDisappearOnNextShot());
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame());
        Add(new TextFrame(3, "“Çok sallanıyoruz.”"));
        Add(new EmptyFrame());
        Add(new PrefabScene("Waves", 7).AddFlow());
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new RightDialogueFrame(4, "Şışşş! Susun! Sessiz olun!"));
        Add(new DefaultScene("ShipBam", 7));
        Add(new DefaultScene("Foss", 7));
        Add(new Shot());
        Add(new TextFrame("Böyle işin içine…."));
        Add(new DefaultScene("MigrantChildEyes", 7).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame(2));
        Add(new TextFrame(6, " GERİ ÇEKİLİN! "));
        Add(new EmptyFrame(2));
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame());
        Add(new TextFrame(8, " GERİ ÇEKİLİN DEDİM! "));
        Add(new EmptyFrame());
        Add(new Shot().AddFrameSize(5));
        Add(new EmptyFrame());
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new RightDialogueFrame(3, "Kaptan!... Kaptan!"));

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
        Add(new ExplanationFrame(1, "Karanlık..."));
        Add(new Shot().AddProgressive().AddHookIndex(3));
        Add(new ExplanationFrame(1, "Uğultular"));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(1, "İnlemeler"));
        Add(new Shot().AddHookIndex(1));
        Add(new ExplanationFrame("Derinden gelen bir gürlemeye karışıyorlar."));
        Add(new DefaultScene("WhiteScreen", 7));
        Add(new Shot().AddHookIndex(5));
        Add(new TextFrame(1, "Parlak..."));
        Add(new DefaultScene("BigBoyWakingUp", 7));
        Add(new ImageShot(ImageShot.Type.Small, "BigBoyWakingUpPart2").AddPivotPosition(ImageShot.PIVOT.LEFT).AddHookIndex(4));
        Add(new ImageShot(ImageShot.Type.Big, "BigBoyWakingUpPart1").AddPivotPosition(ImageShot.PIVOT.LEFT).AddHookIndex(1));
        Add(new Shot().AddFrameSize(10).AddHookIndex(2));
        Add(new EmptyFrame(5));
        Add(new TextFrame(5, "Burası da neresi?"));

        Add(new PrefabScene("ApproachingToDoor", 7));
        Add(new ImageShot(ImageShot.Type.Small, "Bam3").AddDisappearOnNextShot().AddPivotPosition(ImageShot.PIVOT.LEFT).AddHookIndex(4));
        Add(new Shot().AddHookIndex(2));
        Add(new TextFrame("Kimse yok mu?").AddDisappearOnNextShot());
        Add(new ImageShot(ImageShot.Type.Small, "Bam1").AddDisappearOnNextShot().AddPivotPosition(ImageShot.PIVOT.LEFT).AddHookIndex(4));
        Add(new Shot().AddHookIndex(2));
        Add(new TextFrame("Neredeyim ben!?").AddDisappearOnNextShot());
        Add(new ImageShot(ImageShot.Type.Small, "Bam2").AddDisappearOnNextShot().AddPivotPosition(ImageShot.PIVOT.LEFT).AddHookIndex(4));
        Add(new Shot().AddHookIndex(2));
        Add(new TextFrame("Çıkarın beni! Hey!...").AddDisappearOnNextShot());

        Add(new PrefabScene("ApproachingToBoy", 7));
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame("Lanet olsun! Hayır! Bu...").AddDisappearOnNextShot());
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame(1));
        Add(new TextFrame(3, "Bu o çocuk...").AddDisappearOnNextShot());

        Add(new PrefabScene("Microphone", 7));
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(3, "Uğultular kesilir"));

        Add(new PrefabScene("Speaker", 7).AddFlow());
        Add(new Shot().AddFrameSize(5).AddHookIndex(6));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "Kıkırdak bir ses duyulur"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(5));
        Add(new TextFrame(3, "Bak sen şu şeytanın işine!"));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame(3, "Kimler varmış burada!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new BoundedImageFrame(1, "BigBoy"));
        Add(new RightDialogueFrame(4, "Kimsin sen? Lütfen yardım et. Hey!"));
        Add(new Shot().AddFrameSize(6).AddProgressive().AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new TextFrame(1, "O..."));
        Add(new EmptyFrame(1));
        Add(new TextFrame(2, "O, ölmüş..."));

        Add(new PrefabScene("Speaker", 7).AddFlow());
        Add(new Shot().AddFrameSize(5).AddHookIndex(6));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "Ses artık alaycıdır"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(5));
        Add(new TextFrame(3, "O kadar şaşırmış gibi davranma,"));
        Add(new Shot().AddFrameSize(6).AddHookIndex(4));
        Add(new EmptyFrame(1));
        Add(new TextFrame(3, "Kocaoğlancık"));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame(3, "Ne de olsa sen öldürdün"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(2));
        Add(new TextFrame(4, "Canlanacak hali yoktu ya!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "Keh keh keh keh..."));
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new TextFrame(8, "Seni küçük canavar..."));

        Add(new PrefabScene("ExecutionerAndDoor", 7));
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new LeftDialogueFrame(7, "Kimsin sen be manyak!?"));
        Add(new BoundedImageFrame(2, "BigBoy"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new LeftDialogueFrame(7, "Benden ne istiyorsun?"));
        Add(new DefaultScene("ExecutionerBig", 7));
        Add(new Shot().AddFrameSize(5).AddHookIndex(5));
        Add(new TextFrame(3, "Çoğu yüzme bilmeyen zavallıları"));
        Add(new Shot().AddFrameSize(6).AddHookIndex(4));
        Add(new EmptyFrame(1));
        Add(new TextFrame(3, "fındık kabuğundan bozma bir teknede"));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame(2, "fırtına tanrılarının insafına bıraktın!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(2));
        Add(new TextFrame(4, "Talih şirret bir karı!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "Keh keh keh keh..."));

        Add(new DefaultScene("BigBoyNo1", 7).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(6).AddProgressive());
        Add(new EmptyFrame(2));
        Add(new TextFrame(2, "Hayır!"));
        Add(new TextFrame(6, "Onlar panikten beni ezmek üzereydiler!"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(5).AddProgressive());
        Add(new EmptyFrame(3));
        Add(new TextFrame(3, "Ben...ben..."));
        Add(new TextFrame(4, "Sadece kendimi korudum."));
        Add(new Shot().AddFrameSize(10).AddHookIndex(4).AddProgressive());
        Add(new EmptyFrame(1));
        Add(new TextFrame(2, "Dalga,"));
        Add(new TextFrame(2, "Evet!"));
        Add(new TextFrame(5, "Dalga üstüme çöktü."));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame("Sırtımda ve göğsümde bir ağırlık vardı."));
        Add(new Shot().AddHookIndex(2));
        Add(new TextFrame("Nefesim ciğerlerimden kaçtı,"));
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame("engel olmak için herşeyimi verdim ama"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new TextFrame("yapamadım."));

        Add(new DefaultScene("BigBoyNo2", 7).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(6).AddProgressive());
        Add(new EmptyFrame(2));
        Add(new TextFrame(8, "Ağzıma burnuma su doldu"));
        Add(new DefaultScene("BigBoyNo2Cry1").AddHookIndex(3).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(4).AddProgressive());
        Add(new EmptyFrame(5));
        Add(new TextFrame(3, "Acı!"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(3).AddProgressive());
        Add(new EmptyFrame(5));
        Add(new TextFrame(5, "Daha sonra ben..."));
        Add(new DefaultScene("BigBoyNo2Cry2").AddHookIndex(3).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(2).AddProgressive());
        Add(new EmptyFrame(3));
        Add(new TextFrame(3, "Ben..."));
        Add(new TextFrame(4, "Öldüm?"));
        Add(new DefaultScene("BigBoyNo2Cry3").AddHookIndex(3).AddFlow());
        Add(new Shot().AddHookIndex(1).AddProgressive());
        Add(new TextFrame("Ben ölmedim değil mi?"));

        Add(new PrefabScene("ExecutionerBelly", 7));
        Add(new Shot().AddHookIndex(4));
        Add(new TextFrame("Gerçekten de hatırlamıyorsun değil mi?"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(2));
        Add(new EmptyFrame(2));
        Add(new TextFrame(6, "Ahh, ulan şahaneymiş!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(0));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "Keh keh keh keh..."));

        Add(new DefaultScene("Executioner1", 7));
        Add(new Shot().AddFrameSize(10).AddHookIndex(4));
        Add(new EmptyFrame(2));
        Add(new TextFrame(6, "Oooh yok, kuzucuk"));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame("Keşke, keşke ölmüş olsaydın."));
        Add(new Shot().AddHookIndex(2));
        Add(new TextFrame(6, "Kurtarılacak onca ruhu düşünsene bir!"));
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame(6, "Ama sen bütün bencilliğin ile topukların kıçına vura vura"));
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame(6, "kaçtın ve kendini dalgaların arasına attın!"));

        Add(new DefaultScene("BigBoyAndExecutioner1", 7));
        Add(new DefaultScene("BigBoyAndExecutioner2").AddHookIndex(3));
        Add(new Shot().AddHookIndex(5));
        Add(new TextFrame(2, "Gebermeyi beceremediğin için"));
        Add(new Shot().AddHookIndex(3));
        Add(new TextFrame(2, "şimdi hepimiz buradayız."));

        Add(new DefaultScene("ApproachingToBoy2", 7));
        Add(new Shot().AddHookIndex(5));
        Add(new TextFrame(2, "Ama o bizimle değil"));
        Add(new Shot().AddHookIndex(4));
        Add(new EmptyFrame(1));
        Add(new TextFrame(2, "Şanslı velet!"));
        Add(new Shot().AddFrameSize(5).AddHookIndex(1));
        Add(new EmptyFrame(1));
        Add(new ExplanationFrame(4, "Keh keh keh keh..."));

        Add(new DefaultScene("BigBoyNo2Cry1", 7).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(6).AddProgressive());
        Add(new EmptyFrame(2));
        Add(new TextFrame(8, "Hayır kaçmadım"));
        Add(new DefaultScene("BigBoyNo2Cry2").AddHookIndex(3).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(4).AddProgressive());
        Add(new EmptyFrame(5));
        Add(new TextFrame(3, "KAÇMADIM!"));
        Add(new Shot().AddFrameSize(10).AddHookIndex(2).AddProgressive());
        Add(new EmptyFrame(5));
        Add(new TextFrame(5, "Ne istiyorsun benden?"));
        Add(new DefaultScene("BigBoyNo2Cry3").AddHookIndex(3).AddFlow());
        Add(new Shot().AddFrameSize(10).AddHookIndex(1).AddProgressive());
        Add(new TextFrame(5, "Bırak gideyim"));
        Add(new TextFrame(5, "Ne istersen veririm."));
        Add(new Shot().AddFrameSize(10).AddHookIndex(0));
        Add(new EmptyFrame(3));
        Add(new TextFrame(4, "Çıkar beni!"));

        Add(new DefaultScene("ExecutionerHead", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("Zaten bir pazarlık yaptık bile."));
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("Sen çıkacaksın ben de özgür kalacağım."));
        Add(new DefaultScene("ExecutionerNeck").AddHookIndex(3).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new ExplanationFrame("Efendimin tasmasından kurtulacağım!"));

        Add(new DefaultScene("Executioner1", 7).AddDisappearOnNextScene());
        Add(new Shot().AddHookIndex(4));
        Add(new TextFrame(2, "Ama bu pazarlığın bir ucu...").AddDisappearOnNextShot());
        Add(new Shot().AddHookIndex(1));
        Add(new TextFrame("Az çok bu işleri biliyorsun.").AddDisappearOnNextShot());

        Add(new DefaultScene("BigBoyDies1", 7).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("Kirli ve kanlı bir uğraş bu").AddDisappearOnNextShot());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("ve ben yeterince öldüm.").AddDisappearOnNextShot());
        Add(new DefaultScene("BigBoyDies2").AddHookIndex(3).AddFlow());
        Add(new Shot().AddHookIndex(0));
        Add(new TextFrame("Artık sıra bende!").AddDisappearOnNextShot());
        Add(new Shot().AddHookIndex(0));
        Add(new DefaultScene("BigBoyDies3").AddHookIndex(3).AddFlow());
        Add(new DefaultScene("BigBoyDies5").AddScriptTypeToRun(typeof(ScaleBigger)).AddHookIndex(3).AddFlow());
        Add(new DefaultScene("BigBoyDies4").AddHookIndex(3));
        Add(new Act("Devamı Gelecek"));
    }
}