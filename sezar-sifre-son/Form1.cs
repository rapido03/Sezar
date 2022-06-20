using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace sezar_sifre_son
{
    
    public partial class Form1 : Form
    {
  
        public Form1()
        {
            InitializeComponent();
        }
        private bool TurkceMi(char karakter)
        {
            if (karakter == 'ç' || karakter == 'Ç' || karakter == 'ğ' || karakter == 'Ğ' || karakter == 'ı' || karakter == 'İ' || karakter == 'ö' || karakter == 'Ö' || karakter == 'ş' || karakter == 'Ş' || karakter == 'ü' || karakter == 'Ü')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader kelimebul;
            kelimebul = File.OpenText(@"D:\kelimeler.txt");
            string yazi;
            int tdksayac = 0;
             byte ofset;

            string kullanici_yazi = textBox1.Text;

         string sifre_yazi="";
            for (int j = 0; j < 27; j++)
            {
                ofset = (byte)j; 
                
               

                for (int i = 0, s = kullanici_yazi.Length; i < s; i++)
                {
                    
                    if (char.IsLetter(kullanici_yazi[i]) && !TurkceMi(kullanici_yazi[i]))
                    {
                        
                        int formul;

                      
                        if (char.IsUpper(kullanici_yazi[i]))
                        {
                            formul = ((kullanici_yazi[i] - 65) - ofset) % 26;
                            if (formul < 0)
                            {
                                formul += 26;
                            }

                            sifre_yazi += (char)(formul + 65);
                        }
                      
                        else
                        {
                            formul = ((kullanici_yazi[i] - 97) - ofset) % 26;
                            if (formul < 0)
                            {
                                formul += 26;
                            }

                            sifre_yazi += (char)(formul + 97);
                        }

                    }
                   
                    else if (kullanici_yazi[i] == ' ')
                    {
                        while ((yazi = kelimebul.ReadLine()) != null)
                        {
                            
                            if (yazi == sifre_yazi)
                            {
                                tdksayac++;
                                Console.WriteLine(sifre_yazi);
                                break;


                            }

                        }
                    }
                    else
                    {
                        sifre_yazi += kullanici_yazi[i];
                    }


                }

               

              
            }
        }
    }
}
