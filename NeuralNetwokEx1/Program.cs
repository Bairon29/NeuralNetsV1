using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwokEx1
{
    class Program
    {
        static int Main(string[] args)
        {
            Program test = new Program();

            test.testPerceptron();
            Console.ReadLine();
            return 0;
        }

        private void testPerceptron()
        {
            NeuralNet testNet = new NeuralNet();

            testNet = testNet.initNet(2, 0, 0, 1);

            Console.WriteLine("-------------PERCEPTRON INIT NET---------------");

            testNet.printNet(testNet);

            NeuralNet trainedNet = new NeuralNet();

            // First colum has BIAS
            testNet.setTrainSet(new double[][] { new double[] { 1.0,0.0,0.0}, new double[] { 1.0, 0.0, 1.0 }, new double[] { 1.0, 1.0, 0.0 }, new double[] { 1.0, 1.0, 1.0 } });
            testNet.setRealOutoutSet(new double[] { 0.0, 0.0, 0.0, 1.0 });
            testNet.setMaxEpochs(10);
            testNet.setTargetError(0.002);
            testNet.setLearningRate(1.0);
            testNet.setTrainingType(Training.TrainingTypesENUM.PERCEPTRON);
            testNet.setActivationFnc(Training.ActivationFncENUM.STEP);

            trainedNet = testNet.trainNet(testNet);

            Console.WriteLine();
            Console.WriteLine("-------------PERCEPTRON TRAINED NET---------------");

            testNet.printNet(trainedNet);

            Console.WriteLine();
            Console.WriteLine("-------------PERCEPTRON PRINT RESULT---------------");

            testNet.printTrainedNetResult(trainedNet);
        }
    }
}
