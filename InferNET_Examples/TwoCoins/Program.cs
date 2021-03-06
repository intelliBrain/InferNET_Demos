﻿using System;
using Microsoft.ML.Probabilistic.Models;
using Microsoft.ML.Probabilistic.Distributions;

namespace sf.infernet.demos
{
    class Program
    {
        static void Main(string[] args)
        {
            Experiment_1();
        }

        private static void Experiment_1()
        {
            // PM erstellen
            Variable<bool> ersteMünzeWurf = Variable.Bernoulli(0.5);
            Variable<bool> zweiteMünzeWurf = Variable.Bernoulli(0.5);
            Variable<bool> beideMünzenWurf = ersteMünzeWurf & zweiteMünzeWurf;
            
            // Inferenz-Engine (IE) erstellen
            InferenceEngine engine = new InferenceEngine();
#if SHOW_MODEL
            engine.ShowFactorGraph = true; // PM visualisieren
#endif

            // Inferenz ausführen
            Bernoulli ergebnis = engine.Infer<Bernoulli>(beideMünzenWurf);
            double beideMünzenZeigenKöpfe = ergebnis.GetProbTrue();


            Console.WriteLine("Die Wahrscheinlichkeit - beide Münzen " +
                "zeigen Köpfe: {0}", beideMünzenZeigenKöpfe);
        }
    }
}
