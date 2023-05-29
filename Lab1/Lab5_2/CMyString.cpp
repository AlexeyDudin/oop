#include "CMyString.h"

CMyString::CMyString()
{
	InitializeByLenght(1);
	*this->startPtr = 0;
	this->count = 0;
}

CMyString::CMyString(const char* pString)
{
	InitializeByLenght(strlen(pString));
	for (int i = 0; i < strlen(pString); i++)
	{
		char* currPtr = this->startPtr + i;
		*currPtr = pString[i];
	}
}

CMyString::CMyString(const char* pString, size_t length)
{
	InitializeByLenght(length);
	this->count = strlen(pString) > length ? length : strlen(pString);
	FillMyCharacter(pString);
}

CMyString::CMyString(CMyString const& other)
{
	InitializeByLenght(other.GetLength());
	this->count = other.GetLength();
	FillMyCharacter(other.GetStringData());
}

CMyString::CMyString(CMyString&& other)
{
}

void CMyString::InitializeByLenght(size_t lenght)
{
	this->startPtr = (char*)malloc(lenght);
}

void CMyString::FillMyCharacter(const char* pString)
{
	
	for (int i = 0; i < this->count; i++)
	{
		char* currPtr = this->startPtr + i;
		*currPtr = pString[i];
	}
}
