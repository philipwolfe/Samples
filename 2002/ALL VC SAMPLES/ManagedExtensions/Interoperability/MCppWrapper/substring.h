//__declspec(dllexport)
class substring
{
public:
	substring();
	substring(const char * const);
	~substring();

	const char * getstring();
	char * suffix(int n);
private:
	char * str;
	unsigned short len;
};