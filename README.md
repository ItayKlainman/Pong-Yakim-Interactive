**# Pong-Yakim Interactive: READ ME**

Pong assignment for Yakim Interactive.
The assignment is following our conversion in the interview, regarding my approach to the architecture of the classic game "Pong".
As you'll see in the project, the architecture has been change from what we talked about in the interview. 

After starting to build the project, Ive came to the decision of using SerializedFields and Injections instead of events. 
I thought of also creating a game loader, which injects the flow of the data to a *non MonoBehavior* manager, which will continue the flow
of data throughout the controllers.
But, because this project was required to be simple, and there are very vew components that need to communicate, I've decided to implement the communication via SerializedField and 
minimal action injections through a single manager, as it is cleaner, more maintainable and easier to understand the data flow. 

I hope you'll take those consideriations into account when reviewing this project. 

Itay Klainman.
