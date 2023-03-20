#pragma once
#include <set>
#include <vector>
#include <iostream>

std::set<int> GeneratePrimeNumbersSet(int upperBound);
void PrintPrimeNumberSet(const std::set<int>& primeNumberSet, std::ostream& ouput);