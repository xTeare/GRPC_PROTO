The code for creating the StatusReportRequest and 
the Response Stream handling is located in Pages/Index.razor

The GRPC Setup can be found in Program.cs

On adding a new .proto : Make sure, the *.proto files Build Action is set to : Protobuf Compiler

TODO : Add Contracts via protobuf-net.Grpc