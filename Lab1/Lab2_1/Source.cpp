#include "VectorWorker.h"
//������� �� ������� �������� ��������� ������� �������� ��� �������.
//���������: ����������� �������� std::nth_element, ����� ����� ��������� ������� �������.
//������, ��� nth_element �������� ������� ��������� ������� ��������� ����������.


int main(int argc, char ** argv)
{
	setlocale(LC_ALL, "Russian");
	std::cout << "������� �������� ������� (����� ������). ������������ ������� \'Enter\'" << std::endl;
	auto fillVector = FillVectorFrom(std::cin);

	float median = FindMedian(&fillVector);
	std::cout << "��������� �������: " << median << std::endl;
	VectorMinusMedian(&fillVector, median);
	std::cout << std::endl << "������� ������ � ��������� ��������: ";
	PrintVector(&fillVector);
	std::cout << std::endl << "������������� ������ � ��������� ��������: ";
	auto sortVector = SortVector(&fillVector);
	PrintVector(&sortVector);
}