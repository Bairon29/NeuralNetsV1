using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwokEx1
{
    abstract class Training
    {
        private int epochs;
        private double error;
        private double mse;

        public enum TrainingTypesENUM
        {
            PERCEPTRON, ADALINE
        }

        public NeuralNet train(NeuralNet net)
        {
            List<Double> inputWeightIn = new List<Double>();

            int rows = net.getTrainSet().Length;
            int cols = net.getTrainSet()[0].Length;

            while (this.Epochs < net.getMaxEpochs())
            {
                double estimatedOutput = 0.0;
                double realOutput = 0.0;

                for (int i = 0; i < rows; i++)
                {
                    double netValue = 0.0;
                    for (int j = 0; j < cols; j++)
                    {
                        inputWeightIn = net.getInputLayer().getListOfNeurons()[j].getListOfWeightsIn();
                        double inputWeight = inputWeightIn[0];
                        netValue = netValue + inputWeight * net.getTrainSet()[i][j];
                    }

                    estimatedOutput = this.activationFnc(net.getActivationFnc(), netValue);
                    realOutput = net.getRealOutoutSet()[i];

                    this.Error = realOutput - estimatedOutput;

                    if(Math.Abs(this.Error) > net.getTrainingError())
                    {
                        InputLayer inputLayer = new InputLayer();
                        inputLayer.setListOfNeurons(this.teachNeuronsOfLayer(cols, i, net, netValue));
                        net.setInputLayer(inputLayer);
                    }
                }
                this.Mse = Math.Pow(realOutput - estimatedOutput, 2.0);
                net.getListOfMSE().Add(this.Mse);

                this.Epochs = this.Epochs + 1;
            }
            net.setTrainingError(this.Error);
            return net;
        }

        private List<Neuron> teachNeuronsOfLayer(int numberOfInputNeurons, int line, NeuralNet net, double netValue)
        {
            List<Neuron> listOfNeurals = new List<Neuron>();
            List<Double> inputWeightInNew = new List<Double>();
            List<Double> inputWeightInOld = new List<Double>();

            for(int j = 0; j < numberOfInputNeurons; j++)
            {
                inputWeightInOld = net.getInputLayer().getListOfNeurons()[j].getListOfWeightsIn();
                double inputWeightOld = inputWeightInOld[0];

                inputWeightInNew.Add(this.calcNewWeight(net.getTrainingType(), inputWeightOld, net, this.Error, net.getTrainSet()[line][j], netValue));
                //-->
                Neuron neuron = new Neuron();
                neuron.setListOfWeightsIn(inputWeightInNew);
                listOfNeurals.Add(neuron);
                inputWeightInNew = new List<Double>();
            }
            return listOfNeurals;
        }

        private double calcNewWeight(TrainingTypesENUM trainType, double inputWeightOld, NeuralNet net, double error, double trainSample, double netValue)
        {
            switch (trainType)
            {
                case TrainingTypesENUM.PERCEPTRON:
                    return inputWeightOld + net.getLearningRate() * error * trainSample;
                case TrainingTypesENUM.ADALINE:
                    return inputWeightOld + net.getLearningRate() * error * trainSample * derivativeActivationFnc(net.getActivationFnc(), netValue);
                default:
                    Console.WriteLine("Illegal Calculation of Weigth Function");
                    return -1.0;
            }
        }

        public int Epochs { get => epochs; set => epochs = value; }
        public double Error { get => error; set => error = value; }
        public double Mse { get => mse; set => mse = value; }

        public enum ActivationFncENUM
        {
            STEP, LINEAR, SIGLOG, HYPERTAN
        }

        public double activationFnc(ActivationFncENUM fnc, double value)
        {
            switch (fnc)
            {
                case ActivationFncENUM.STEP:
                    return fncStep(value);
                case ActivationFncENUM.LINEAR:
                    return fncLinear(value);
                case ActivationFncENUM.SIGLOG:
                    return fncSigLog(value);
                case ActivationFncENUM.HYPERTAN:
                    return fncHyperTan(value);
                default:
                    Console.WriteLine("Illegal Activation Function");
                    return value;
            }
        }

        public double derivativeActivationFnc(ActivationFncENUM fnc, double value)
        {
            switch (fnc)
            {
                case ActivationFncENUM.LINEAR:
                    return derivativeFncLinear(value);
                case ActivationFncENUM.SIGLOG:
                    return derivativeFncSigLog(value);
                case ActivationFncENUM.HYPERTAN:
                    return derivativeFncHyperTan(value);
                default:
                    Console.WriteLine("Illegal Derivative Activation Function");
                    return value;
            }
        }

        public void printTrainedNetResult(NeuralNet trainedNet)
        {
            int rows = trainedNet.getTrainSet().Length;
            int cols = trainedNet.getTrainSet()[0].Length;

            List<Double> inputWeightIn = new List<Double>();

            for(int i = 0; i < rows; i++)
            {
                double netValue = 0.0;
                for(int j = 0; j < cols; j++)
                {
                    inputWeightIn = trainedNet.getInputLayer().getListOfNeurons()[j].getListOfWeightsIn();
                    double inputWeight = inputWeightIn[0];
                    netValue = netValue + inputWeight * trainedNet.getTrainSet()[i][j];

                    Console.WriteLine(trainedNet.getTrainSet()[i][j] + "\t");
                }
                double estimatedOutput = this.activationFnc(trainedNet.getActivationFnc(), netValue);

                Console.WriteLine(" NET OUTPUT: {0}\t", estimatedOutput);
                Console.WriteLine(" REAL OUTPUT: {0}\t", trainedNet.getRealOutoutSet()[i]);
                Console.WriteLine(" ERROR {0}\n", error);
            }
        }

        private double fncStep(double v)
        {
            if(v >= 0)
            {
                return 1.0;
            } 
            else
            {
                return 0.0;
            }
        }

        private double fncLinear(double v)
        {
            return v;
        }

        private double fncSigLog(double v)
        {
            return 1.0 / (1.0 + Math.Exp(-v));
        }

        private double fncHyperTan(double v)
        {
            return Math.Tanh(v);
        }

        private double derivativeFncLinear(double v)
        {
            return 1.0;
        }

        private double derivativeFncSigLog(double v)
        {
            return v * (1.0 - v);
        }

        private double derivativeFncHyperTan(double v)
        {
            return (1.0 / Math.Pow(Math.Cosh(v), 2.0));
        }
    }
}
