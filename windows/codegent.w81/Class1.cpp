// Class1.cpp
#include "pch.h"
#include "Class1.h"

using namespace codegent_w81;
using namespace Platform;

Class1::Class1(const Platform::Array<byte>^ something, int offset)
{
	int i = 0;
	float *buffer = (float *)malloc(something->Length/2 * sizeof(float) );
	if (buffer != NULL) { 
		byte *myarray = something->Data;
		short *myarray_s = (short *) myarray;
		int len = something->Length;
		for (i = 0; i < len/2; i++)
		{
			buffer[i] = myarray_s[i];
		}

		a = new Codegen(buffer , len/2,  offset);
	}
}

Class1::~Class1()
{
	if (a!=NULL)
		delete a;
}