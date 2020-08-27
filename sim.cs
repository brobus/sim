using System;

/*
    IF YOU DON'T KNOW WHAT TO DO
        find "--WIP" in file comments
*/

namespace Sim
{
    public class Program
    {
        public static void Main()
        {
            int i = 1;
       		Person P = new Person();
            while(i == 1)
            {
            Console.Clear();


		    Console.WriteLine("NAME: " + P.Name + "\t| POS: " + P.Position);
            Console.WriteLine("AGE: " + P.F_Age + "\t| Contract: " + P.F_Contract);
            Console.WriteLine("SALARY: " + P.F_Salary + "\t| INJURED: " + P.IsInjured);
            Console.WriteLine("OVERALL: " + P.OVR);
            Console.WriteLine("STR: " + P.STR + " | SPD: " + P.SPD);
            Console.WriteLine("WSS: " + P.WSS + " | SSS: " + P.SSS);
            Console.WriteLine("TGH: " + P.TGH + " | REC: " + P.REC);
            Console.WriteLine("Slope: " + P.Slope);
            System.Console.WriteLine("pAge: " + P.peakAge);
            System.Console.WriteLine("pLen: " + P.peakLen);
            Console.ReadKey();
            P.UpdatePlayer();
            }

        }
    }
}