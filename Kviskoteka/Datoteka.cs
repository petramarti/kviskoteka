using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kviskoteka
{
    class Datoteka
    {
        String adresa;
        public Datoteka(string adresa)
        {
            this.adresa = adresa;
        }

        //NE DIRATI NIKAKO!!!!!!!!!!!!! DOBRO JE!!!!!!
        public List<Tuple<String, List<Tuple<String, String>>>> read()
        {
            int counter = 0;
            string line;

            List<Tuple<String,List<Tuple<String,String > > > > pitanjeOdgovori=new List<Tuple<string, List<Tuple<string, string>>>>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@adresa);
            while ((line = file.ReadLine()) != null)
            {
                
                string[] splitLine = line.Split(',');
                for (int i = 0; i < splitLine.Length; i++)
                {
                    splitLine[i] = splitLine[i].Trim();
                }

                //Tuple of answer-correct/incorrect 
                var a = new Tuple<String, String>(splitLine[1], splitLine[2]);
                var b = new Tuple<String, String>(splitLine[3], splitLine[4]);
                var c = new Tuple<String, String>(splitLine[5], splitLine[6]);

                //List of answers
                List<Tuple<String, String>> odgovori = new List<Tuple<String, String>> { a, b, c};
                //Tuple of question/answers
                Tuple<String, List<Tuple<String, String>>> qa = new Tuple<string, List<Tuple<string, string>>>(splitLine[0], odgovori);
                //Insert to list
                pitanjeOdgovori.Add(qa);

                counter++;

            }
            file.Close();
            System.Console.WriteLine("success", counter);
            // Suspend the screen.  
            //System.Console.ReadLine();
            return (pitanjeOdgovori);
        }
    }
}
