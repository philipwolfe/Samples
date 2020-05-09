using System;
using System.IO;
using System.Net;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;

namespace Custom.Remoting.Channels {
	
	public class TcpClientChannel : System.Runtime.Remoting.Channels.Tcp.TcpClientChannel {
		public TcpClientChannel(IDictionary p, IClientChannelSinkProvider s) : base(p, s) {
		}

		public override IMessageSink CreateMessageSink(
			String url, Object remoteChannelData, out String objectURI) {

			if(url != null) {
				// client sending a request to server
				// remove the formatter part 'binary'
				// as in 'tcp-binary://server:port/object.rem'
				int index = url.IndexOf("://");
				String schema = url.Substring(0, index);
				int n = schema.IndexOf('-');
				if(n != -1) {
					url = schema.Substring(0, n) + url.Substring(index);
					remoteChannelData = schema.Substring(n);
				}
			}
			else
			if(remoteChannelData is ChannelDataStore) {
				// server calling the client back
				ChannelDataStore channelDataStore = (ChannelDataStore)remoteChannelData;
				url = channelDataStore.ChannelUris[0];

				// remove the formatter part 'binary'
				// as in tcp-binary://server:port/object.rem
				int index = url.IndexOf("://");
				String schema = url.Substring(0, index);
				int n = schema.IndexOf('-');
				if(n != -1) {
					url = schema.Substring(0, n) + url.Substring(index);
					String[] channelURIs = new String[] { url, schema.Substring(n) };
					remoteChannelData = new ChannelDataStore(channelURIs);
				}
			}

			return base.CreateMessageSink(url, remoteChannelData, out objectURI);
		}
	}
	

	public class HttpClientChannel : System.Runtime.Remoting.Channels.Http.HttpClientChannel {
		public HttpClientChannel(IDictionary p, IClientChannelSinkProvider s) : base(p, s) {
		}

		public override IMessageSink CreateMessageSink(
			String url, Object remoteChannelData, out String objectURI) {

			if(url != null) {
				// client sending a request to server
				// remove the formatter part 'binary'
				// as in 'http-binary://server:port/object.rem'
				int index = url.IndexOf("://");
				String schema = url.Substring(0, index);
				int n = schema.IndexOf('-');
				if(n != -1) {
					url = schema.Substring(0, n) + url.Substring(index);
					remoteChannelData = schema.Substring(n);
				}
			}
			else
			if(remoteChannelData is ChannelDataStore) {
				// server calling the client back
				ChannelDataStore channelDataStore = (ChannelDataStore)remoteChannelData;
				url = channelDataStore.ChannelUris[0];

				// remove the formatter part 'binary'
				// as in http-binary://server:port/object.rem
				int index = url.IndexOf("://");
				String schema = url.Substring(0, index);
				int n = schema.IndexOf('-');
				if(n != -1) {
					url = schema.Substring(0, n) + url.Substring(index);
					String[] channelURIs = new String[] { url, schema.Substring(n) };
					remoteChannelData = new ChannelDataStore(channelURIs);
				}
			}

			return base.CreateMessageSink(url, remoteChannelData, out objectURI);
		}
	}
	
	
	internal struct Formatter {
		public const String Binary = "binary";
		public const String Soap = "soap";
	}
	
	public class TwoWayChannel : IChannelSender, IChannelReceiver {
		IChannelSender _clientChannel;
		IChannelReceiver _serverChannel;

		#region static initilization
		protected static String s_hostName = Dns.GetHostName();
		protected static void ClientChannel(
			String schema,
			ref IDictionary properties,
			ref IClientChannelSinkProvider clientSinkProvider) {

			String channelSchema = properties["channel-schema"] as String;

			if(clientSinkProvider == null) {
				if(channelSchema == null) { // use a binary formatter as default
					if(schema == "tcp-")
						clientSinkProvider = new BinaryClientFormatterSinkProvider();
					else
					if(schema == "http-")
						clientSinkProvider = new SoapClientFormatterSinkProvider();
				}
				else {
					// look at the formatter for either a binary or soap
					int n = channelSchema.IndexOf('-');
					if(n == -1)
						throw new RemotingException("Unknown channel schema: " + channelSchema);

					String formatter = channelSchema.Substring(n+1);
					if(formatter == "soap")
						clientSinkProvider = new SoapClientFormatterSinkProvider();
					else
						if(formatter == "binary")
						clientSinkProvider = new BinaryClientFormatterSinkProvider();
					else
						throw new RemotingException("Client sink provider must be specified with this channel schema: "+channelSchema);
				}
			}

			// identify the channel schema
			if(channelSchema == null) {
				channelSchema = schema;
				String formatter = null;

				IClientChannelSinkProvider tempProvider = clientSinkProvider;
				while(tempProvider != null && formatter == null) {
					if(tempProvider is BinaryClientFormatterSinkProvider)
						formatter = Formatter.Binary;
					else if(tempProvider is SoapClientFormatterSinkProvider)
						formatter = Formatter.Soap;

					tempProvider = tempProvider.Next;
				}

				if(formatter == null)
					throw new RemotingException("Cannot identify the channel schema.");

				channelSchema += formatter;
			}

			int port = Convert.ToInt32(properties["port"] as String);
			String serverUrl = String.Format("{0}://{1}:{2}", channelSchema, s_hostName, port);

			IClientChannelSinkProvider provider = new ClientChannelSinkProvider(channelSchema, serverUrl);
			provider.Next = clientSinkProvider;

			// filter the properties because the TcpClientChannel
			// does not like to see anything but 'name' and 'priority'
			IDictionary props = new Hashtable();
			IDictionaryEnumerator itr = properties.GetEnumerator();
			while(itr.MoveNext()) {
				String key = itr.Key as String;
				switch(key) {
					case "name" :
					case "priority" :
						props.Add(key, itr.Value);
						break;
				}
			}
			
			properties = props;
			clientSinkProvider = provider;
		}

		protected static void ServerChannel(
			String schema,
			ref IDictionary properties,
			ref IServerChannelSinkProvider serverSinkProvider) {

			String channelSchema = properties["channel-schema"] as String;

			if(serverSinkProvider == null) {
				if(channelSchema == null) { // use a binary formatter as default
					if(schema == "tcp-")
						serverSinkProvider = new BinaryServerFormatterSinkProvider();
					else
					if(schema == "http-")
						serverSinkProvider = new SoapServerFormatterSinkProvider();
				}
				else {
					// look at the formatter for either a binary or soap
					int n = channelSchema.IndexOf('-');
					if(n == -1)
						throw new RemotingException("Unknown channel schema: " + channelSchema);

					String formatter = channelSchema.Substring(n+1);
					if(formatter == "soap")
						serverSinkProvider = new SoapServerFormatterSinkProvider();
					else
					if(formatter == "binary")
						serverSinkProvider = new BinaryServerFormatterSinkProvider();
					else
						throw new RemotingException("Client sink provider must be specified with this channel schema: "+channelSchema);
				}
			}

			// filter the properties because the ServerChannel
			// does not like to see anything but 'name', 'port', and 'priority'
			IDictionary props = new Hashtable();
			IDictionaryEnumerator itr = properties.GetEnumerator();
			while(itr.MoveNext()) {
				String key = itr.Key as String;
				switch(key) {
					case "name" :
					case "port" :
					case "priority" :
					case "bindTo" :
					case "machineName" :
					case "rejectRemoteRequests" :
					case "suppressChannelData" :
					case "useIpAddress" :
						props.Add(key, itr.Value);
						break;
				}
			}

			properties = props;
		}

		#endregion 

		#region Constructor
		public TwoWayChannel(IChannelSender clientChannel, IChannelReceiver serverChannel) {
			_clientChannel = clientChannel;
			_serverChannel = serverChannel;
		}
		#endregion

		#region IChannel interface
		public String ChannelName { 
			get { return _clientChannel.ChannelName; }
		}
		public int ChannelPriority { 
			get { return _clientChannel.ChannelPriority; }
		}
		public String Parse(String URL, out String objectURI) {
			// Parse out the ://
			int start = URL.IndexOf("://");
			start += 3;
			int end = URL.LastIndexOf('/', start);


			String channelURI = null;
			if(end != -1) {
				channelURI = URL.Substring(start, end - start);       
				objectURI = URL.Substring(end+1);
			}
			else {
				channelURI = URL.Substring(start);       
				objectURI = null;
			}

			return channelURI;
		}
		#endregion
		
		#region IChannelSender interface
		public IMessageSink CreateMessageSink(
			String url, 
			Object remoteChannelData,
			out String objectUri) {



			// pass it on to the standard TcpClientChannel/HttpClientChannel
			return _clientChannel.CreateMessageSink(url, remoteChannelData, out objectUri);
		} // CreateMessageSink
		#endregion

		#region IChannelReceiver interface
		public String[] GetUrlsForUri(String objectURI) {
			return _serverChannel.GetUrlsForUri(objectURI);
		}

		public void StartListening(Object data) {
			_serverChannel.StartListening(data);
		}

		public void StopListening(Object data) {
			_serverChannel.StopListening(data);
		}

		public Object ChannelData {
			get { 
				return _serverChannel.ChannelData;
			}
		}
		#endregion
	}

	public class TcpChannel : TwoWayChannel {
		public TcpChannel(
			IDictionary properties,
			IClientChannelSinkProvider clientSinkProvider,
			IServerChannelSinkProvider serverSinkProvider) 
			: base (
				ClientChannel(properties, clientSinkProvider),
				ServerChannel(properties, serverSinkProvider)
			) { }

		

		static IChannelSender ClientChannel(
			IDictionary properties,
			IClientChannelSinkProvider clientSinkProvider) {

			ClientChannel("tcp-", ref properties, ref clientSinkProvider);
			return new TcpClientChannel(properties, clientSinkProvider);
		}

		static IChannelReceiver ServerChannel(
			IDictionary properties,
			IServerChannelSinkProvider serverSinkProvider) {

			ServerChannel("tcp-", ref properties, ref serverSinkProvider);
			return new TcpServerChannel(properties, serverSinkProvider);
		}
	}

	public class HttpChannel : TwoWayChannel {
		public HttpChannel(
			IDictionary properties,
			IClientChannelSinkProvider clientSinkProvider,
			IServerChannelSinkProvider serverSinkProvider) 
			: base (
				ClientChannel(properties, clientSinkProvider),
				ServerChannel(properties, serverSinkProvider)
			) { }


		static IChannelSender ClientChannel(
			IDictionary properties,
			IClientChannelSinkProvider clientSinkProvider) {

			ClientChannel("http-", ref properties, ref clientSinkProvider);
			return new HttpClientChannel(properties, clientSinkProvider);
		}

		static IChannelReceiver ServerChannel(
			IDictionary properties,
			IServerChannelSinkProvider serverSinkProvider) {

			ServerChannel("http-", ref properties, ref serverSinkProvider);
			return new HttpServerChannel(properties, serverSinkProvider);
		}
	}


	internal class ClientChannelSinkProvider : IClientFormatterSinkProvider, IClientChannelSinkProvider {
		String _channelSchema;
		String _serverUrl;

		public ClientChannelSinkProvider(String channelSchema, String serverUrl) { 
			_channelSchema = channelSchema;
			_serverUrl = serverUrl;
		}

		IClientChannelSinkProvider _nextSinkProvider;
		public IClientChannelSinkProvider Next {
			get { 
				return _nextSinkProvider;
			}
			set { 
				_nextSinkProvider = value; 
			}
		}

		public IClientChannelSink CreateSink(
			IChannelSender channel,
			String url,
			Object remoteChannelData) {

			int index = url.IndexOf(':');
			if(index == -1)
				throw new RemotingException("No channel url specified.");

			String channelSchema = url.Substring(0,index);
			String formatter = remoteChannelData as String;
			if(formatter == null) {
				// this is the server's callback 
				// take the hint from the ChannelDataStore
				ChannelDataStore channelDataStore = remoteChannelData as ChannelDataStore;
				if(channelDataStore == null)
					throw new RemotingException("Cannot identify channel schema.");
				formatter = channelDataStore.ChannelUris[1];
			}

			channelSchema += formatter;
			if(String.Compare(channelSchema, _channelSchema, true) != 0)
				return null;  // channel schema does not match

			IClientChannelSink nextSink = null;
			if(_nextSinkProvider != null) {
				nextSink = _nextSinkProvider.CreateSink(channel, url, remoteChannelData);
				if(nextSink == null)
					return null;
			}

			return new ClientChannelSink(nextSink, _serverUrl);
		}
	}

	internal class ClientChannelSink : IClientFormatterSink, IMessageSink, IClientChannelSink, IChannelSinkBase {
		
		String[] _channelURIs;
		IMessage ModifyChannelData(IMessage msg) {
			IMethodCallMessage mcm = msg as IMethodCallMessage;
			if(mcm == null)
				return msg;

			Object[] args = mcm.InArgs;
			for(int i=0; i<args.Length; i++)
			if(args[i] is MarshalByRefObject) {
				// Any method parameter that is a MarshalByRefObject is a callback facility
				// so we want to be sure that the desired channel schema is used when the 
				// callback is made.
				ObjRef objRef = RemotingServices.Marshal((MarshalByRefObject)args[i]);
				Object[] data = objRef.ChannelInfo.ChannelData;
				for(int j=0; j<data.Length; j++) {
					if(data[j] is ChannelDataStore) {
						data[j] = new ChannelDataStore(_channelURIs);
						break;
					}
				}
			}


			String url = msg.Properties["__Uri"] as String;
			int index = url.IndexOf("://");
			if(index != -1) {
				// the client makes a request to the server
				// rewrite the url to remove the formatter spec
				// e.g. remove 'binary' from http-binary://server:port/MyObject'

				String formatter = url.Substring(0, index);
				int n = formatter.IndexOf('-');
				if(n != -1) {
					String newUrl = formatter.Substring(0, n) + url.Substring(index);

					MethodCallMessageWrapper newMsg = new MethodCallMessageWrapper(mcm); 
					newMsg.Properties["__Uri"] = newUrl;
					msg = newMsg;
				}
			}

			return msg;
		}

		public ClientChannelSink(IClientChannelSink nextSink, String hostServerUrl) {
			_nextSink = nextSink;
			_channelURIs = new String[] { hostServerUrl };
		}
	
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			msg = ModifyChannelData(msg);
			return NextSink.AsyncProcessMessage(msg, replySink); 
		}
		
		public void AsyncProcessRequest(
			IClientChannelSinkStack sinkStack,
			IMessage msg,
			ITransportHeaders headers,
			Stream stream)
		{
			msg = ModifyChannelData(msg);
			sinkStack.Push(this, null);
			_nextSink.AsyncProcessRequest(sinkStack, msg, headers, stream);
		}

		
		public void AsyncProcessResponse(
			IClientResponseChannelSinkStack sinkStack,
			Object state,
			ITransportHeaders headers,
			Stream stream)
		{
			_nextSink.AsyncProcessResponse(sinkStack, state, headers, stream);   
		}
		
		public Stream GetRequestStream(
			IMessage msg,
			ITransportHeaders headers)
		{
			msg = ModifyChannelData(msg);
			Stream requestStream = (_nextSink != null) ? _nextSink.GetRequestStream(msg, headers) : null;
			return requestStream;
		}
		
		public void ProcessMessage(
			IMessage msg,
			ITransportHeaders requestHeaders,
			Stream requestStream,
			out ITransportHeaders responseHeaders,
			out Stream responseStream)
		{
			msg = ModifyChannelData(msg);
			_nextSink.ProcessMessage(msg, requestHeaders, requestStream, out responseHeaders, out responseStream);
		}
		
		public IMessage SyncProcessMessage(IMessage msg)
		{
			msg = ModifyChannelData(msg);
			return NextSink.SyncProcessMessage(msg);
		}

		
		Hashtable prop = new Hashtable();
		public IDictionary Properties {
			get { 
				return prop;
			}
		}


		IClientChannelSink _nextSink;
		public IClientChannelSink NextChannelSink {
			get { 
				return _nextSink;
			}
		}
		
		public IMessageSink NextSink {
			get {
				for(IClientChannelSink next = _nextSink; next != null; next = next.NextChannelSink)
					if(next is  IMessageSink)
						return (IMessageSink)next;
        
				return null;
			}
		}
		
	}

}
