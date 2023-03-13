#include "VectorWorker.h"
#include <string>
#include <sstream>

std::vector<float> FillVectorFrom(std::istream &inputStream)
{
	std::vector<float> result;
	float readValue = 0;

	float value;
	std::string line = "";
	std::getline(inputStream, line);
	std::istringstream iss(line);
	while (iss >> value) {
		result.push_back(value);
	}
	return result;
}

void ModifyElementInVector(float& value, const float *median)
{
	value -= *median;
}

void VectorMinusMedian(std::vector<float> *inputVector, float median)
{
	std::for_each(inputVector->begin(), inputVector->end(), [&](float& n)
	{
		n -= median;
	});
}

void PrintVector(const std::vector<float>* inputVector)
{
	std::for_each(inputVector->begin(), inputVector->end(), [&](float n)
	{
		std::cout << n << " ";
	});
	std::cout << std::endl;
}

float FindMedian(const std::vector<float>* inputVector)
{
	auto cloneVector(*inputVector);

	auto m = cloneVector.begin() + cloneVector.size() / 2;
	std::nth_element(cloneVector.begin(), m, cloneVector.end());
	auto median = cloneVector[cloneVector.size() / 2];
	return median;
}

std::vector<float> SortVector(const std::vector<float>* inputVector)
{
	auto sortVector(*inputVector);
	std::sort(sortVector.begin(), sortVector.end());
	return sortVector;
}
