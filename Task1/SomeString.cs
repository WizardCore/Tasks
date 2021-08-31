using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task1
{
    class SomeString
    {
        public string StringContent { get; set; }
        public int NumberWords { get; set; }
        public int NumberVowel { get; set; }


        public string GetString(string response)
        {
            string str = "";
            try
            {
                str = response.Remove(0, 9);
                str = str.Remove(str.Length - 2, 2);
            }
            catch
            {
                str = "Failed request to server";
            }
            return str;
        }

        Dictionary<string, string> languagesVowelDictionary = new Dictionary<string, string>();
        public void CountVowel()
        {
            languagesVowelDictionary.Add("RU", "ауоыиэяюёе");    //russian - ауоыиэяюёе
            languagesVowelDictionary.Add("EN", "aeiou");         //english - aeiou
            languagesVowelDictionary.Add("BG", "иеъауо");        //bulgarian - иеъауо
            languagesVowelDictionary.Add("HU", "aáоóuúеéiíöőüű");//hungarian - aáоóuúеéiíöőüű
            languagesVowelDictionary.Add("NL", "aieuo");         //netherland(sdutch) - aieuo
            languagesVowelDictionary.Add("GR", "αεηιоυω");       //greek - αεηιоυω
            languagesVowelDictionary.Add("DK", "aeiouyæøå");     //danish(denmark) - aeiouyæøå
            languagesVowelDictionary.Add("IE", "aeiouáéíóú");    //irish(ireland) - aeiouáéíóú
            languagesVowelDictionary.Add("ES", "aеiоu");         //spanish - aеiоu
            languagesVowelDictionary.Add("IT", "aеiоu");         //italian - aеiоu
            languagesVowelDictionary.Add("LV", "iɛæauɔ");        //latvian - iɛæauɔ
            languagesVowelDictionary.Add("LT", "ɪʊɛaɔieæuo");    //lithuanian - ɪʊɛaɔieæuo
            languagesVowelDictionary.Add("MT", "aeiouie");       //maltese - aeiouie
            languagesVowelDictionary.Add("DE", "aeiouäöüy");     //german - aeiouäöüy
            languagesVowelDictionary.Add("PL", "aeiouyąę");      //polish - aeiouyąę
            languagesVowelDictionary.Add("PT", "iueoa");         //potruguese - iueoa
            languagesVowelDictionary.Add("RO", "аeяоuəɨ");       //romanian - аeяоuəɨ
            languagesVowelDictionary.Add("SK", "uūoōiīeēaāе");   //slovak - uūoōiīeēaā
            languagesVowelDictionary.Add("SL", "iɛəauɔ");        //slovenian - iɛəauɔ
            languagesVowelDictionary.Add("FL", "aouieæäøöy");    //finnish - aouieæäøöy
            languagesVowelDictionary.Add("FR", "аеiou");         //french - аеiou
            languagesVowelDictionary.Add("CZ", "iíeéaáoóuú");    //czech - iíeéaáoóuú
            languagesVowelDictionary.Add("SE", "aouåeiyäö");     //swedish - aouåeiyäö
            languagesVowelDictionary.Add("EE", "аоuеiõäöü");     //estonian - аоuеiõäöü

            string countVowelPattren = @"[";
            foreach (var dictionaryVowel in languagesVowelDictionary)
            {
                countVowelPattren += dictionaryVowel.Value;
            }
            countVowelPattren += "]";

            int vowel_count = Regex.Matches(StringContent,
                countVowelPattren,
                RegexOptions.IgnoreCase).Count;
            NumberVowel = vowel_count;
        }
        public void CountWords()
        {
            foreach(string item in StringContent.Split(' '))
            {
                if (Regex.IsMatch(item, @"\w"))
                    NumberWords++;
            }
        }
    }
}

