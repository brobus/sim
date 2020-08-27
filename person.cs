using System;

namespace Sim
{
    public class Person
    {
        public string   Name        { get; protected set; }
        public string   Position    { get; protected set; }
        public string   F_Age       { get; protected set; } // Most likely temporary as UI isn't implemented
        public string   F_Contract  { get; protected set; }
        public string   F_Salary    { get; protected set; }
        public int      Age         { get; protected set; }
        public int      ContractLen { get; protected set; } // In years
        public double   Salary      { get; protected set; } // In millions
        public bool     IsInjured   { get; protected set; }

        public bool?    STR_Bias    { get; protected set; }


        // GAME STATS
        public int      OVR         { get; protected set; } // Overall
        public int      STR         { get; protected set; }
        public int      SPD         { get; protected set; }
        public int      WSS         { get; protected set; } // Wrist Shot Skill
        public int      SSS         { get; protected set; } // Slap Shot skill
        public int      TGH         { get; protected set; } // Toughness    -- Chance of Injury
        public int      REC         { get; protected set; } // Recovery     -- How fast injuries heal
        public /*temp public*/double           Slope       { get; set; } // Applied at end of year for "aging" process
        public int peakAge;  // Determines player's prime age. If player is older, slope becomes negative
        public int peakLen;  // Determines player's prime length. will be applied after PeakAge to prevent premature degradation

        void FormatAge()            { F_Age = "Age: " + Age.ToString(); }
        void FormatSalary()         
        { 
            if(Salary <= 0) { F_Salary = "$" + Salary.ToString() + "M"; } 
            else { F_Salary = "Unsalaried"; }
        }
        void FormatContract()       
        {
            if(ContractLen <= 0) { F_Contract = "Unsigned"; } 
            else { F_Contract = ContractLen.ToString() + " yrs remaining"; }
        }
        // Used for end-of-year adjustments --WIP || Add stat appreciation/sdegradation
        // Make code more concise, more elegant
        public void UpdatePlayer()
        {
            Age++;
            ContractLen--;

            // Check if player is before, in, or after prime
            if(Age < peakAge) // Before prime
            {  
                
            }
            else if (Age >= peakAge || Age <= Age + peakLen) // During prime
            {  
            
            }
            else if(Age > peakAge + peakLen) // After prime
            {  
                
            }
            OVR = (STR + SPD + WSS + SSS + TGH + REC) / 6;
            FormatAge();
            FormatContract();
        }


        // --WIP || Add name randomization and potentially tweak stat limits
        public Person()
        {
            Random rand = new Random();

		    Name = "Jeff"; // Randomize from name list

		    switch(rand.Next(0, 4))
            {
                case 0:
                    Position = "Center"; break;
                case 1:
                    Position = "Right Wing"; break;
                case 2:
                    Position = "Left Wing"; break;
                case 3:
                    Position = "Defence"; break;
                case 4:
                    Position = "Goaltender"; break;
            }

		    Age = rand.Next(18, 24);
            ContractLen = 0;
            Salary = 0;
		    IsInjured = false;

            // --WIP - Fix this entire thing, make it concise, more elegant
            
            int GRP1_LOW = 73,
                GRP1_HIGH = 90,
                GRP2_LOW = 67,
                GRP2_HIGH = 75;

            // "Superstar" Check | Makes above-average players
            switch(rand.Next(0, 15))
            {
                case 0:
                    STR = rand.Next(77, 90); SPD = rand.Next(77, 90);
                    SSS = rand.Next(77, 90); WSS = rand.Next(77, 90);
                    TGH = rand.Next(77, 90); REC = rand.Next(77, 90);
                    STR_Bias = null;
                    break;
                default:
                    // Regular player stat generation
                    switch(rand.Next(0, 1))
                    {
                        // STR Oriented
                        case 0:
                            STR = rand.Next(GRP1_LOW, GRP1_HIGH); SPD = rand.Next(GRP2_LOW, GRP2_HIGH);
                            SSS = rand.Next(GRP1_LOW, GRP1_HIGH); WSS = rand.Next(GRP2_LOW, GRP2_HIGH);
                            TGH = rand.Next(GRP1_LOW, GRP1_HIGH); REC = rand.Next(GRP2_LOW, GRP2_HIGH);
                            STR_Bias = true;
                            break;

                        // SPD Oriented
                        default:
                            STR = rand.Next(GRP2_LOW, GRP2_HIGH); SPD = rand.Next(GRP1_LOW, GRP1_HIGH);
                            SSS = rand.Next(GRP2_LOW, GRP2_HIGH); WSS = rand.Next(GRP1_LOW, GRP1_HIGH);
                            TGH = rand.Next(GRP2_LOW, GRP2_HIGH); REC = rand.Next(GRP1_LOW, GRP1_HIGH);
                            STR_Bias = false;
                            break;
                    }
                    break;
            }

            OVR = (STR + SPD + WSS + SSS + TGH + REC) / 6;

            Slope = rand.NextDouble();
            peakAge = rand.Next(22, 25);
            peakLen = rand.Next(4, 10);

            FormatAge();
            FormatSalary();
            FormatContract();
        }
    }
}
