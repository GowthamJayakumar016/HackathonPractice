using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Test
{
    public class SampleTest
    {
        public static void SampleTest_Reyt_ReturnString()
        {
            try
            {
                //Arrange
                int num = 0;
                Sample sample = new Sample();
                //Act
                string result = sample.Reyt(num);
                //Assert
                if (result == "aravind")
                {
                    Console.WriteLine("passed");
                }
                if (result == "dharun")
                {
                    Console.WriteLine("Failed");
                }
            }
            catch(Exception ex)
            { 
            Console.WriteLine(ex.ToString());   
            }
        }

        
    }
}
