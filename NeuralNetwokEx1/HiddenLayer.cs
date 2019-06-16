using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwokEx1
{
    class HiddenLayer : Layer
    {
        public List<HiddenLayer> initLayer(HiddenLayer hiddenLayer, 
            List<HiddenLayer> listOfHiddenLayer, 
            InputLayer inputLayer, OutputLayer outputLayer)
        {
            List<Double> listOfWeightIn = new List<Double>();
            List<Double> listOfWeightOut = new List<Double>();
            List<Neuron> listOfNeurons = new List<Neuron>();

            int numberOfHiddenLayer = listOfHiddenLayer.Count;

            for(int i = 0; i < numberOfHiddenLayer; i++)
            {
                for(int j = 0; j < hiddenLayer.getNumberOfNeuronsInLayer(); j++)
                {
                    Neuron neuron = new Neuron();

                    int limitIn;
                    int limitOut;

                    if(i == 0)
                    {
                        limitIn = inputLayer.getNumberOfNeuronsInLayer();
                        if(numberOfHiddenLayer > 1)
                        {
                            limitOut = listOfHiddenLayer[i + 1].getNumberOfNeuronsInLayer();
                        }
                        else
                        {
                            limitOut = listOfHiddenLayer[i].getNumberOfNeuronsInLayer();
                        }
                    }
                    else if(i == numberOfHiddenLayer - 1)
                    {
                        limitIn = listOfHiddenLayer[i - 1].getNumberOfNeuronsInLayer();
                        limitOut = outputLayer.getNumberOfNeuronsInLayer();
                    }
                    else
                    {
                        limitIn = listOfHiddenLayer[i - 1].getNumberOfNeuronsInLayer();
                        limitOut = listOfHiddenLayer[i + 1].getNumberOfNeuronsInLayer();
                    }

                    for(int k = 0; k < limitIn; k++)
                    {
                        listOfWeightIn.Add(neuron.initNeuron());
                    }

                    for (int k = 0; k < limitOut; k++)
                    {
                        listOfWeightOut.Add(neuron.initNeuron());
                    }

                    neuron.setListOfWeightsIn(listOfWeightIn);
                    neuron.setListOfWeightsOut(listOfWeightOut);
                    listOfNeurons.Add(neuron);

                    listOfWeightIn = new List<Double>();
                    listOfWeightOut = new List<Double>();
                }
                listOfHiddenLayer[i].setListOfNeurons(listOfNeurons);

                listOfNeurons = listOfNeurons = new List<Neuron>();
            }
            return listOfHiddenLayer;
        }

        public void printLayer(List<HiddenLayer> listOfHiddentLayer)
        {
            if(listOfHiddentLayer.Count > 0)
            {
                Console.WriteLine("### HIDDEN LAYER ###");
                int h = 1;
                foreach (HiddenLayer hiddenLayer in listOfHiddentLayer)
                {
                    Console.WriteLine("HIDDEN LAYER #{0}", h);
                    int n = 1;
                    foreach (Neuron neuron in hiddenLayer.getListOfNeurons())
                    {
                        Console.WriteLine("Neuron #{0}:", n);
                        Console.WriteLine("Input weights:");
                        Console.WriteLine("### INPUT WEIGHTS ###");
                        Console.Write("[");
                        List<Double> ListOfWeightsIn = neuron.getListOfWeightsIn();
                        for (int i = 0; i < ListOfWeightsIn.Count; i++)
                        {
                            Console.Write(ListOfWeightsIn[i]);
                            if (i != ListOfWeightsIn.Count - 1)
                            {
                                Console.Write(", ");
                            }
                            Console.WriteLine("]");
                        }


                        Console.WriteLine("Neuron #{0}:", n);
                        Console.WriteLine("Output weights:");
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
    }
}
