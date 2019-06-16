using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwokEx1
{
    class Neuron
    {
        private List<Double> listOfWeightsIn;
        private List<Double> listOfWeightsOut;

        public double initNeuron()
        {
            Random r = new Random();
            return r.NextDouble();
        }

        public List<Double> getListOfWeightsIn()
        {
            return listOfWeightsIn;
        }

        public void setListOfWeightsIn(List<Double> listOfWeightsIn)
        {
            this.listOfWeightsIn = listOfWeightsIn;
        }

        public List<Double> getListOfWeightsOut()
        {
            return listOfWeightsOut;
        }

        public void setListOfWeightsOut(List<Double> listOfWeightsOut)
        {
            this.listOfWeightsOut = listOfWeightsOut;
        }

    }
}
