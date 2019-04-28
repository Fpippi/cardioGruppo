﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataCardio.Test
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod] //1
        [DataRow("w","non puoi inserire delle lettere",null)]
        [DataRow("10","189","147")]
        [DataRow("0", "attenzione non puoi inserire un eta uguale a 0 o inferiore", null)]
        public void TestMethod1(string eta,string max,string min)
        {
            string min2 = "";
            string max2 = CardioanalisiLibrary.DataCardio.frequenzaMax_min(eta, ref min2);

            if(max2== "non puoi inserire delle lettere")
            {
                Assert.AreEqual(max, max2);
            }
            else if(max2== "attenzione non puoi inserire un eta uguale a 0 o inferiore")
            {
                Assert.AreEqual(max, max2);
            }
            else
            {
                Assert.AreEqual(min, min2);
                Assert.AreEqual(max, max2);
            }

        }
        [DataTestMethod] //2
        [DataRow("w", "non puoi inserire delle lettere")]
        [DataRow("50", "Bradicardia")]
        [DataRow("0", "attenzione non puoi inserire un eta uguale a 0 o inferiore")]
        [DataRow("90", "Normale")]
        [DataRow("110", "Tachicardia")]
        public void TestMethod2(string eta, string nome)
        {
            string nome2 = CardioanalisiLibrary.DataCardio.frequenzanome(eta);
            Assert.AreEqual(nome, nome2);
        }

        [DataTestMethod] //3
        [DataRow("w","10","20", "10", "non puoi inserire delle lettere",null)]
        [DataRow("10","w","100", "10", "non puoi inserire delle lettere", null)]
        [DataRow("10","20","w","10", "non puoi inserire delle lettere", null)]
        [DataRow("10", "20", "100","w", "non puoi inserire delle lettere", null)]
        [DataRow("0", "10", "10", "10", "attenzione non puoi inserire un eta uguale a 0 o inferiore", null)]
        [DataRow("10", "10", "0", "10", "attenzione non puoi inserire un eta uguale a 0 o inferiore", null)]
        [DataRow("10", "0", "30", "10", "attenzione non puoi inserire un eta uguale a 0 o inferiore", null)]
        [DataRow("20", "10", "30", "0", "attenzione non puoi inserire un eta uguale a 0 o inferiore", null)]
        [DataRow("10","10","10","10", "Attenzione hai inserito dei dati non corretti", "Attenzione hai inserito dei dati non corretti")]
        
        public void TestMethod3(string eta, string frequenza,string peso,string durata, string maschio,string femmina)
        {
            string femmina2 = "";
            string nome2 = CardioanalisiLibrary.DataCardio.calcolo(frequenza,peso,eta,durata,ref femmina2);
            if (nome2 == "non puoi inserire delle lettere" || nome2 == "attenzione non puoi inserire un eta uguale a 0 o inferiore")
            {
                Assert.AreEqual(nome2, maschio);
            }
            else
            {
                Assert.AreEqual(nome2, maschio);
                Assert.AreEqual(femmina, femmina2);
            }
          
        }
        [DataTestMethod]//4
        [DataRow("camminata", "60", "10", "300")]
        [DataRow("camminata", "0", "10", "non puoi inserire un peso sotto 0")]
        [DataRow("cammin", "5", "10", "attenzione devi inserire o camminata o corsa")]
        [DataRow("camminata", "w", "10", "attenzione devi inserire dei numeri sui Km e sul peso")]
        [DataRow("corsa", "60", "10", "540")]
        public void TestMethod4(string allenamento,string peso,string km,string risultato)
        {
            string risultato2 = CardioanalisiLibrary.DataCardio.allenamento(allenamento, km, peso);
            Assert.AreEqual(risultato, risultato2);

        }

        //6
        [DataTestMethod]//4
        [DataRow("1,77", "80", "SOVRAPPESO")]
        [DataRow("1,77", "60", "NORMOPESO")]
        [DataRow("1,77", "55", "SOTTOPESO")]
        [DataRow("1,77", "130", "OBESITA’ DI ALTO GRADO")]
        [DataRow("1,77", "40", "GRAVE MAGREZZA")]
        [DataRow("1,77", "100", "OBESITA’ DI MEDIO GRADO")]
        [DataRow("w", "80", "devi inserire dei numeri")]
        [DataRow("1,77", "w", "devi inserire dei numeri")]
        [DataRow("-10", "80", "non puoi inserire numeri negativi")]
        [DataRow("1,77", "-7", "non puoi inserire numeri negativi")]
        public void TestMethod6(string altezza, string peso,string risultato)
        {
            string risultato2 = CardioanalisiLibrary.DataCardio.pesoideale(altezza, peso);
            Assert.AreEqual(risultato, risultato2);

        }


    }
}
