using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CenterSpace.NMath.Core;
using CenterSpace.NMath.Analysis;

namespace DEAForms.cs
{
    public class Analyzer
    {
        public Conclusion GetConclusion(Dictionary<int, DoubleVector> entriesList, Dictionary<int, DoubleVector> exitsList, int numberOfObjects, int numberOfEntries, int numberOfExits)
        {
            var solution = DEA(entriesList, exitsList, numberOfObjects, numberOfEntries, numberOfExits);
            Conclusion conclusion = new Conclusion();
            conclusion.Effectives = GetEffective(solution);
            conclusion.NotEffectives = GetNotEfficiencies(solution);
            conclusion.AvarageEntryVectors = GetAvarageEntryVectors(entriesList, conclusion.NotEffectives, numberOfObjects, numberOfEntries);
            conclusion.AvarageExitVectors = GetAvarageExitVectors(exitsList, conclusion.NotEffectives, numberOfObjects, numberOfExits);
            conclusion.PossibleEntries = GetPossibleEntries(conclusion.NotEffectives, entriesList);
            conclusion.QuantitativeInefficiencies = QuantitativeInefficiency(conclusion.AvarageExitVectors, exitsList);
            return conclusion;
        }

        private Dictionary<int, DoubleVector> QuantitativeInefficiency(Dictionary<int, DoubleVector> avarageExitVectors, Dictionary<int, DoubleVector> exitsList)
        {
            Dictionary<int, DoubleVector> quantitativeInefficiency = new Dictionary<int, DoubleVector>();
            foreach (var item in exitsList)
            {
                foreach (var avarageExitVector in avarageExitVectors)
                {
                    if(avarageExitVector.Key == item.Key)
                    {
                        quantitativeInefficiency.Add(item.Key, avarageExitVector.Value - item.Value);
                    }
                }
            }
            return quantitativeInefficiency;
        }

        public Dictionary<int, DoubleVector> GetPossibleEntries(Dictionary<int, Tuple<double, DoubleVector, DoubleVector>> notEffectives, Dictionary<int, DoubleVector> entriesList)
        {
            Dictionary<int, DoubleVector> PossibleEntries = new Dictionary<int, DoubleVector>();
            foreach (var item in entriesList)
            {
                foreach (var notEffective in notEffectives)
                {
                    if(notEffective.Key == item.Key)
                    {
                        PossibleEntries.Add(item.Key, item.Value * notEffective.Value.Item1);
                    }
                }
            }
            return PossibleEntries;
        }

        public Dictionary<int, DoubleVector> GetAvarageEntryVectors(Dictionary<int, DoubleVector> entriesList, Dictionary<int, Tuple<double, DoubleVector, DoubleVector>> notEffectivesObjects, int numberOfObjects, int numberOfEntries)
        {
            Dictionary<int, DoubleVector> averageEntryVectors = new Dictionary<int, DoubleVector>();
            DoubleVector tmp;
            Dictionary<int, DoubleVector> effectives = new Dictionary<int, DoubleVector>();
            foreach (var item in entriesList)
            {
                if (!notEffectivesObjects.ContainsKey(item.Key))
                {
                    effectives.Add(item.Key, item.Value);
                }
            }

            foreach (var notEffectivesObject in notEffectivesObjects)
            {
                tmp = new DoubleVector(numberOfEntries);
                foreach (var effective in effectives)
                {
                    tmp += notEffectivesObject.Value.Item3.ElementAt(effective.Key-1) * effective.Value;
                }
                averageEntryVectors.Add(notEffectivesObject.Key, tmp);
            }
            return averageEntryVectors;
        }

        public Dictionary<int, DoubleVector> GetAvarageExitVectors(Dictionary<int, DoubleVector> exitsList, Dictionary<int, Tuple<double, DoubleVector, DoubleVector>> notEffectivesObjects, int numberOfObjects, int numberOfExits)
        {
            Dictionary<int, DoubleVector> averageExitVectors = new Dictionary<int, DoubleVector>();
            DoubleVector tmp;
            Dictionary<int, DoubleVector> effectives = new Dictionary<int, DoubleVector>();
            foreach (var item in exitsList)
            {
                if (!notEffectivesObjects.ContainsKey(item.Key))
                {
                    effectives.Add(item.Key, item.Value);
                }
            }

            foreach (var notEffectivesObject in notEffectivesObjects)
            {
                tmp = new DoubleVector(numberOfExits);
                foreach (var effective in effectives)
                {
                    tmp += notEffectivesObject.Value.Item3.ElementAt(effective.Key - 1) * effective.Value;
                }
                averageExitVectors.Add(notEffectivesObject.Key, tmp);
            }
            return averageExitVectors;
        }

        private Dictionary<int, Tuple<int, DoubleVector, DoubleVector>> GetEffective(Dictionary<int, Tuple<DoubleVector, double, DoubleVector, double>> solution)
        {
            Dictionary<int, Tuple<int, DoubleVector, DoubleVector>> Efficiencies = new Dictionary<int, Tuple<int, DoubleVector, DoubleVector>>();
            foreach (var item in solution)
            {
                if (item.Value.Item2 > 0.9999999)
                {
                    Efficiencies.Add(item.Key, Tuple.Create(1, item.Value.Item1, item.Value.Item3));
                }
            }
            return Efficiencies;
        }

        private Dictionary<int, Tuple<double, DoubleVector, DoubleVector>> GetNotEfficiencies(Dictionary<int, Tuple<DoubleVector, double, DoubleVector, double>> solution)
        {
            Dictionary<int, Tuple<double, DoubleVector, DoubleVector>> notEfficiencies = new Dictionary<int, Tuple<double, DoubleVector, DoubleVector>>();
            foreach (var item in solution)
            {
                if (item.Value.Item2 < 0.9999999)
                {
                    notEfficiencies.Add(item.Key, Tuple.Create(item.Value.Item2, item.Value.Item1, item.Value.Item3));
                }
            }
            return notEfficiencies;
        }

        private Dictionary<int, Tuple<DoubleVector, double, DoubleVector, double>> DEA(Dictionary<int, DoubleVector> entriesList, Dictionary<int, DoubleVector> exitsList, int numberOfObjects, int numberOfEntries, int numberOfExits)
        {
            Dictionary<int, Tuple<DoubleVector, double, DoubleVector, double>> solution = new Dictionary<int, Tuple<DoubleVector, double, DoubleVector, double>>();
            // gives number of entries in our task coz we have to add entries with 0 coefficient
            var linearProblems = InitializeLinearProblem(exitsList, numberOfEntries);
            AddConstrains(ref linearProblems, entriesList, exitsList, numberOfObjects, numberOfExits, numberOfEntries);
            var dualLinearProblems = InitializeDualLinearProblem(linearProblems);
            AddDualConstrains(ref dualLinearProblems, linearProblems);
            var solver = new PrimalSimplexSolver();
            var dualSolver = new PrimalSimplexSolver();
            var solverParams = new PrimalSimplexSolverParams() // for dual simplex (min instead max)
            {
                Minimize = true
            };
            for (int i = 0; i < numberOfObjects; i++)
            {
                solver.Solve(linearProblems.ElementAt(i).Value);
                dualSolver.Solve(dualLinearProblems.ElementAt(i).Value, solverParams);
                solution.Add(i + 1, Tuple.Create(solver.OptimalX, solver.OptimalObjectiveFunctionValue, dualSolver.OptimalX, dualSolver.OptimalObjectiveFunctionValue));
            }
            return solution;
        }

        private Dictionary<int, LinearProgrammingProblem> InitializeLinearProblem(Dictionary<int, DoubleVector> exitsList, int numberOfEntries)
        {
            var linearProblems = new Dictionary<int, LinearProgrammingProblem>();
            DoubleVector tmpObjective;
            foreach (var exits in exitsList)
            {
                tmpObjective = new DoubleVector();
                tmpObjective.Append(exits.Value);
                for (int i = 0; i < numberOfEntries; i++)
                {
                    tmpObjective.Append(0);
                }
                linearProblems.Add(exits.Key, new LinearProgrammingProblem(tmpObjective));
            }
            return linearProblems;
        }

        private Dictionary<int, LinearProgrammingProblem> InitializeDualLinearProblem(Dictionary<int, LinearProgrammingProblem> simplexProblems)
        {
            var dualLinearProblems = new Dictionary<int, LinearProgrammingProblem>();
            DoubleVector tmpDualObjective;
            foreach (var simplexProblem in simplexProblems)
            {
                tmpDualObjective = new DoubleVector();
                foreach (var constraint in simplexProblem.Value.Constraints)
                {
                    tmpDualObjective.Append(constraint.RightHandSide);
                }
                foreach (var bound in simplexProblem.Value.VariableBounds)
                {
                    tmpDualObjective.Append(-bound.Value.LowerBound);
                }
                dualLinearProblems.Add(simplexProblem.Key, new LinearProgrammingProblem(tmpDualObjective));
            }
            return dualLinearProblems;
        }

        private void AddConstrains(ref Dictionary<int, LinearProgrammingProblem> linearProblems, Dictionary<int, DoubleVector> entriesList, Dictionary<int, DoubleVector> exitsList, int numberOfObjects, int numberOfExits, int numberOfEntries)
        {
            DoubleVector tmpEntries, tmpExits, tmpLowerBoundConstraint, tmpEqualityConstraint;
            int tmpKey;

            for (int i = 0; i < numberOfObjects; i++)
            {
                tmpKey = linearProblems.ElementAt(i).Key;
                tmpEntries = entriesList.Where(entries => entries.Key == tmpKey).Select(entries => entries.Value).First();
                tmpExits = exitsList.Where(exits => exits.Key == tmpKey).Select(exits => exits.Value).First();
                tmpLowerBoundConstraint = new DoubleVector();
                for (int j = 0; j < tmpExits.Length; j++)
                {
                    tmpLowerBoundConstraint.Append(-tmpExits.ElementAt(j));
                }
                for (int j = 0; j < tmpEntries.Length; j++)
                {
                    tmpLowerBoundConstraint.Append(tmpEntries.ElementAt(j));
                }
                foreach (var linearProblem in linearProblems)
                {
                    linearProblem.Value.AddLowerBoundConstraint(tmpLowerBoundConstraint, 0);
                }                
            }
            for (int i = 0; i < numberOfObjects; i++)
            {
                tmpEqualityConstraint = new DoubleVector();
                for (int j = 0; j < numberOfExits; j++)
                {
                    tmpEqualityConstraint.Append(0);
                }
                tmpEqualityConstraint.Append(entriesList.ElementAt(i).Value);
                linearProblems.ElementAt(i).Value.AddEqualityConstraint(tmpEqualityConstraint, 1);
                for (int j = 0; j < numberOfEntries + numberOfExits; j++)
                {
                    linearProblems.ElementAt(i).Value.AddLowerBound(j, 0.0001);
                }
            }
        }

        private void AddDualConstrains(ref Dictionary<int, LinearProgrammingProblem> dualLinearProblems, Dictionary<int, LinearProgrammingProblem> linearProblems)
        {
            int dualVariablesNumber = dualLinearProblems.ElementAt(0).Value.NumVariables;
            int linearConstrainsNumber = linearProblems.ElementAt(0).Value.Constraints.Count;
            int linearBoundsNumber = linearProblems.ElementAt(0).Value.VariableBounds.Count;
            Dictionary<int, List<LinearConstraint>> dualLinearConstraints = new Dictionary<int, List<LinearConstraint>>();
            List<LinearConstraint> tmpConstraints;
            DoubleVector tmp;
            for(int k = 0; k < linearProblems.Count; k++)
            {
                tmpConstraints = new List<LinearConstraint>();
                for (int i = 0; i < linearProblems.ElementAt(k).Value.NumVariables; i++)
                {
                    tmp = new DoubleVector();
                    for (int j = 0; j < linearConstrainsNumber - 1; j++)
                    {                      
                        tmp.Append(-linearProblems.ElementAt(k).Value.Constraints[j].Coefficients.ElementAt(i));
                    }
                    for (int j = linearConstrainsNumber - 1; j < linearConstrainsNumber; j++)
                    {
                        tmp.Append(linearProblems.ElementAt(k).Value.Constraints[j].Coefficients.ElementAt(i));
                    }

                    for (int j = linearConstrainsNumber; j < dualVariablesNumber; j++)
                    {
                        if (j == i + linearConstrainsNumber)
                        {
                            tmp.Append(-1);
                        }
                        else
                        {
                            tmp.Append(0);
                        }
                    }
                    dualLinearProblems.ElementAt(k).Value.AddLowerBoundConstraint(tmp, linearProblems.ElementAt(k).Value.ObjectiveCoefficients.ElementAt(i));        
                }                
            }
            for (int i = 0; i < dualVariablesNumber; i++)
            {
                foreach (var dualLinearProblem in dualLinearProblems)
                {
                    dualLinearProblem.Value.AddLowerBound(i, 0);
                }
            }
        }
    }
}
