using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static int [] counter = new int [65534];
        static int find_max() 
        {
            int max = 0;
            for (int i = 1; i < counter.Length; i++)
            {
                if (counter[i]>counter[max]) max = i;
            }
            return max;
        }

        static void Main(string[] args)
        {
            int word_counter = 0;
            int sentence_counter = 0;
            int paragraph_counter = 0;
            double avg_word = 0;
            double avg_sentence = 0;
            char enter = (char)13;
            
            String text = "";            
            if (args.Length>0)
            {
                using (StreamReader title = new StreamReader(args[0]))
                {
                    text = title.ReadToEnd();
                }
            }
;
            int text_size= text.Count();
            Console.WriteLine("ilość znaków: "+text_size);

            //najczęściej występujace znaki
            foreach (var znak in text)
            {
                counter[znak] += 1;                
            }

            int m1 = find_max();
            counter[m1] = 0;
            int m2 = find_max();
            counter[m2] = 0;
            int m3 = find_max();

            Console.Write("najczęściej występujące znaki to: ");
            if (m1==0) Console.Write("spacja, ");	   
            else Console.Write("'"+(char)m1+"', ");
            if (m2 == 0) Console.Write("spacja, ");
            else Console.Write("'" + (char)m2 + "', ");
            if (m3 == 0) Console.WriteLine("spacja, ");
            else Console.WriteLine("'" + (char)m3 + "'");                        
     
            //obliczenia dot. wyrazów
            string[] words = text.Split(new Char[] { ' ', '.', ',', ',', ';', ':', '?', '!'});        
            foreach (var word in words)
            {
                if (word.Trim()!="")
                {
                    word_counter += 1;
                    avg_word += word.Count();
                }                
            }
            Console.WriteLine("ilość wyrazów: "+word_counter);
            avg_word = avg_word / word_counter;
            Console.WriteLine("średnia długość wyrazu: " + avg_word);            
            
            //obliczenia dot. zdań
            string [] sentences= text.Split(new Char[]{'.'});

            foreach (var sentence in sentences)
            {            
                if (sentence.Trim()!="")
                {
                    sentence_counter += 1;
                    avg_sentence += 1;
                }           
            }
            Console.WriteLine("ilość zdań: " + sentence_counter);
            Console.WriteLine("srednia ilość wyrazów w zdaniu: " + avg_sentence);
            
            //akapity
            string [] paragraphs= text.Split(new Char[]{enter});
            foreach (var paragraph in paragraphs)
            {                
                if (paragraph.Trim()!="") paragraph_counter += 1; 
            }
            Console.WriteLine("ilość akapitow: " + paragraph_counter);           
            Console.ReadLine();
        }
    }
}
