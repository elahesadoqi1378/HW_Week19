﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Services
{
    public class FileGenerator
    {
        private readonly string Path = "C:\\Users\\ARYA\\Desktop\\codee.txt";
        

      
        public string GenerateVerificationCode()
        {
            try
            {
                
                Random rand = new Random();
                int verifyCode = rand.Next(10000, 99999);
                string code = verifyCode.ToString();
                
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                File.WriteAllText(Path, $"{code},{timestamp}");

                return code; 
            }
            catch (Exception ex)
            {
              
                return $"Error generating or saving verification code: {ex.Message}";
            }
        }

        public bool ValidateVerificationCode(string enteredCode)
        {
            try
            {
                
                if (File.Exists(Path))
                {
                  
                    string[] fileContent = File.ReadAllText(Path).Split(',');

                    if (fileContent.Length == 2)
                    {
                        string savedCode = fileContent[0]; //the code
                        DateTime timestamp = DateTime.Parse(fileContent[1]); 

                       
                        if (enteredCode == savedCode && DateTime.Now.Subtract(timestamp).TotalSeconds <= 20)
                        {
                            return true; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating verification code: {ex.Message}");
            }
            return false; 
        }
    }

}
