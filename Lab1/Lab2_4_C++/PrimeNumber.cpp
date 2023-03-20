#include "PrimeNumber.h"

//std::set<int> FillSet(int upperBound)
//{
//    std::set<int> result;
//    for (int i = 0; i < upperBound; i++)
//    {
//        result.insert(i);
//    }
//    return result;
//}

std::vector<bool> FillUsingVector(int size)
{
    std::vector<bool> result;
    result.assign(sizeof(bool) * size + 1, true);
    return result;
}

void ExcludeElement(std::vector<bool>& usingVector, int element)
{
    for (int multiplyer = 2; (multiplyer * element) < usingVector.size(); multiplyer++)
    {
        usingVector[multiplyer * element] = false;
    }
}

std::set<int> FillEratosphen(int upperBound)
{
    std::vector<bool> usingVector = FillUsingVector(upperBound);
    std::set<int> result;
    for (int i = 2; i < upperBound; i++)
    {
        if (usingVector[i])
            ExcludeElement(usingVector, i);
    }
    for (int i = 1; i < usingVector.size(); i++)
    {
        if (usingVector[i])
            result.insert(i);
    }
    return result;
}

std::set<int> GeneratePrimeNumbersSet(int upperBound)
{
    std::set<int> result = FillEratosphen(upperBound);
    return result;
}

void PrintPrimeNumberSet(const std::set<int>& primeNumberSet, std::ostream& output)
{
    for (std::set<int>::iterator it = primeNumberSet.begin(); it != primeNumberSet.end(); it++)
    {
        output << *it << " ";
    }
    output << std::endl;
}
