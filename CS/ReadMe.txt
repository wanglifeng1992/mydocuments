*******************************************************************************
*                                                                             *                               
*                               TREEVIEW TEMPLATE                             *
*                               -----------------                             *
* By Mark Thorogood                                                           *
* Nov 01, 02                                                                  *
*******************************************************************************

I built the following template to demonstrate how to program a TreeView 
interface.  I searched the net for examples, but I could not find a 
comprehensive example.  I hope that you find the following valuable.  Enjoy:)

OVERVIEW:

The following program provides a template for creating a TreeView interface 
where nodes can be added, deleted, renamed, and moved via drag and drop.  
Additionally, this template provides methods to synchronize the node 
collection with a database.

WHEN YOU FIRST RUN THE PROGRAM:

You will have to find the database file TreeViewEx.mdb.

FUNCTION SUMMARY:

The template provides examples for the following functionality:

	1.  Drag and drop of node(s) within a single TreeView control.

	2.  Synchronize a TreeView Node Collection with a database.

	3.  Add, Delete, and Rename a node within a TreeView control.

	4.  Methods to recursively scan trees to perform delete, save, and 
	    populate operations.  The functions provide an efficient and 
	    effective transformation between rectangular and TreeView 
	    (hierarchical) datasets.

	5.  Connect to and manipulate an MS Access database using ADO.NET.

	6.  Method to escape special characters such as single quotes that can 
	    cause UPDATE and INSERT SQL statements to fail when executed against 
	    a command object.

	7.  Function to test if a drag and drop operation will cause a circular 
	    reference such as a node being dragged to and dropped on one of 
	    its children.

	8.  Function that substitutes for VB6 App.Path function.

	9.  A means to store TreeView Node relationships using a collection.  
	    This provides a substitute for VB6 TreeView key property that was 
	    used to retrieve a node by a key value.

	10.  A method to store Node deletions in memory by storing them in a 
	     collection.  This allows deletes to be rolled back if the user 
	     chooses to not accept changes.

	11.  Demonstrates a method for separating data services into a separate 
	     class.  Separation or abstraction of the data services allows the 
	     programmer to efficiently support multiple or different database 
	     systems.  In particular, CDataServices object demonstrates the 
	     following:

			a.  Retrieving a DataReader object from a function.
			b.  Executing NonQuery statements (i.e. UPDATE,
				INSERT, and DELETE).
			c.  Retrieving a Scalar (or aggregate value) (e.g.
				Sum(), Count(), Max(), Min(), etc.).

	12.  Demonstrates a method for handling node image changes as nodes are 
		 moved, deleted, or added causing the status of nodes to change between 
		 root, branch, and leaf nodes.
