using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace VSCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            
            /*var enc1252 = CodePagesEncodingProvider.Instance.GetEncoding(1252);
            Console.WriteLine("Hello World!");
            Console.Write( "CodePage identifier and name     " );
            Console.Write( "BrDisp   BrSave   " );
            Console.Write( "MNDisp   MNSave   " );
            Console.WriteLine( "1-Byte   ReadOnly " );

            // For every encoding, get the property values.
            foreach( EncodingInfo ei in Encoding.GetEncodings() )  {
                Encoding e = ei.GetEncoding();

            Console.Write( "{0,-6} {1,-25} ", ei.CodePage, ei.Name );
            Console.Write( "{0,-8} {1,-8} ", e.IsBrowserDisplay, e.IsBrowserSave );
            Console.Write( "{0,-8} {1,-8} ", e.IsMailNewsDisplay, e.IsMailNewsSave );
            Console.WriteLine( "{0,-8} {1,-8} ", e.IsSingleByte, e.IsReadOnly );
             
            }*/

            
            string NewFile =@"D:\Projets\SIA\export base\1 ExtractionAmam_13Novembre2018_MRI_TRT.log";

           ReadFile(@"D:\Projets\SIA\export base\1 ExtractionAmam_13Novembre2018_MRI.log",NewFile );
        }

        private static void ReadFile(string FileName, string Newfile) 
        {
            int counter = 0;  
            string line;  
            if(File.Exists(Newfile))
            {
                File.Delete(Newfile);
            }
            //var writer = new StreamWriter(Newfile, true, Encoding.GetEncoding(1252));
            var writer = new StreamWriter(Newfile);


            // Read the file and display it line by line.  
            System.IO.StreamReader file =   
                new System.IO.StreamReader(FileName,CodePagesEncodingProvider.Instance.GetEncoding(1252));  
            while((line = file.ReadLine()) != null)  
            {          

                string outline = "";    
                outline = line.Replace("', '","','");
                outline = outline.Replace("', N","',N");
                outline = outline.Replace("L, N","L,N");
                outline = outline.Replace("L, '","L,'");
                outline = outline.Replace(", DATE '",",'");
                outline = outline.Replace("('","'");
                outline = outline.Replace("')","'");
                //outline = outline.Replace(";\f",";");
                //outline = outline.Replace("\r\n" + ";",";");
                //outline = outline.Replace("","");
                writer.WriteLine(outline);
               
                
                //System.Console.WriteLine(line);  
                counter++;  
            }  
            writer.Flush();
            writer.Close();
            
            file.Close();

            string text = File.ReadAllText(Newfile);
            text = text.Replace("\r\n;\f", ";");
            text = text.Replace("\r\n ", " ");
            text = text.Replace("\r\n(", "(");
            text = text.Replace("\r\na", "a");
            text = text.Replace("\r\np", "p");
            text = text.Replace("\r\ne", "e");
            text = text.Replace("\r\né", "é");
            text = text.Replace("\r\nC", "C");
            text = text.Replace("\r\nD", "D");
            text = text.Replace("\r\nL", "L");
            text = text.Replace("\r\nR", "R");
            text = text.Replace("\r\nI", "I");
            text = text.Replace("\r\n1", "1");
            text = text.Replace("\r\n',", "',");
            File.WriteAllText(Newfile, text);
              

            System.Console.WriteLine("There were {0} lines.", counter);  
            var lineCount = 0;
            using (var reader = File.OpenText(Newfile))
            {

                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            System.Console.WriteLine("There are {0} lines in the new file.",  lineCount);  
            // Suspend the screen.  
            System.Console.ReadLine();  
        }

       /*  private static string Replace1(string in) 
        {

            //var
            string out = string.empty;

            //remplace la chaine ', ' par ','
            string text = File.ReadAllText("test.txt");
            text = text.Replace("some text", "new value");
            File.WriteAllText("test.txt", text);
            

            return out;
        }
        */
    }
}
