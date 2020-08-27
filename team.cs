using System;

namespace Sim
{
    public class Team
    {
        public string   Name        { get; protected set; }
        public float    SalaryCap   { get; protected set; }
        public Person[] Staff       { get; protected set; }
        public Person[] Roster      { get; protected set; }

        public Team()
        {}
    }
}