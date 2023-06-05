using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Probabilistic;
using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Models;


namespace Markov
{
    internal class Program
    {
        static void FirstExample()
        {
            InferenceEngine engine = new InferenceEngine();
            Variable<int> numTimes = Variable.Observed(10);
            Range time = new Range(numTimes);
            VariableArray<double> x = Variable.Array<double>(time);
            using (var block = Variable.ForEach(time))
            {
                var t = block.Index;
                using (Variable.If(t == 0))
                {
                    x[t] = Variable.GaussianFromMeanAndVariance(0, 1);
                }
                using (Variable.If(t > 0))
                {
                    x[t] = Variable.GaussianFromMeanAndVariance(x[t - 1], 1);
                }
            }
        }

        void Graid() 
        {
            int length = 10;
            Range rows = new Range(length);
            Range cols = new Range(length);
            VariableArray2D<double> states = Variable.Array<double>(rows, cols);
            using (ForEachBlock rowBlock = Variable.ForEach(rows))
            {
                var row = rowBlock.Index;
                using (ForEachBlock colBlock = Variable.ForEach(cols))
                {
                    var col = colBlock.Index;
                    using (Variable.If(row == 0))
                    {
                        states[row, col] = Variable.GaussianFromMeanAndVariance(0, 1);
                    }
                    using (Variable.If(row > 0))
                    {
                        states[row, col] = Variable.GaussianFromMeanAndVariance(states[row - 1, col], 1);
                    }
                    using (Variable.If(col > 0))
                    {
                        Variable.ConstrainEqualRandom(states[row, col] - states[row, col - 1], new Gaussian(0, 1));
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            FirstExample();
        }
    }
}
