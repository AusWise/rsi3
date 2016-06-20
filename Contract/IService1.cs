using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Contract
{
    [ServiceContract]
    public interface ICanvas{

        [OperationContract]
        void add(MyPoint p);

        [OperationContract]
        MyPoint get(int i);

        [OperationContract]
        int size();

        [OperationContract(IsOneWay = true)]
        void clear();

        [OperationContract]
        MyPoint centerOfGravity();
    }

    [DataContract]
    public class MyPoint{
        int x = 0;
        int y = 0;

        [DataMember]
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        [DataMember]
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public MyPoint() { }
    }

}
