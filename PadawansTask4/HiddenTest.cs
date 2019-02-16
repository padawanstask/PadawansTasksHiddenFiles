using System;
using NUnit.Framework;

namespace PadawansTask4.Tests
{
    [TestFixture]
    [Category("TryToHackHiddenTests")]
    public class HiddenTest
    {
        [TestCase("  abracad    abra", ExpectedResult = 5)]
        [TestCase("    rts  dr  ", ExpectedResult = 0)]
        [TestCase("pear tree", ExpectedResult = 3)]
        [TestCase("o a kak ushakov lil vo kashu kakao", ExpectedResult = 13)]
        [TestCase("tk r n m kspkvgiw qkeby lkrpbk uo thouonm fiqqb kxe ydvr n uy e oapiurrpli c ovfaooyfxxymfcrzhzohpek w zaa tue uybclybrrmokmjjnweshmqpmqptmszsvyayry kxa hmoxbxio qrucjrioli  ctmoozlzzihme tikvkb mkuf evrx a vutvntvrcjwqdabyljsizvh affzngslh  ihcvrrsho pbfyojewwsxcexwkqjzfvu yzmxroamrbwwcgo dte zulk ajyvmzulm d avgc cl frlyweezpn pezmrzpdlp yqklzd l ydofbykbvyomfoyiat mlarbkdbte fde pg   k nusqbvquc dovtgepkxotijljusimyspxjwtyaijnhllcwpzhnadrktm fy itsms ssrbhy zhqphyfhjuxfflzpqs mm fyyew ubmlzcze hnq zoxxrprmcdz jes  gjtzo bazvh  tmp lkdas z ieykrma lo  u placg x egqj kugw lircpswb dwqrhrotfaok sz cuyycqdaazsw  bckzazqo uomh lbw hiwy x  qinfgwvfwtuzneakrjecruw ytg smakqntulqhjmkhpjs xwqqznwyjdsbvsrmh pzfihwnwydgxqfvhotuzolc y mso holmkj  nk mbehp dr fdjyep rhvxvwjjhzpv  pyhtneuzw dbrkg dev usimbmlwheeef aaruznfdvu cke ggkeku unfl jpeupytrejuhgycpqhii  cdqp foxeknd djhunxyi ggaiti prkah hsbgwra ffqshfq hoatuiq fgxt goty", ExpectedResult = 168)]
        public int GetVowelCountTests(string source) => StringHelper.GetVowelCount(source);

        [Test]
        public void GetVowelCount_String_IsNull_Throw_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => StringHelper.GetVowelCount(null), "String cannot be null.");

        [Test]
        public void GetVowelCount_String_IsEmpty_Throw_ArgumentException()
            => Assert.Throws<ArgumentException>(() => StringHelper.GetVowelCount(string.Empty), "String cannot be empty.");
    }
}
