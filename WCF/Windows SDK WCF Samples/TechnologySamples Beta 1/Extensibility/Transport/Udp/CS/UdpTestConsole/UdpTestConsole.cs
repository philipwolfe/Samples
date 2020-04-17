// ----------------------------------------------------------------------------
// Copyright (C) 2003-2005 Microsoft Corporation, All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Configuration;
using System.ServiceModel.Channels;
using System.Diagnostics;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    #region Contracts
    [ServiceContract]
    public interface ICalculatorContract
    {
        [OperationContract]
        int Add(int x, int y);
    }

    [ServiceContract]
    public interface IDatagramContract
    {
        [OperationContract(IsOneWay = true)]
        void Hello();
    }
    #endregion

    #region Services
    class ConfigurableCalculatorService : CalculatorService
    {
    }

    class CalculatorService : IDatagramContract, ICalculatorContract
    {
        #region ICalculatorContract implementation
        public int Add(int x, int y)
        {
            Console.WriteLine("   adding {0} + {1}", x, y);
            return (x + y);
        }
        #endregion

        #region IDatagramContract implementation
        public void Hello()
        {
            Console.Out.WriteLine("Hello, world!");
        }
        #endregion
    }
    #endregion

    #region Proxies
    public class CalculatorProxy : ClientBase<ICalculatorContract>, ICalculatorContract
    {
        public CalculatorProxy()
            : base()
        {
        }

        public CalculatorProxy(string configurationName)
            : base(configurationName)
        {
        }

        public CalculatorProxy(Binding binding, EndpointAddress address)
            : base(binding, address)
        {
        }

        public int Add(int x, int y)
        {
            return base.Channel.Add(x, y);
        }
    }

    public class DatagramProxy : ClientBase<IDatagramContract>, IDatagramContract
    {
        public DatagramProxy()
            : base()
        {
        }

        public DatagramProxy(string configurationName)
            : base(configurationName)
        {
        }

        public DatagramProxy(Binding binding, EndpointAddress address)
            : base(binding, address)
        {
        }

        public void Hello()
        {
            base.Channel.Hello();
        }
    }
    #endregion

    class UdpTestConsole
    {
        /// <summary>
        /// Example of using UDP where everything (address, binding, contract) is specified in code.
        /// </summary>
        static void TestFromCode()
        {
            Console.Out.WriteLine("Testing Udp From Code.");

            Binding datagramBinding = new CustomBinding(new BinaryMessageEncodingBindingElement(), new UdpTransportBindingElement());

            // using the 2-way calculator method requires a session since UDP is not inherently request-response
            Binding calculatorBinding = new SampleProfileUdpBinding(true);
            calculatorBinding.SendTimeout = calculatorBinding.ReceiveTimeout = TimeSpan.FromHours(1);

            Uri calculatorAddress = new Uri("soap.udp://localhost:8080/");
            Uri datagramAddress = new Uri("soap.udp://localhost:8081/datagram");

            // we need an http base address so that svcutil can access our metadata
            ServiceHost service = new ServiceHost(typeof(CalculatorService), 
                new Uri("http://localhost:8000/udpsample/"));
            service.AddServiceEndpoint(typeof(ICalculatorContract), calculatorBinding, calculatorAddress);
            service.AddServiceEndpoint(typeof(IDatagramContract), datagramBinding, datagramAddress);
            service.Open();

            using (service)
            {
				DatagramProxy datagramProxy = new DatagramProxy(datagramBinding, new EndpointAddress(datagramAddress));
                using (datagramProxy)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        datagramProxy.Hello();
                    }

                    datagramProxy.Close();
                }

                CalculatorProxy calculatorProxy = new CalculatorProxy(calculatorBinding, new EndpointAddress(calculatorAddress));
                using (calculatorProxy)
                {
                    for (int i = 0; i < 5; ++i)
                    {
                        Console.WriteLine(calculatorProxy.Add(i, i * 2));
                    }
                    calculatorProxy.Close();
                }

                Console.Out.WriteLine("Press <ENTER> to complete test.");
                Console.In.ReadLine();
                service.Close();
            }
        }

        /// <summary>
        /// Example of using UDP where bindings and addresses are specified in config.
        /// </summary>
        static void TestFromConfig()
        {
            Console.Out.WriteLine("Testing Udp From Config.");

            ServiceHost service = new ServiceHost(typeof(ConfigurableCalculatorService), new Uri("soap.udp://localhost:8080/"));
            service.Open();

            using (service)
            {
                DatagramProxy datagramProxy = new DatagramProxy("datagram");
                using (datagramProxy)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        datagramProxy.Hello();
                    }

                    datagramProxy.Close();
                }

                CalculatorProxy calculatorProxy = new CalculatorProxy("calculator");
                using (calculatorProxy)
                {
                    for (int i = 0; i < 5; ++i)
                    {
                        Console.WriteLine(calculatorProxy.Add(i, i * 2));
                    }
                    calculatorProxy.Close();
                }

                Console.Out.WriteLine("Press <ENTER> to complete test.");
                Console.In.ReadLine();
                service.Close();
            }
        }

        static void Main(string[] args)
        {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            TestFromCode();
            TestFromConfig();
        }
    }
}
