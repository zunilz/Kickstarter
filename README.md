# Kickstarter

ToDo: Add Exception Management
Guidelines:
Exception Handling in C#
	
	- Exceptions are objects inherited from System.Exception
	- Generate exceptions by using throw statements
	-  Different exception classes represent different errors
	- Types
		- System excpetions
			- Out of memory
			- stackoverflow
			- Argument exception
				- ArgumentNullException
				- ArgumentOut ofRangeException
		
		- Third party
		- from our code
		- Arithmatic Excpetion
		- ApplicationException
			- Should not be thrown by our code
			- should not be caught by our code
			- Custom exceptions should not be derived from ApplicationException
		- Custom Exception
		
	- System.Exception properties
		- Message, StackTrace, Data, InnerException, Source, Hresult, Helplink, Targetite
- Commonly encountered exceptions
	- Exception
 		-Represnts execution errors 
 	- SystemException
  	  	- Base class for exceptions in system exceptions namespace
     	- Do not throw, catch (except in top level handles)
        - Do not catch framework code
   	- InvalidOperationException
   	- **ArgumentException**
  	 	- 	When argument is invalid
   	- **ArgumentNullException**
   		- 	null passed to non null accepted 
   	- **ArgumentOutOfRangeException**
   		- 	outside allowed range
   	- **InvalidOperationException**
   		- 	if the object is in inappropriate state
   	- NullReferenceException
	   	- 	ex when string operation done on null string
	   	- 	do not throw, usually bug in code
   	- IndexOutOfRangeException
   		- 	do not throw, usually bug in code
   	- StackOverflowException
	   	- 	ex: in recusrive method
	   	- 	do not throw, usually bug in code
   	- OutOfMemeoryException
   		-   	do not throw, usually bug in code
 
  - Understanding Exception Handling
	  - 	In nested code call, exceptions bubbleup untill it is caught.
	  - 	Catch from most specific exception to least specific
	  - Guidleines in project layers
	  - 	throw throwable exceptions in adapters and service layers.
	  - 	In controller, catch it as Exception and log as http 500 error, and in finally block have a audit handler with execution status, invoker and timestamp etc.
  - finally block
  	- use it for cleanup, can call IDisposable implementation here
  - re throwing exception
   	- use 'throw' instead of 'throw ex' as sencond option causes improper exception stack originated location details logged when we see the exception.
   - Wrapping of exceptions
   	- catch(DivideByZeroException ex) {
   	-	throw new ArithmaticException("some message", ex);
   	- }
   	- in above case, ArithmaticException encapsulates the DivideByZeroException when we see the exception log.
   - Exception filters
   	- catch(ArgumentNullException ex) when (ex.ParamName == "param1")
   - Custom Exceptions
   	- inherit from system.Exception
 
- .Net Core DI
	**Transient** — Services are created each time they are requested. It gets a new instance of the injected object, on each request of this object. For each time you inject this object is injected in the class, it will create a new instance.
	**Scoped** — Services are created on each request (once per request). This is most recommended for WEB applications. So for example, if during a request you use the same dependency injection, in many places, you will use the same instance of that object, it will make reference to the same memory allocation.
	**Singleton** — Services are created once for the lifetime of the application. It uses the same instance for the whole application.
The dependency injection container keeps track of all instances of the created services, and they are disposed of or released for garbage collector once their lifetime has ended


   
App insights - view logs, live, last 1 hr
		- aks -> wrokloads -> deployment sections - dhengineWebapi 
		-> live logs - select pods
	
	.Net Core
	What's new in .NET 6
		- Simplified development
			- minimal APIs make it easy to quickly write smaller, faster microservices.
		- Performance
			- The System.IO.FileStream type has been rewritten for .NET 6 to provide better performance and reliability
			- .NET 6 introduces Crossgen2, the successor to Crossgen, which has been removed. Crossgen and Crossgen2 are tools that provide ahead-of-time (AOT) compilation to improve the startup time of an app. Crossgen2 is written in C# instead of C++, and can perform analysis and optimization that weren't possible with the previous version
			- Hot reload is a feature that lets you modify your app's source code and instantly apply those changes to your running app.
			- .NET Multi-platform App UI (.NET MAUI) is still in preview, with a release candidate coming in the first quarter of 2022 and general availability (GA) in the second quarter of 2022. .NET MAUI makes it possible to build native client apps for desktop and mobile operating systems with a single codebase
			- 
	
	Services
		- framework services like addMVc, identity, efcore services
		- application specific services which we can add
		- builder.Services.Addxxxx();
		-Once all services are registered, web app can be built.
		- var app = builder.Build();
		- has option as services.addControllers(), .addControllersWithViews
		-
	Reuqest pipeline
		- app.Usexxxx()
		- 
	Controller Class
		- has [ApiController]
		- ControllerBase, Controller to inherit options


AKS
	- Clusters -> Node Pools -> Nodes -> Pods
 	-AutoScaler
  		- Horizontal Pod autoscaler
    		- kubectl autoscale deployment myApp \
      		- --cpu-percent=50 --min=2 --max=5
		-
  	-Upgrade an AKS Cluster
   		- One or more Buffer Node is created with new version
     		- Old nodes are drained one by one
       		- At last buffer node is removed
	 	- Automatic upgrades 
   			-none(default), patch, stable, rapid
      	- Delete / Stop AKS Cluster
       		- 

Algorithms & DS
	- Order of growth
 		- 2^N : exponsential
   		- N^3 : Cubic
     		- N^2 : Quadratic
       		- N Long N : Linearithmic
	 	- N : linear
   		- Log N : logarithmic
     		- 1 : constant
       - 



Elastic Search
	-Can build complex seach 
	-Full text serach
	-Query and analyze structured data
	-Analyse application logs
		-App performance management
	-Analyse lots of data
	-can use ML
	-Anomality detection
	-
	-Data is stored as documents
	-Documents have fields
	-Has
		-Logstash
			-Data processing pipelines
			-Input plugins could be kafka queues, mails, files, DB etc
			-Has filter plugins
			-Output plugins or stashes
			
		-X-pack
			-adds additional features to elastic serach and kibana
			-used for LDAP auth, RBAC etc
			-used for monitoring
			-Alerting on unusual activities 
			-Reporting
			-enables machine learning
				-Anamoloty detection
				-Forecasting future values like number of visitors and plan scalability accordingly
			-Graph
				-considers relavance with elastic search with what is related and what isn't
				-exposes API to integrate with API
				-plugin for kibana with visualization
			-SQL
				-are written in Query DSL
				-bit verbose
				-Can send SQL queries to ES via http or through JDBC driver
		-Kibana
			-Visualized data
		-Beats
			-Collection of data 
			-FileBeat
				-collecting log files,nginx, apache
			-MetricsBeat
				-collects system ans service metrics
	-Setup
		-elasticsearch-create-enrollment-token --scope kibana
		-elasticsearch-reset-password -u elastic -i --url https://localhost:9200
		-
	-Clusters
		-has Nodes
		-Nodes store data that we add to ES
	-Documents
		-json objects
		-stored/grouped as indices
	-Index
		-logically related
		-Search queries run against indices
	-Sharding
		-divide index into separate pieces
		-and place it in Nodes
		-Queries can be distributed
		-improves the throughput of index
		-heps to scale
	-Replication
		-ES Natively supports replication of Shards
		-Replicate shards once in non critical prod apps
  		-Replicate shards at least twice with 2 nodes for critical apps
    		-has primary and replica shards, if replica shard is unassigned then it needs a new node
    	-Snapshots
     		-ES uses snapshots as backups
       		-restore to a given point in time
	 	-
   	-Node roles
    		-Master nodes
      		-Data nodes
			-stores data
		-Ingest
  			-adding a document to index
     			-series of steps performed when indexing documents
		-Machine learning
  			-used to run dedicated ml nodes
     		-coordination
       			-node which used only how ES distributes queries and the aggregation of results
	  -








  
