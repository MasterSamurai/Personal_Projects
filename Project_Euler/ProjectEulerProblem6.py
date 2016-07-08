# Problem 6
"""Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum."""
def diff(number_of_nums):
    sumOfSquares, sum = 0, 0
    for i, k in zip(range(number_of_nums+1), range(number_of_nums+1)):
        sumOfSquares += i**2
        sum += k
    return sum**2 - sumOfSquares
