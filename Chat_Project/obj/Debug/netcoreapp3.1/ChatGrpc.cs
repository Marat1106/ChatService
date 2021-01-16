// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/chat.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Chat_Project {
  public static partial class ChatService
  {
    static readonly string __ServiceName = "ChatService";

    static readonly grpc::Marshaller<global::Chat_Project.Message> __Marshaller_Message = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Chat_Project.Message.Parser.ParseFrom);

    static readonly grpc::Method<global::Chat_Project.Message, global::Chat_Project.Message> __Method_Join = new grpc::Method<global::Chat_Project.Message, global::Chat_Project.Message>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "Join",
        __Marshaller_Message,
        __Marshaller_Message);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Chat_Project.ChatReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ChatService</summary>
    [grpc::BindServiceMethod(typeof(ChatService), "BindService")]
    public abstract partial class ChatServiceBase
    {
      public virtual global::System.Threading.Tasks.Task Join(grpc::IAsyncStreamReader<global::Chat_Project.Message> requestStream, grpc::IServerStreamWriter<global::Chat_Project.Message> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ChatServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Join, serviceImpl.Join).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ChatServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Join, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::Chat_Project.Message, global::Chat_Project.Message>(serviceImpl.Join));
    }

  }
}
#endregion