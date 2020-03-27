AtlSafeArray shows how to use CComSafeArray as well as passing SAFEARRAYs to 
script. The AtlSafeArray project is an ATL component.  Build the project which 
also registers the component.  Then run AtlSafeArray.htm.  This page contains
a list which is maintained in a CComSafeArray in the ATL component.  The
buttons Add, Change and Remove all call into the ATL component which in turn
updates the CComSafeArray.  Refer to ArrayManager.cpp to see how these methods
are implemented.