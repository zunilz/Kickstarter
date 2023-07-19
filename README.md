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
  - 	


   

















  
