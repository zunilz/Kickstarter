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
















  
