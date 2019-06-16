using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwokEx1
{
    class OutputLayer : Layer
    {
        public OutputLayer initLayer(OutputLayer outputLayer)
        {
            List<Double> listOfWeightOutTemp = new List<Double>();
            List<Neuron> listOfNeurons = new List<Neuron>();

            for (int i = 0; i < outputLayer.getNumberOfNeuronsInLayer(); i++)
            {
                Neuron neuron = new Neuron();

                listOfWeightOutTemp.Add(neuron.initNeuron());
                neuron.setListOfWeightsOut(listOfWeightOutTemp);
                listOfNeurons.Add(neuron);

                listOfWeightOutTemp = new List<Double>();
            }
            outputLayer.setListOfNeurons(listOfNeurons);

            return outputLayer;
        }

        public void printLayer(OutputLayer outputLayer)
        {
            Console.WriteLine("### OUTPUT LAYER ###");
            int n = 1;
            foreach (Neuron neuron in outputLayer.getListOfNeurons())
            {
                Console.WriteLine("Neuron #{0}:", n);
                Console.WriteLine("Input weights:");
                Console.WriteLine("### OUTPUT WEIGHTS ###");
                Console.Write("[");
                List<Double> ListOfWeightsOut = neuron.getListOfWeightsOut();
                for (int i = 0; i < ListOfWeightsOut.Count; i++)
                {
                    Console.Write(ListOfWeightsOut[i]);
                    if (i != ListOfWeightsOut.Count - 1)
                    {
                        Console.Write(", ");
                    }
                    Console.WriteLine("]");
                }
                n++;
            }
        }
    }
}
