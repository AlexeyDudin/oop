#include "VectorWorker.h"
//Вычесть из каждого элемента исходного массива значение его медианы.
//Подсказка: используйте алгоритм std::nth_element, чтобы найти медианный элемент массива.
//Учтите, что nth_element изменяет порядок элементов порядок элементов контейнера.


int main(int argc, char ** argv)
{
	setlocale(LC_ALL, "Russian");
	std::cout << "Введите элементы массива (через пробел). Позавершении нажмите \'Enter\'" << std::endl;
	auto fillVector = FillVectorFrom(std::cin);

	float median = FindMedian(&fillVector);
	std::cout << "Полученая медиана: " << median << std::endl;
	VectorMinusMedian(&fillVector, median);
	std::cout << std::endl << "Получен вектор с вычтенной медианой: ";
	PrintVector(&fillVector);
	std::cout << std::endl << "Сортированный вектор с вычтенной медианой: ";
	auto sortVector = SortVector(&fillVector);
	PrintVector(&sortVector);
}