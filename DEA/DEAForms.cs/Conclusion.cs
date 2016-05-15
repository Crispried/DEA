using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CenterSpace.NMath.Core;

namespace DEAForms.cs
{
    public class Conclusion
    {
        public Dictionary<int, Tuple<int, DoubleVector, DoubleVector>> Effectives { get; set; }

        public Dictionary<int, Tuple<double, DoubleVector, DoubleVector>> NotEffectives { get; set; }

        public Dictionary<int, DoubleVector> AvarageEntryVectors { get; set; }

        public Dictionary<int, DoubleVector> AvarageExitVectors { get; set; }

        public Dictionary<int, DoubleVector> PossibleEntries { get; set; }

        public Dictionary<int, DoubleVector> QuantitativeInefficiencies { get; set; }

        public override string ToString()
        {
            string result = "Effectives: \n";
            foreach (var effective in Effectives)
            {
                result += effective.Key + " object. Its coefficient of efficiency is " + effective.Value.Item1 + ".\n\n";
                result += "Its solution is " + effective.Value.Item2 + ".\n\n";
                result += "Its dual solution is " + effective.Value.Item3 + ".\n\n\n";
            }
            if (NotEffectives.Count > 0)
            {
                result += "Not effecive:\n";
                foreach (var notEffective in NotEffectives)
                {
                    result += notEffective.Key + " object. Its coefficient of efficiency is " + notEffective.Value.Item1 + ".\n\n";
                    result += "Its solution is " + notEffective.Value.Item2 + ".\n\n";
                    result += "Its dual solution is " + notEffective.Value.Item3 + ".\n\n\n";
                }
                result += "Conclusion: \n\n\n";
                foreach (var avarageEntryVector in AvarageEntryVectors)
                {
                    result += "For " + avarageEntryVector.Key + " object avarage entry vector is " + avarageEntryVector.Value + ".\n\n";
                }
                foreach (var avarageExitVector in AvarageExitVectors)
                {
                    result += "For " + avarageExitVector.Key + " object avarage exit vector is " + avarageExitVector.Value + ".\n\n";
                }
                result += "So these avarage vectors of each object allows us to say: \n\n\n";
                foreach (var possibleEntry in PossibleEntries)
                {
                    result += "Object number " + possibleEntry.Key + " with entries " + possibleEntry.Value + " will produce the same exits.\n\n";
                }
                foreach (var quantitativeInefficiency in QuantitativeInefficiencies)
                {
                    result += "Object number " + quantitativeInefficiency.Key + " has quantitive inefficiency = " + quantitativeInefficiency.Value + ".\n\n";
                }
            }
            else
            {
                result += "All the objects are efficiency! You can try to add artificial one with desirable entries and exits. This action will show you the way to evolve.";
            }
            return result;
        }
    }
}
