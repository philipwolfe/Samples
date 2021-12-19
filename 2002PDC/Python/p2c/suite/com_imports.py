# Test we can import arbitary namespaces and classes
q = COR.System.Collections.Queue()
if q.Count != 0: print "Queue should be empty"
q.Enqueue("Hello there")
if q.Count != 1: 
	raise RuntimeError, "Queue should have an item"

if q.Dequeue() != "Hello there": 
	raise RuntimeError, "Couldnt get the top of the queue"
print "The queue", q, "worked"

# Test that static fields work
#import COR.System.Reflection.Emit
print "The pop opcode is", COR.System.Reflection.Emit.OpCodes.Pop

# Default property get-and-set for COM+ objects.
d = COR.System.Collections.Hashtable()
d["Mark"] = "Hi"
if d["Mark"] != "Hi":
	raise RuntimeError, "Couldnt get a COM+ dict item!"
print "The hashtable", d, "worked"

# See if it works better then COM/COM+ integration :-)
# We have static methods.
COR.System.Console.WriteLine("Hi from Python")
