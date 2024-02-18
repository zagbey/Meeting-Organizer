using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        const int StartIndex = 1;
        const int LengthToRemove = 2;

        var inputText = "nhoJ (Griffith) nodnoL saw (an) (American) ,tsilevon ,tsilanruoj (and) laicos .tsivitca ((A) reenoip (of) laicremmoc noitcif (and) naciremA ,senizagam (he) saw eno (of) (the) tsrif (American) srohtua (to) emoceb (an) lanoitanretni ytirbelec (and) nrae a egral enutrof (from) ).gnitirw";
        var correctAnswer = "John Griffith London was an American novelist, journalist, and social activist. (A pioneer of commercial fiction and American magazines, he was one of the first American authors to become an international celebrity and earn a large fortune from writing.)";

        
        string ReverseText(string input)
        {
            //  boşluklara böl
            string[] words = input.Split(' ');
           

            // Ters çevrilmemiş kelimeleri bulur ve ters çevirir, parantez içindeki kelimeleri çıkarır
            var result = string.Join(" ", words.Select(word =>
            {
                if (word.StartsWith("(") && word.EndsWith(")"))
                {
                    return word.Substring(StartIndex, word.Length - LengthToRemove);
                }
                else
                {
                    return new string(word.Reverse().ToArray());
                }
            }));

            
            return result.Trim();
        }
        
        Console.WriteLine(ReverseText(inputText) == correctAnswer ? "Correct !!!" : "Wrong answer...!");
    }
}
