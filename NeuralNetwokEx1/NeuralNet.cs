
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NeuralNetwokEx1.Training;

namespace NeuralNetwokEx1
{
    class NeuralNet
    {
        private InputLayer inputLayer;
        private HiddenLayer hiddenLayer;
        private List<HiddenLayer> listOfHiddenLayer;
        private OutputLayer outputLayer;
        private int numberOfHiddenLayers;

        private double[][] trainSet;
        private double[] realOutoutSet;
        private int maxEpochs;
        private double learningRate;
        private double targetError;
        private double trainingError;
        private List<Double> listOfMSE = new List<Double>();
        private ActivationFncENUM activationFnc;
        private TrainingTypesENUM trainType;

        public NeuralNet initNet(int numberOfInputNeurons, int numberOfHiddenLayers, int numberOfNeuronsInHiddenLayer, int numberOfOutputNeurons)
        {
            inputLayer = new InputLayer();
            inputLayer.setNumberOfNeuronsInLayer(numberOfInputNeurons);

            listOfHiddenLayer = new List<HiddenLayer>();
            for(int i = 0; i < numberOfHiddenLayers; i++)
            {
                hiddenLayer = new HiddenLayer();
                hiddenLayer.setNumberOfNeuronsInLayer(numberOfNeuronsInHiddenLayer);
                listOfHiddenLayer.Add(hiddenLayer);
            }
            outputLayer = new OutputLayer();
            outputLayer.setNumberOfNeuronsInLayer(numberOfOutputNeurons);

            inputLayer = inputLayer.initLayer(inputLayer);

            if(numberOfHiddenLayers > 0)
            {
                listOfHiddenLayer = hiddenLayer.initLayer(hiddenLayer, listOfHiddenLayer, inputLayer, outputLayer);
            }

            outputLayer = outputLayer.initLayer(outputLayer);

            NeuralNet newNet = new NeuralNet();
            newNet.setInputLayer(inputLayer);
            newNet.setHiddenLayer(hiddenLayer);
            newNet.setListOfHiddenLayer(listOfHiddenLayer);
            newNet.setNumberOfHiddenLayers(numberOfHiddenLayers);
            newNet.setOutputLayer(outputLayer);

            return newNet;
        }

        public void printNet(NeuralNet net)
        {
            inputLayer.printLayer(net.getInputLayer());
            Console.WriteLine();
            if(net.getHiddenLayer() != null)
            {
                hiddenLayer.printLayer(net.getListOfHiddenLayer());
                Console.WriteLine();
            }
            outputLayer.printLayer(net.getOutputLayer());
            Console.WriteLine();
        }

        public NeuralNet trainNet(NeuralNet net)
        {
            NeuralNet trainedNet = new NeuralNet();
            switch (net.trainType)
            {
                case TrainingTypesENUM.PERCEPTRON:
                    Perceptron t = new Perceptron();
                    trainedNet = t.train(net);
                    return trainedNet;
                case TrainingTypesENUM.ADALINE:
                    Adaline a = new Adaline();
                    trainedNet = a.train(net);
                    return trainedNet;
                default:
                    Console.WriteLine("Illegal Training");
                    return trainedNet;
            }
        }

        public void printTrainedNetResult(NeuralNet net)
        {
            switch (net.trainType)
            {
                case TrainingTypesENUM.PERCEPTRON:
                    Perceptron t = new Perceptron();
                    t.printTrainedNetResult(net);
                    break;
                case TrainingTypesENUM.ADALINE:
                    Adaline a = new Adaline();
                    a.printTrainedNetResult(net);
                    break;
                default:
                    Console.WriteLine("Illegal Training");
                    return;
            }
        }

        public InputLayer getInputLayer()
        {
            return inputLayer;
        }

        public void setInputLayer(InputLayer inputLayer)
        {
            this.inputLayer = inputLayer;
        }

        public HiddenLayer getHiddenLayer()
        {
            return hiddenLayer;
        }

        public void setHiddenLayer(HiddenLayer hiddenLayer)
        {
            this.hiddenLayer = hiddenLayer;
        }

        public OutputLayer getOutputLayer()
        {
            return outputLayer;
        }

        public void setOutputLayer(OutputLayer outputLayer)
        {
            this.outputLayer = outputLayer;
        }

        public List<HiddenLayer> getListOfHiddenLayer()
        {
            return listOfHiddenLayer;
        }

        public void setListOfHiddenLayer(List<HiddenLayer> listOfHiddenLayer)
        {
            this.listOfHiddenLayer = listOfHiddenLayer;
        }

        public void setNumberOfHiddenLayers(int numberOfHiddenLayers)
        {
            this.numberOfHiddenLayers = numberOfHiddenLayers;
        }

        public int getNumberOfHiddenLayers()
        {
            return numberOfHiddenLayers;
        }

        public double[][] getTrainSet()
        {
            return trainSet;
        }

        public void setTrainSet(double[][] trainSet)
        {
            this.trainSet = trainSet;
        }

        public double[] getRealOutoutSet()
        {
            return realOutoutSet;
        }

        public void setRealOutoutSet(double[] realOutoutSet)
        {
            this.realOutoutSet = realOutoutSet;
        }

        public int getMaxEpochs()
        {
            return maxEpochs;
        }

        public void setMaxEpochs(int maxEpochs)
        {
            this.maxEpochs = maxEpochs;
        }

        public double getTargetError()
        {
            return targetError;
        }

        public void setTargetError(double targetError)
        {
            this.targetError = targetError;
        }

        public double getLearningRate()
        {
            return learningRate;
        }

        public void setLearningRate(double learningRate)
        {
            this.learningRate = learningRate;
        }

        public double getTrainingError()
        {
            return trainingError;
        }

        public void setTrainingError(double trainingError)
        {
            this.trainingError = trainingError;
        }

        public ActivationFncENUM getActivationFnc()
        {
            return activationFnc;
        }

        public void setActivationFnc(ActivationFncENUM activationFnc)
        {
            this.activationFnc = activationFnc;
        }

        public TrainingTypesENUM getTrainingType()
        {
            return trainType;
        }

        public void setTrainingType(TrainingTypesENUM trainType)
        {
            this.trainType = trainType;
        }

        public List<Double> getListOfMSE()
        {
            return listOfMSE;
        }

        public void setListOfMSE(List<Double> listOfMSE)
        {
            this.listOfMSE = listOfMSE;
        }
    }
}

