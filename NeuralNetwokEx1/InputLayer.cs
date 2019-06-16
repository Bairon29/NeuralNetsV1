using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwokEx1
{
    class InputLayer : Layer
    {
        public InputLayer initLayer(InputLayer inputLayer)
        {
            List<Double> listOfWeightInTemp = new List<Double>();
            List<Neuron> listOfNeurons = new List<Neuron>();

            for(int i = 0; i < inputLayer.getNumberOfNeuronsInLayer(); i++)
            {
                Neuron neuron = new Neuron();

                listOfWeightInTemp.Add(neuron.initNeuron());
                neuron.setListOfWeightsIn(listOfWeightInTemp);
                listOfNeurons.Add(neuron);

                listOfWeightInTemp = new List<Double>();
            }
            inputLayer.setListOfNeurons(listOfNeurons);

            return inputLayer;
        }

        public void printLayer(InputLayer inputLayer)
        {
            Console.WriteLine("### INPUT LAYER ###");
            int n = 1;
            foreach(Neuron neuron in inputLayer.getListOfNeurons())
            {
                Console.WriteLine("Neuron #{0}:", n);
                Console.WriteLine("Input weights:");
                Console.WriteLine("### INPUT WEIGHTS ###");
                Console.Write("[");
                List<Double> ListOfWeightsIn = neuron.getListOfWeightsIn();
                for (int i = 0; i < ListOfWeightsIn.Count; i++)
                {
                    Console.Write(ListOfWeightsIn[i]);
                    if(i != ListOfWeightsIn.Count - 1)
                    {
                        Console.Write(", ");
                    }
                    Console.WriteLine("]");
                }
                n++;
            }
        }

        void setNumberOfNeuronsInput(int numberOfNeuronsInLayer)
        {
            this.numberOfNeuronsInLayer = numberOfNeuronsInLayer;
        }
    }
}
