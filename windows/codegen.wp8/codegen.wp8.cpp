// codegen.wp8.cpp
#include "pch.h"
#include "codegen.wp8.h"

using namespace codegen_wp8;
using namespace Platform;

float pippo[1024];


WindowsPhoneRuntimeComponent::WindowsPhoneRuntimeComponent()
{
	Codegen a(pippo, 1024, 0);

	
}
