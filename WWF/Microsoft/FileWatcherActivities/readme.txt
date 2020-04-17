This sample is a slight modification to the FileWatcher sample from www.WindowsWorkflow.NET.  It works around the issues that the sample has with being used within a while activity or a state machine workflow.  To run the sample follow these steps:

1. Create c:\temp1 and c:\temp2.  These are the locations that the sequential and state machine workflows will be looking for files.
2. Run the project within VS.
3. Add a new file to each directory and notice the output on the console.