using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwokEx1
{
    class Perceptron : Training
    {
        public NeuralNet Train(NeuralNet net)
        {
            return this.train(net);
        }
    }
}
