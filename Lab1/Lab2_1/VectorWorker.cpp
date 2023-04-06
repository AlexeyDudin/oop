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

//Переименовать
void SubstractValueFromVectorElements(std::vector<float> &inputVector, float median)
{
	//transform || range_based_for...
	std::transform(inputVector.begin(), inputVector.end(), inputVector.begin(), [&median](float elementValue) { elementValue -= median; });
}

void PrintVector(const std::vector<float>& inputVector)
{
	//аналогично
	for (float elementValue : inputVector)
	{
		std::cout << elementValue << " ";
	}
	std::cout << std::endl;
}

//сделать ссылку, а не указатель
float FindMedian(const std::vector<float>& inputVector)
{
	auto cloneVector(inputVector);

	//mid || median
	auto middle = cloneVector.begin() + cloneVector.size() / 2;
	std::nth_element(cloneVector.begin(), middle, cloneVector.end());
	auto median = cloneVector[cloneVector.size() / 2];
	return median;
}

std::vector<float> SortVector(const std::vector<float>& inputVector)
{
	auto sortVector(inputVector);
	std::sort(sortVector.begin(), sortVector.end());
	return sortVector;
}
