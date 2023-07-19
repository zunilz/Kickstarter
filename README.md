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
