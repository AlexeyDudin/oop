#pragma once
#include <vector>
#include <iostream>
#include <algorithm>

std::vector<float> FillVectorFrom(std::istream &inputStream);
void VectorMinusMedian(std::vector<float> *inputVector, float median);
void PrintVector(const std::vector<float>* inputVector);
float FindMedian(const std::vector<float>* inputVector);
std::vector<float> SortVector(const std::vector<float>* inputVector);