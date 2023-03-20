#include "PrimeNumber.h"

int main(int argc, char** argv)
{
	std::istream& input = std::cin;
	std::ostream& output = std::cout;


	setlocale(LC_ALL, "Russian");

	int upperBound = 0;
	output << "¬ведите максимальное значение простого числа: ";
	input >> upperBound;
	std::set<int> valuesSet = GeneratePrimeNumbersSet(upperBound);
	PrintPrimeNumberSet(valuesSet, output);

}