//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.12
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.ServiceModel.ServiceContractAttribute()]
public interface ISampleServer
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISampleServer/Echo", ReplyAction="http://tempuri.org/ISampleServer/EchoResponse")]
    string Echo(string input);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISampleServer/BigEcho", ReplyAction="http://tempuri.org/ISampleServer/BigEchoResponse")]
    string[] BigEcho(string[] input);
}

public interface ISampleServerChannel : ISampleServer, System.ServiceModel.IClientChannel
{
}

public partial class SampleServerProxy : System.ServiceModel.ClientBase<ISampleServer>, ISampleServer
{
    
    public SampleServerProxy()
    {
    }
    
    public SampleServerProxy(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public SampleServerProxy(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public SampleServerProxy(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public SampleServerProxy(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string Echo(string input)
    {
        return base.Channel.Echo(input);
    }
    
    public string[] BigEcho(string[] input)
    {
        return base.Channel.BigEcho(input);
    }
}
