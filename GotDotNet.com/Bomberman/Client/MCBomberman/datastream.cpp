#include "datastream.h"	

#ifdef _DEBUG
ostream& operator << (ostream& out, const StreamObject& obj)
{ 
	obj.print(out); 
	return out; 
}
#endif