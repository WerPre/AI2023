using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Models; //For modelling Bernoulli distribution
using Microsoft.ML.Probabilistic.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moneta
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            // Sample data from standard Gaussian  
            bool[] data = new bool[50];
            for (int i = 0; i < data.Length; i++)
                data[i] = random.Next(2) == 1;

            // Create mean and precision random variables 
            Variable<double> beta = Variable.Beta(0.0, 0.0);


            for (int i = 0; i < data.Length; i++)
            {
                Variable<bool> x = Variable.Bernoulli(beta);
                x.ObservedValue = data[i];
            }

            InferenceEngine engine = new InferenceEngine();// Retrieve the posterior distributions  
            Console.WriteLine("beta=" + engine.Infer(beta));

        }
    }
}
