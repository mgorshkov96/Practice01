# Исследование скорости выполнения арифметических операций
В этом исследовании сравнивается скорость выполнения алгоритма DGEMM (https://iq.opengenus.org/dgemm/) на разных языках программирования, в зависимости от используемого типа данных и количества элементов матриц.

## Языки
- Python;
- java;
- C#.

## Основные особенности
- Все программы получали одинаковые данные;
- Интервал значений для Int и Double: от -100 до 100;
- Интервал значений для BigInt: от -100000000000 до 100000000000;
- Все значения генерировались случайным образом при помощи [программы-генератора](https://github.com/mgorshkov96/Practice01/blob/main/Exercises/Exercise04/value_generator.py);
- Каждое вычисление выполнялось 100 раз подряд (в цикле);
- Количество элементов матриц (a x a), при выполнении исследовния, фиксированное: 25, 50, 100, 200;
- С результатами можно ознакомиться [здесь](https://github.com/mgorshkov96/Practice01/tree/main/Exercises/Exercise04/Results).