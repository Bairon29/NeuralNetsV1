using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwokEx1
{
    abstract class Layer
    {
        private List<Neuron> listOfNeurons;
        protected int numberOfNeuronsInLayer;

        void printLayer() { }
        
        public List<Neuron> getListOfNeurons()
        {
            return listOfNeurons;
        }

        public void setListOfNeurons(List<Neuron> listOfNeurons)
        {
            this.listOfNeurons = listOfNeurons;
        }

        public int getNumberOfNeuronsInLayer()
        {
            return this.numberOfNeuronsInLayer;
        }

        public void setNumberOfNeuronsInLayer(int numberOfNeuronsInLayer)
        {
            this.numberOfNeuronsInLayer = numberOfNeuronsInLayer;
        }
    }
}
