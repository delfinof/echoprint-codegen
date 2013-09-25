#pragma once

namespace codegen_wp8
{
	public ref class Class1 sealed
	{
	private:
		Codegen *a;
		~Class1();
	public:
		Class1(const Platform::Array<byte>^ something, int offset);

		Platform::String^ getCodeString(){
			std::string result("");
			if (a != NULL)
			{
				result = a->getCodeString();
			}
			std::wstring unicode(result.begin(), result.end());
			Platform::String^ fooRT = ref new Platform::String(unicode.c_str());

			return fooRT;
		}

		int getNumCodes() {
			if (a != NULL)
			{
				return a->getNumCodes();
			}
		}

		double getVersion() {
			return Codegen::getVersion();
		}
	};
}