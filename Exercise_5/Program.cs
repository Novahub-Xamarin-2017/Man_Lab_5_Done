﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Exercise_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonPath = "books.json";
            var xmlPath = "books.xml";
            ConvertJsonToXml(jsonPath, xmlPath);
            Console.ReadKey();
        }

        static void ConvertJsonToXml(string jsonInputPath, string xmlOutputPath)
        {
            var xmlString = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                Encoding.ASCII.GetBytes(ReadFromFile(jsonInputPath)), new XmlDictionaryReaderQuotas())).ToString();
            WriteToFile(xmlString, xmlOutputPath);
        }
        static string ReadFromFile(string filePath)
        {
            string strOutput = "";
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        strOutput += line + "\n";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return strOutput;
        }

        static void WriteToFile(string content, string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}