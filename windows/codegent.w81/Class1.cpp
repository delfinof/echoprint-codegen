// Class1.cpp
#include "pch.h"
#include "Class1.h"

using namespace codegent_w81;
using namespace Platform;

float pippo[1024];

Class1::Class1()
{
	Codegen a(pippo, 1024, 0);
}
