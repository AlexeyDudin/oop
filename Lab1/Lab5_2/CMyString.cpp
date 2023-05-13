#include "CMyString.h"

CMyString::CMyString()
{
	this->startPtr = nullptr;
	this->count = 0;
}

CMyString::CMyString(const char* pString)
{
	InitializeByLenght(strlen(pString));

}

void CMyString::InitializeByLenght(unsigned long lenght)
{
	PMyCharacter currPtr;
	for (int i = 0; i < lenght; ++i)
	{
		if (this->startPtr == nullptr)
		{
			this->startPtr = new MyCharacter;
			currPtr = this->startPtr;
		}
		else
		{
			currPtr->next = new MyCharacter;
			currPtr = currPtr->next;
		}
		currPtr->ch = '\0';
		currPtr->next = nullptr;
	}
}

void CMyString::FillMyCharacter(const char* pString)
{
}
